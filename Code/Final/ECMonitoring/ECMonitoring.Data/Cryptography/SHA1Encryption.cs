using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data.Cryptography
{
    /// <summary>
    /// SHA1 шифрование/дешифрвание чего - нибудь, пока только строки текста.
    /// Шифрование/Дешифрвание пример взят из: 
    /// интернета с сайта: http://msdn.microsoft.com/ru-ru/Library/ms172831.aspx
    /// найдено на яндексе по ссылке 'шифрование vb книга'
    /// </summary>
    public class SHA1Encryption
    {
        // Закрытое поле для хранения поставщика служб шифрования 3DES
        TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
        const string _key = "~1#6J1saD";      // ключ по умолчанию для всех моих программ

        // Конструктор для инициализации поставщика служб шифрования 3DES. 
        // Параметр key управляет методами EncryptData и DecryptData. 
        public SHA1Encryption()
            : this(_key)
        {
        }
        public SHA1Encryption(string key)
        {
            // Initialize the crypto provider.            
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);
        }
        
        byte[] TruncateHash(string key, int length)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            // Hash the key.
            byte[] keyBytes_ = System.Text.Encoding.Unicode.GetBytes(key);
            byte[] hash_ = sha1.ComputeHash(keyBytes_);
            Array.Resize(ref hash_, length);
            return hash_;
        }
        
        /// <summary>
        /// Шифрование строки (может и текста). plain - обычный
        /// </summary>
        public string EncryptData(string plainText)
        {
            // Convert the plaintext plainText to a byte array.
            byte[] plaintextBytes_ = System.Text.Encoding.Unicode.GetBytes(plainText);

            // Create the stream.
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            // Create the encoder to write to the stream.
            CryptoStream encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(),
                CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes_, 0, plaintextBytes_.Length);
            encStream.FlushFinalBlock();

            // Convert the encrypted stream to a printable string.
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Дешифрование строки (может и текста). cipher - шифр
        /// </summary>
        public string DecryptData(string cipherText)
        {
            // Convert the encrypted text string to a byte array.
            byte[] cipherBytes_ = Convert.FromBase64String(cipherText);

            // Create the stream.
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            // Create the decoder to write to the stream.
            CryptoStream decStream = new CryptoStream(ms, TripleDes.CreateDecryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            decStream.Write(cipherBytes_, 0, cipherBytes_.Length);
            decStream.FlushFinalBlock();

            // Convert the plaintext stream to a string.
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}

