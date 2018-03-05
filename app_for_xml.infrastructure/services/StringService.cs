namespace app_for_xml.infrastructure.services
{
    using System.Text.RegularExpressions;

    public class StringService : IStringService
    {
        public bool CheckFormat(string str)
        {
            var data = str.Split('_');
            return data.Length == 3;
        }

        public bool FirstPartShouldBeCyrilic(string str)
        {
            if (!CheckFormat(str)) return false;

            const string r = "^[а-яА-ЯёЁ]{1,100}$";
            var reqex = new Regex(r);
            var data = str.Split('_');
            return reqex.IsMatch(data[0]);
        }

        public bool SecondPartShouldBeNumber(string str)
        {
            if (!CheckFormat(str)) return false;

            const string r = "^[0-9]{1}$";
            var reqex = new Regex(r);
            var data = str.Split('_');
            return reqex.IsMatch(data[1]);
        }

        public bool ThirdPartShouldBeAny(string str)
        {
            if (!CheckFormat(str)) return false;

            const string r = "^.{1,7}$";
            var reqex = new Regex(r);
            var data = str.Split('_');
            return reqex.IsMatch(data[2]);
        }
    }
}
