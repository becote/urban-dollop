using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.Serialization;
using WindowsFormApp.AccesDonnees;
using WindowsFormApp.Persistence;

namespace WindowsFormApp
{
    public partial class Form1 : Form
    {
        private string fullFilePath = "";
        private List<RandomObject> randomObjects = new List<RandomObject>();
        private ConverterXMLContext context;
        private RandomObjectRepository randomObjectRepository;
        public Form1()
        {
            InitializeComponent();

            context = CreateContext();

            randomObjectRepository = new RandomObjectRepository(context);
        }

        private static ConverterXMLContext CreateContext()
        {
            DbContextOptionsBuilder<ConverterXMLContext> optionsBuilder = new DbContextOptionsBuilder<ConverterXMLContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["bdProjetsConverterConnectionString"].ConnectionString);
            return new ConverterXMLContext(optionsBuilder.Options);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            CheckInputFields();
            LoadXMLFile(fullFilePath);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select the XLM source file.";
            openFile.CheckFileExists = true;
            openFile.InitialDirectory = @"c:\tmp\";
            openFile.Filter = "XML (*.xml)|*.xml";
            openFile.FilterIndex = 0;
            openFile.RestoreDirectory = true;
            if(openFile
                .ShowDialog() == DialogResult.OK)
            {
                fullFilePath = openFile.FileName;
                textBox1.Text = Path.GetFileName(openFile.FileName);
            }
        }

        private void CheckInputFields()
        {
            if(textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select a file");
            }
        }

        private void AddRandomObjectToDB(List<RandomObject> randomObjects)
        {
            
            try
            {
                foreach (RandomObject obj in randomObjects)
                {
                    randomObjectRepository.AjouterRandomObject(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oups : " + ex.Message);
            }

            MessageBox.Show("Successfuly added, check the db");
        }

        private void LoadXMLFile(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectContainer));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    ObjectContainer container = (ObjectContainer)serializer.Deserialize(fileStream);

                    randomObjects = container.RandomObjects;

                    AddRandomObjectToDB(randomObjects);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}