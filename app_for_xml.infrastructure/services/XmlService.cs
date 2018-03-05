namespace app_for_xml.infrastructure.services
{
    using System;
    using System.Xml.Linq;

    public class XmlService: IXmlService
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
            var contentElement = IsXml(content) ? new XElement("Content", XElement.Parse(content,LoadOptions.None)) : new XElement("Content", content);
            fileElement.Add(nameElement);
            fileElement.Add(dateElement);
            fileElement.Add(contentElement);
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
    }
}
