using System.Xml.Serialization;

[Serializable]
[XmlRoot("objects", IsNullable = false)]
public class ObjectContainer
{
    [XmlElement("randomObject")]
    public List<RandomObject> RandomObjects { get; set; }

    #region Méthodes
    public override string ToString()
    {
        List<string> randomObjectStrings = RandomObjects.Select(obj => obj.ToString()).ToList();
        return string.Join(", ", randomObjectStrings);
    }

    #endregion



}