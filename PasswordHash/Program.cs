using System.Security.Cryptography;
using System.Text;
namespace PasswordHash
{
    public class Program
    {
        private static void Main()
        {
            var passwordText = "password";
            var saltText = "saltsaltsaltsalt";
            var salt = Encoding.UTF8.GetBytes(saltText);
            var passwordHash = GeneratePasswordHashUsingSalt(passwordText, salt);
            Console.WriteLine(passwordHash);
        }
        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {
            var iterate = 10000;
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            var hash = pbkdf2.GetBytes(20);
            Array.Resize(ref salt, 36);
            Array.Copy(hash, 0, salt, 16, 20);
            var passwordHash = Convert.ToBase64String(salt);
            return passwordHash;
        }
    }
}