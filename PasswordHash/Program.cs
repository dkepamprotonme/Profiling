using System.Security.Cryptography;
using System.Text;
namespace PasswordHash
{
    public class Program
    {
        private static void Main()
        {
            Span<byte> span = stackalloc byte[36];
            Encoding.UTF8.GetBytes("saltsaltsaltsalt", span);
            ReadOnlySpan<char> passwordText = "password".AsSpan();
            var iterate = 10000;
            Rfc2898DeriveBytes.Pbkdf2(passwordText, span[..16], span.Slice(16, 20), iterate, HashAlgorithmName.SHA1);
            var passwordHash = Convert.ToBase64String(span);
            Console.WriteLine(passwordHash);
        }
    }
}