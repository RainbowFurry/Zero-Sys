using Aspose.Pdf;
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

        /// <summary>
        /// Convert Word Document to PDF Document
        /// </summary>
        /// <param name="filePath"></param>
        public void ConvertWordToPDF(string filePath)
        {

            Aspose.Words.Document wordDocument = new Aspose.Words.Document(filePath);
            wordDocument.Save(filePath.Replace(".doc", ".pdf").Replace(".docx", ".pdf"), Aspose.Words.SaveFormat.Pdf);

        }
        private static Document wordDocument { get; set; }

        /// <summary>
        /// Convert PDF To Doc
        /// </summary>
        /// <param name="filePath"></param>
        public void ConvertPDFToDoc(string filePath)
        {

            // Open the source PDF document
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(filePath);

            // Save the file into MS document format
            pdfDocument.Save(filePath.Replace(".pdf", ".doc"), SaveFormat.Doc);

        }

        /// <summary>
        /// Convert PDF to DocX
        /// </summary>
        /// <param name="filePath"></param>
        public void ConvertPDFToDocX(string filePath)
        {

            // Open the source PDF document
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(filePath);

            // Save using save options
            // Create DocSaveOptions object
            DocSaveOptions saveOptions = new DocSaveOptions();

            // Set the recognition mode as Flow
            saveOptions.Mode = DocSaveOptions.RecognitionMode.Flow;

            // Set the Horizontal proximity as 2.5
            saveOptions.RelativeHorizontalProximity = 2.5f;

            // Enable the value to recognize bullets during conversion process
            saveOptions.RecognizeBullets = true;

            // Save the resultant DOC file
            pdfDocument.Save(filePath.Replace(".pdf", ".docx"), saveOptions);

        }

    }
}
