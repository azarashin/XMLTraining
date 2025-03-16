using System.Xml;
using System.Xml.Serialization;

namespace Core
{
    public abstract class Training
    {
        public abstract string GetTitle();
        public abstract object GetXML();
        public abstract Type GetXMLType(); 
        public abstract XmlSerializerNamespaces GetNamespaces();


        public void Run(int index)
        {
            object obj = GetXML();
            XmlSerializer serializer = new XmlSerializer(GetXMLType());
            XmlSerializerNamespaces namespaces = GetNamespaces();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineOnAttributes = false
            };
            using (XmlWriter xmlWriter = XmlWriter.Create($"output/{index}_{GetTitle()}.xml", settings))
            {
                serializer.Serialize(xmlWriter, obj, namespaces);
            }

            Console.WriteLine($"XML({index}_{GetTitle()}) file has been created.");

        }
    }
}