using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp.Year2015.Day04;

public static class StringEncoder
{
    public static string MD5Encode(this string str)
    {
        var encodedPassword = new UTF8Encoding().GetBytes(str);
        var cryptoConfig = CryptoConfig.CreateFromName("MD5");

        if (cryptoConfig == null)
            throw new CryptographicException("Can't create Crypto using MD5 string!");

        var hash = ((HashAlgorithm)cryptoConfig).ComputeHash(encodedPassword);
        return BitConverter.ToString(hash)
            .Replace("-", "")
            .ToLower();
    }
}