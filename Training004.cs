using System;
using System.IO;
using System.Xml.Serialization;

namespace Training004
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "属性付きの基本的なXML";
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
            return null;
        }
    }

    public class XYZ
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string? name { get; set; }
        [XmlAttribute]
        public DateTime date { get; set; }

        [XmlElement]
        public double[] values = Array.Empty<double>(); 
    }

}
