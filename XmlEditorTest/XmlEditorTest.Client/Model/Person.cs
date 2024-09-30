using System.Xml.Serialization;

[XmlRoot("Person")]
public class Person
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Age")]
    public int Age { get; set; }
}
