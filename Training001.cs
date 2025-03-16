using System;
using System.IO;
using System.Xml.Serialization;

namespace Training001
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "基本的なXML";
        }

        public override object GetXML()
        {
            XYZ xyz = new XYZ
            {
                id = 1,
                name = "Sample",
                date = DateTime.Now
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
        public int id { get; set; }
        public string? name { get; set; }
        public DateTime date { get; set; }
    }

}
