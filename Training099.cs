using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Training099
{
    public class Training : Core.Training
    {
        public override string GetTitle()
        {
            return "CityGMLサンプル";
        }

        public override object GetXML()
        {
            CityModel xyz = new CityModel
            {
                boundedBy = new Envelope[] 
                {
                    new Envelope
                    {
                        lowerCorner = new double[] { 35.7082128028541, 139.76215456836624, 0 },
                        upperCorner = new double[] { 35.71678825577485, 139.77510002092876, 137.58374023355998 }
                    }
                }, 
                appearanceMember = new Appearance[]{
                    new Appearance
                    {
                        theme = "rgbTexture",
                        surfaceDataMember = new ParameterizedTexture[]
                        {
                            new ParameterizedTexture
                            {
                                imageURI = "53394651_bldg_6697_appearance/tk3019180.jpg",
                                mimeType = "image/jpg",
                                texCoordListTarget = new TexCoordListTarget
                                {
                                    uri = "#poly_TK3019180_p84081_3",
                                    target = new TexCoordList
                                    {
                                        textureCoordinates = new UVList
                                        {
                                            ring = "#line_TK3019180_p84081_3",
                                            textureCoordinates = new UV[]
                                            {
                                                new UV { u = 0.8563101, v = 0.9017087 },
                                                new UV { u = 0.8468469, v = 0.9017087 },
                                                new UV { u = 0.8468469, v = 0.7083333 },
                                                new UV { u = 0.8563101, v = 0.7083333 }, 
                                                new UV { u = 0.8563101, v = 0.9017087 },
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }, 
                cityObjectMember = new Building[]
                {
                    new Building
                    {
                        id = "bldg_831c94cd-ced1-4eff-976a-8ce9c724bac7",
                        creationDate = "2024-03-15",
                        BuildingClass = new BuildingClass
                        {
                            codeSpace = "../../codelists/Building_class.xml",
                            buildingClass = "3002"
                        },
                        measuredHeight = new MeasuredHeight
                        {
                            uom = "m",
                            measuredHeight = 30.9
                        },
                        lod1Solid = new Solid[]
                        {
                            new Solid
                            {
                                exterior = new CompositeSurface[]
                                {
                                    new CompositeSurface
                                    {
                                        surfaceMember = new Polygon[]
                                        {
                                            new Polygon
                                            {
                                                exterior = new LinearRing
                                                {
                                                    posList = new PositionList
                                                    {
                                                        positionList = new Position[]
                                                        {
                                                            new Position { lat = 35.7082128028541, lng = 139.76215456836624, height = 0 },
                                                            new Position { lat = 35.7082128028541, lng = 139.76215456836624, height = 137.58374023355998 },
                                                            new Position { lat = 35.71678825577485, lng = 139.77510002092876, height = 137.58374023355998 },
                                                            new Position { lat = 35.71678825577485, lng = 139.77510002092876, height = 0 },
                                                            new Position { lat = 35.7082128028541, lng = 139.76215456836624, height = 0 },
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("gml", "http://www.opengis.net/gml");
            namespaces.Add("app", "http://www.opengis.net/citygml/appearance/2.0");
            namespaces.Add("core", "http://www.opengis.net/citygml/2.0");
            namespaces.Add("bldg", "http://www.opengis.net/citygml/building/2.0");
            
            return namespaces;
        }
    }

    public class Envelope
    {
        [XmlAttribute]
        public string srsName="http://www.opengis.net/def/crs/EPSG/0/6697";

        [XmlAttribute]
        public int srsDimension = 3; 

        [XmlIgnore]
        public double[] lowerCorner = Array.Empty<double>(); 

        [XmlElement("lowerCorner", Namespace = "http://www.opengis.net/gml")]
        public string lowerCornerString
        {
            get => lowerCorner != null ? string.Join(" ", lowerCorner) : string.Empty;
            set => lowerCorner = value?.Split(' ').Select(double.Parse).ToArray();
        }

        [XmlIgnore]
        public double[] upperCorner = Array.Empty<double>(); 

        [XmlElement("upperCorner", Namespace = "http://www.opengis.net/gml")]
        public string upperCornerString
        {
            get => upperCorner != null ? string.Join(" ", upperCorner) : string.Empty;
            set => upperCorner = value?.Split(' ').Select(double.Parse).ToArray();
        }
    }

    public class UV
    {
        public double u;
        public double v;
    }

    public class UVList
    {
        [XmlAttribute(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public string ring; 

        [XmlIgnore]
        public UV[] textureCoordinates = Array.Empty<UV>(); 

        [XmlText]
        public string textureCoordinatesString
        {
            get => textureCoordinates != null ? 
                string.Join(" ", textureCoordinates.Select(s => $"{s.u} {s.v}"))
                :
                string.Empty;
            set
            {
                if(value is null)
                {
                    textureCoordinates = null; 
                    return; 
                }
                string[] values = value?.Split(' ').ToArray();
                if(values.Length % 2 != 0)
                {
                    throw new ArgumentException("Invalid value"); 
                }
                textureCoordinates = Enumerable
                    .Range(0, values.Length / 2)
                    .Select(s => new UV
                    {
                        u = double.Parse(values[s * 2 + 0]), 
                        v = double.Parse(values[s * 2 + 1]), 
                   })
                    .ToArray();
            }
        }

    }

    public class TexCoordList
    {
        [XmlElement("textureCoordinates", Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public UVList textureCoordinates; 

    }

    public class ParameterizedTexture
    {
        [XmlElement(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public string imageURI; 

        [XmlElement(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public string mimeType; 

//        [XmlAttribute("uri")]
        [XmlElement("target", Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public TexCoordListTarget texCoordListTarget; 
    }

    public class TexCoordListTarget
    {
        [XmlAttribute("uri")]
        public string uri { get; set; }

        [XmlElement("TexCoordList", Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public TexCoordList target;
    
    }

    public class Appearance
    {
        [XmlElement(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public string theme; 
        [XmlArray(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public ParameterizedTexture[] surfaceDataMember;
    }

    public class BuildingClass
    {
        [XmlAttribute]
        public string codeSpace; 

        [XmlText]
        public string buildingClass; 
    }

    public class MeasuredHeight
    {
        [XmlAttribute]
        public string uom; 

        [XmlText]
        public double measuredHeight; 
    }

    public class Position
    {
        public double lat; 
        public double lng; 
        public double height; 
    }

    public class PositionList
    {
        [XmlIgnore]
        public Position[] positionList = Array.Empty<Position>(); 

        [XmlText]
        public string positionListString
        {
            get => positionList != null ? 
                string.Join(" ", positionList.Select(s => $"{s.lat} {s.lng} {s.height}"))
                :
                string.Empty;
            set
            {
                if(value is null)
                {
                    positionList = null; 
                    return; 
                }
                string[] values = value?.Split(' ').ToArray();
                if(values.Length % 3 != 0)
                {
                    throw new ArgumentException("Invalid value"); 
                }
                positionList = Enumerable
                    .Range(0, values.Length / 3)
                    .Select(s => new Position
                    {
                        lat = double.Parse(values[s * 3 + 0]), 
                        lng = double.Parse(values[s * 3 + 1]), 
                        height = double.Parse(values[s * 3 + 2]), 
                   })
                    .ToArray();
            }
        }
    }

    public class LinearRing
    {
        [XmlElement("posList", Namespace = "http://www.opengis.net/gml")]
        public PositionList posList; 
    }

    public class Polygon
    {
        [XmlElement("exterior", Namespace = "http://www.opengis.net/gml")]
        public LinearRing exterior; 
    }

    public class CompositeSurface
    {
        [XmlArray("surfaceMember", Namespace = "http://www.opengis.net/gml")]
        public Polygon[] surfaceMember;
    }

    public class Solid
    {
        [XmlArray("exterior", Namespace = "http://www.opengis.net/gml")]
        public CompositeSurface[] exterior; 
    }

    public class Building
    {
        [XmlAttribute("id", Namespace = "http://www.opengis.net/gml")]
        public string id; 

        [XmlElement("creationDate", Namespace = "http://www.opengis.net/citygml/2.0")]
        public string creationDate; 

        [XmlElement("class", Namespace = "http://www.opengis.net/citygml/building/2.0")]
        public BuildingClass BuildingClass;

        [XmlElement("measuredHeight", Namespace = "http://www.opengis.net/citygml/building/2.0")]
        public MeasuredHeight measuredHeight; 

        [XmlArray("lod1Solid", Namespace = "http://www.opengis.net/citygml/building/2.0")]
        [XmlArrayItem("Solid", Namespace = "http://www.opengis.net/gml")]
        public Solid[] lod1Solid; 
    }

    public class CityModel
    {
        [XmlArray(Namespace = "http://www.opengis.net/gml")]
        public Envelope[]? boundedBy = null; 

        [XmlArray(Namespace = "http://www.opengis.net/citygml/appearance/2.0")]
        public Appearance[]? appearanceMember = null; 

        [XmlArray("cityObjectMember", Namespace = "http://www.opengis.net/citygml/2.0")]
        [XmlArrayItem("Building", Namespace = "http://www.opengis.net/citygml/building/2.0")]
        public Building[]? cityObjectMember = null;
    }

}
