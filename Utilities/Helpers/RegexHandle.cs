using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Utilities.Helpers
{
    public class RegexHandle
    {
        public static bool IsUsername(string username)
        {
            string pattern = "^[a-zA-Z][a-zA-Z0-9]{4,12}";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(username);
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"(84|0[3|5|7|8|9])+([0-9]{8})\b").Success;
        }

        public static bool IsEmail(string email)
        {
            return Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success;
        }

        //public static bool IsEmail(string email)
        //{
        //    var valid = true;

        //    try
        //    {
        //        var emailAddress = new MailAddress(email);
        //    }
        //    catch
        //    {
        //        valid = false;
        //    }

        //    return valid;
        //}
    }
}
