using System;
using System.IO;
using System.Xml.Serialization;

namespace Training002
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "数値列";
        }

        public override object GetXML()
        {
            XYZ xyz = new XYZ
            {
                id = 1,
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
        public int id { get; set; }
        public double[] values = Array.Empty<double>(); 
    }

}
