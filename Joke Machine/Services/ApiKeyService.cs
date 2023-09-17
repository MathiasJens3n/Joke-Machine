using System.Security.Cryptography;

namespace Joke_Machine.Services
{
    public class ApiKeyService
    {
        public static byte[] GenerateApiKey()
        {
            return RandomNumberGenerator.GetBytes(256);
        }
    }
}
