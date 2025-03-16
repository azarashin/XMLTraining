using System;
using System.IO;
using System.Xml.Serialization;

namespace Training014
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "属性と要素を両方持つケース";
        }

        public override object GetXML()
        {
            CityModel xyz = new CityModel 
            {
                BoundedBy = new BoundedBy
                {
                    Attrib = "EPSG:6668",
                    Envelope = new Envelope
                    {
                        LowerCorner = "139.691706 35.689487"
                    }
                }
            };
            return xyz; 
        }

        public override Type GetXMLType()
        {
            return typeof(CityModel); 
        }

        public override XmlSerializerNamespaces GetNamespaces()
        {
            return null;
        }
    }

    // ルート要素: core:CityModel (名前空間 http://www.opengis.net/citygml)
    [XmlRoot("CityModel", Namespace = "http://www.opengis.net/citygml")]
    public class CityModel
    {
        // gml:boundedBy 要素として出力するために、BoundedBy クラスのプロパティを定義
        [XmlElement("boundedBy", Namespace = "http://www.opengis.net/gml")]
        public BoundedBy BoundedBy { get; set; }
    }

    // boundedBy 要素を表現するクラス（属性 attrib と内部に Envelope 要素を持つ）
    public class BoundedBy
    {
        [XmlAttribute("attrib")]
        public string Attrib { get; set; }

        // 内部の gml:Envelope 要素として Envelope クラスを配置
        [XmlElement("Envelope", Namespace = "http://www.opengis.net/gml")]
        public Envelope Envelope { get; set; }
    }

    // Envelope クラス（gml:lowerCorner 要素を持つ）
    public class Envelope
    {
        [XmlElement("lowerCorner", Namespace = "http://www.opengis.net/gml")]
        public string LowerCorner { get; set; }
    }


}
