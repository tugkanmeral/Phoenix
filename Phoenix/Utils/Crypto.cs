using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Phoenix.Utils
{
    public class Crypto
    {
        /// <summary>
        /// Encrypt the given plain text
        /// </summary>
        /// <param name="plainText">Plain text to encrypt</param>
        /// <param name="key">Secret key</param>
        /// <param name="iv">Initial Vector important: len of IV must be 16</param>
        /// <returns>Returns encrypted text</returns>
        public static string Encrypt(string plainText, string key, string iv)
        {
            return Encrypt(plainText, Hash(key), Encoding.UTF8.GetBytes(iv));
        }

        /// <summary>
        /// Encrypt the given plain text
        /// </summary>
        /// <param name="plainText">Plain text to encrypt</param>
        /// <param name="key">Secret key</param>
        /// <param name="iv">Initial Vector important: len of IV must be 16</param>
        /// <returns>Returns encrypted text</returns>
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            Aes encryptor = Aes.Create();
            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
            return cipherText;
        }

        /// <summary>
        /// Decrypt the given encrypted text
        /// </summary>
        /// <param name="cipherText">Encrypted text</param>
        /// <param name="key">Secret key</param>
        /// <param name="iv">Initial Vector important: len of IV must be 16</param>
        /// <returns>Returns decrypted plain text</returns>
        public static string Decrypt(string cipherText, string key, string iv)
        {
            return Decrypt(cipherText, Hash(key), Encoding.UTF8.GetBytes(iv));
        }
        /// <summary>
        /// Decrypt the given encrypted text
        /// </summary>
        /// <param name="cipherText">Encrypted text</param>
        /// <param name="key">Secret key</param>
        /// <param name="iv">Initial Vector important: len of IV must be 16</param>
        /// <returns>Returns decrypted plain text</returns>
        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            Aes encryptor = Aes.Create();
            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;

            MemoryStream memoryStream = new MemoryStream();
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            string plainText = String.Empty;

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] plainBytes = memoryStream.ToArray();
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            return plainText;
        }

        /// <summary>
        /// Hash given value with SHA256
        /// </summary>
        /// <param name="value">Value that will be hashed</param>
        /// <returns>Hash value</returns>
        public static byte[] Hash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                return bytes;
            }
        }
    }
}
