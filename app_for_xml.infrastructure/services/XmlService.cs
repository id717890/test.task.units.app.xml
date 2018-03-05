using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Ajax.Utilities;

namespace app_for_xml.infrastructure.services
{
    using System;
    using System.Xml.Linq;

    public class XmlService : IXmlService
    {
        public string CreateXmlContent(string fileName, string version, DateTime date, string content)
        {
            var doc = new XDocument();

            //Cоздаем элемент FIle и добавляем атрибут 
            var fileElement = new XElement("File");
            var fileElementAttr = new XAttribute("FileVersion", version);
            fileElement.Add(fileElementAttr);

            //Cоздаем элемент Name
            var nameElement = new XElement("Name", fileName);

            //Cоздаем элемент DateTime
            var dateElement = new XElement("DateTime", date.ToString("dd.MM.yy HH:mm"));

            //Cоздаем элемент Content где будет остальное содержимое файла
            var contentElement = IsXml(content) ? new XElement("Content", XElement.Parse(content, LoadOptions.None)) : new XElement("Content", content);
            fileElement.Add(nameElement, dateElement, "\r\n"+content );
            //fileElement.Add();
            doc.Add(fileElement);
            return doc.ToString();
        }

        /// <summary>
        /// Проверяет, является строка xml или нет
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsXml(string str)
        {
            try
            {
                var xElement = XElement.Parse(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsXmlValid(string str)
        {
            try
            {
                var xElement = XDocument.Parse(str);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ExtractOnlyContent(string str)
        {
            var doc = XDocument.Parse(str);
            doc.Descendants().First(x => x.Name == "Name").Remove();
            doc.Descendants().First(x => x.Name == "DateTime").Remove();

            const string r = @"<File\s*.*?>\s*(.*)\s*\</File>";
            Regex regex = new Regex(r, RegexOptions.Singleline);
            var data = regex.Match(doc.ToString()).Groups[1].Value;
            //string s = v.Groups[1].ToString();


            //var nodes = doc.Root.Descendants();
            //var data = "";
            //foreach (var i in nodes)
            //{
            //    data = data + i + "\r\n";

            //}
            return data;
        }
    }
}
