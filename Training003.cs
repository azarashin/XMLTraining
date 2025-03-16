using System;
using System.IO;
using System.Xml.Serialization;

namespace Training003
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "要素列";
        }

        public override object GetXML()
        {
            XYZ xyz = new XYZ
            {
                id = 1,
                values = new XYZChild[] {
                    new XYZChild()
                    {
                        id = 0
                    }, 
                    new XYZChild()
                    {
                        id = 1
                    }, 
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
            return null;
        }
    }

    public class XYZChild
    {
        public int id { get; set; }
    }

    public class XYZ
    {
        public int id { get; set; }
        public XYZChild[] values = Array.Empty<XYZChild>(); 
    }

}
