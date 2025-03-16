using System;
using System.IO;
using System.Xml.Serialization;

namespace Training011
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "XmlElement要素";
        }

        public override object GetXML()
        {
            XYZ xyz = new XYZ
            {
                id = 1,
                value = new XYZChild
                {
                    id = 0
                }
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

    public class XYZChild
    {
        [XmlElement(Namespace = "http://www.example.com/namespaceA")]
        public int id { get; set; }
    }

    public class XYZ
    {
        [XmlElement(Namespace = "http://www.example.com/namespaceA")]
        public int id { get; set; }
        [XmlElement(Namespace = "http://www.example.com/namespaceA")]
        public XYZChild? value = null; 
    }

}
