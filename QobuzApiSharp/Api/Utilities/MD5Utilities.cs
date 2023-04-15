using System.Security.Cryptography;
using System.Text;

namespace QobuzApiSharp.Utilities
{
    /// <summary>
    /// MD5 tools helper class.
    /// </summary>
    internal static class MD5Utilities
    {

        /// <summary>
        /// Gets the MD5 hash for an input string.
        /// </summary>
        /// <param name="md5Hash">The MD5 hash algorithm implementation.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <returns>A MD5 hash string.</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}