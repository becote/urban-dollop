using System.Xml.Serialization;

[Serializable]
public class RandomObject
{
    public Guid IdRandomObj { get; set; }
    [XmlElement("name")]
    public string Name {  get; set; }
    [XmlElement("color")]
    public string Color { get; set; }
    [XmlElement("size")]
    public string Size { get; set; }
    [XmlElement("weight")]
    public string Weight { get; set; }
    [XmlElement("description")]
    public string Description { get; set; }
}


