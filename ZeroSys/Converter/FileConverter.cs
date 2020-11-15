using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ZeroSys.Converter
{
    /// <summary>
    /// FileConverter
    /// </summary>
    public class FileConverter
    {

        /// <summary>
        /// Convert XML File To Json File
        /// </summary>
        /// <param name="filePath"></param>
        public void ConvertXmlToJson(string filePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            string json = JsonConvert.SerializeXmlNode(document);

            //Remove root
            json = json.Substring(8, json.Length - 1 - 8);

            File.WriteAllText(filePath.Replace("xml", "json"), json);
        }

        /// <summary>
        /// Convert Json File to XML File
        /// </summary>
        /// <param name="filePath"></param>
        public void ConvertJsonToXml(string filePath)
        {

            StreamReader streamReader = new StreamReader(filePath);
            string jsonString = streamReader.ReadToEnd();

            XNode node = JsonConvert.DeserializeXNode(jsonString, "Root");

            XmlDocument document = new XmlDocument();
            document.LoadXml(node.ToString());

            document.Save(filePath.Replace("json", "xml"));
        }

    }
}
