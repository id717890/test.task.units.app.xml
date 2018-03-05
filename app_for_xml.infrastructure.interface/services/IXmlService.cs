namespace app_for_xml.infrastructure.services
{
    using System;

    public interface IXmlService
    {
        string CreateXmlContent(string fileName, string version, DateTime date, string content);
        bool IsXml(string str);
    }
}