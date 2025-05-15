using System.Text.RegularExpressions;

namespace BAL.Validations
{
    public class UserValidation
    {
        public  bool ValidateEmail(string email)
        {

            if (!Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Email should be in format");
                return false;
            }
            return true;
        }
        public  bool PasswordValidation(string password)
        {

            return password.Length > 4 && password.Length < 20;

        }
    }
}
