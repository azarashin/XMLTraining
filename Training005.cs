using System;
using System.IO;
using System.Xml.Serialization;

namespace Training005
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "namespaceと属性付きの基本的なXML";
        }

        public override object GetXML()
        {
            XYZ xyz = new XYZ
            {
                id = 1,
                name = "Sample",
                date = DateTime.Now, 
                values = new double[] { 1.1, 2.2, 3.3 }
            };
            return xyz; 
        }

        public override Type GetXMLType()
        {
            return typeof(XYZ); 
        }

        public override XmlSerializerNamespaces GetNamespaces()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("nsA", "http://www.example.com/namespaceA");
            namespaces.Add("nsB", "http://www.example.com/namespaceB");
            return namespaces;
        }
    }

    public class XYZ
    {
        [XmlAttribute(Namespace = "http://www.example.com/namespaceA")]
        public int id { get; set; }
        [XmlAttribute(Namespace = "http://www.example.com/namespaceA")]
        public string? name { get; set; }
        [XmlAttribute(Namespace = "http://www.example.com/namespaceB")]
        public DateTime date { get; set; }

        [XmlElement(Namespace = "http://www.example.com/namespaceA")]
        public double[] values = Array.Empty<double>(); 
    }

}
