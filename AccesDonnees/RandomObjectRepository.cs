using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormApp.Persistence;

namespace WindowsFormApp.AccesDonnees
{
    class RandomObjectRepository
    {
        #region Champs
        private ConverterXMLContext context;
        #endregion

        #region Constructeur
        public RandomObjectRepository(ConverterXMLContext context)
        {
            this.context = context;
        }
        #endregion

        public void AjouterRandomObject(RandomObject randomObject)
        {
            context.RandomObjects.Add(randomObject);
            context.SaveChanges();
        }
    }
}