using System.Security.Cryptography;
using System.Text;

namespace C.Service.Helpers.Security;

public static class Hashing
{
    public static string ToSha256(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            stringBuilder.Append(hash[i].ToString("X2"));
        }

        return stringBuilder.ToString();
    }
}
