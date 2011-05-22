using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace QuanLyHoSoCongChuc
{
    public class Encryption
    {
        // use an 8 byte key for DES encryption
        private static byte[] _key = new byte[]
        {
            0xBA, 0x87, 0x09, 0xDC, 0xFE, 0x65, 0x43, 0x21
        };

        private static byte[] _IV = new byte[]
        {
            0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF
        };

        public string Encrypt(string data)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            // convert input to byte array
            byte[] input = Encoding.UTF8.GetBytes(data);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
            ms,
            des.CreateEncryptor(Encryption._key, Encryption._IV),
            CryptoStreamMode.Write);

            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string data)
        {
            byte[] input = Convert.FromBase64String(data);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(
            ms,
            des.CreateDecryptor(Encryption._key, Encryption._IV),
            CryptoStreamMode.Write);

            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
