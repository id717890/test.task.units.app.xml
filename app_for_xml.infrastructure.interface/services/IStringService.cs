namespace app_for_xml.infrastructure.services
{
    public interface IStringService
    {
        bool CheckFormat(string str);
        bool FirstPartShouldBeCyrilic(string str);
        bool SecondPartShouldBeNumber(string str);
        bool ThirdPartShouldBeAny(string str);
    }
}