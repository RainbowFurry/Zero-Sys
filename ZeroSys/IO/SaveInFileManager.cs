using Newtonsoft.Json;
using System.IO;
using System.Resources;
using System.Xml;

namespace ZeroSys.IO
{
    /// <summary>
    /// SaveInFileManager
    /// </summary>
    public class SaveInFileManager
    {

        #region Resx
        //auch classen speicherbar - https://docs.microsoft.com/de-de/dotnet/framework/resources/working-with-resx-files-programmatically

        /// <summary>
        /// Save Content to Resx File
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SaveToResxFile(string filePath, string[] key, string[] value)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(filePath))
            {
                for (int i = 0; i < key.Length - 1; i++)
                {
                    resx.AddResource(key[i], value[i]);
                }
            }
        }

        /// <summary>
        /// Add Content to Resx File
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddToResxFile(string filePath, string[] key, string[] value)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(filePath))
            {
                for (int i = 0; i < key.Length - 1; i++)
                {
                    resx.AddResource(key[i], value[i]);
                }
            }
        }

        /// <summary>
        /// Remove Content from Resx File
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void RemoveFromResxFile(string filePath, string[] key, string[] value)
        {

        }

        #endregion

        #region Xml
        //JSON STRUCTURE MÖGLICH...
        //
        public void SaveToXmlFile(string filePath, string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath + fileName + ".xml"))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("title", "Graphics Programming using GDI+");
                writer.WriteElementString("author", "Mahesh Chand");
                writer.WriteElementString("publisher", "Addison-Wesley");
                writer.WriteElementString("price", "64.95");
                writer.WriteEndElement();
                writer.Flush();
            }
        }

        //
        public void AddToXmlFile()
        {

        }

        //
        public void RemoveFromXmlFile()
        {

        }

        #endregion

        #region Json

        //
        public void SaveToJsonFile(object Object, string path, string name)
        {
            using (StreamWriter file = File.CreateText(path + name + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Object);
                file.Close();
            }
            //string json = JsonConvert.SerializeObject(Object);
            //File.WriteAllText(path + name + ".json", json);
        }

        //
        public void AddToJsonFile()
        {

        }

        //
        public void RemoveFromJsonFile()
        {

        }

        #endregion

    }
}
