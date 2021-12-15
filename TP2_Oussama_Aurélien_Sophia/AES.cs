using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace TP2_Oussama_Aurélien_Sophia
{
    class AES
    {
        //Advanced Encryption Standard (AES) 
        public static string Code(string inputText, bool toDecrypt)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ArgumentException("Input cannot be null");
            }
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            static string EncryptAES(string inputText)
            {
                try
                {
                    string ToReturn = "";
                    string publickey = "12345678";
                    string secretkey = "87654321";
                    byte[] secretkeyByte = { };
                    secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(inputText);
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        ToReturn = Convert.ToBase64String(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return $"{EncryptAES(inputText)}";
        }

        private static string Decrypt(string inputText)
        {
            static string DecryptAES(string inputText)
            {
                try
                {
                    string ToReturn = "";
                    string publickey = "12345678";
                    string secretkey = "87654321";
                    byte[] privatekeyByte = { };
                    privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                    byte[] publickeybyte = { };
                    publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                    MemoryStream ms = null;
                    CryptoStream cs = null;
                    byte[] inputbyteArray = new byte[inputText.Replace(" ", "+").Length];
                    inputbyteArray = Convert.FromBase64String(inputText.Replace(" ", "+"));
                    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                    {
                        ms = new MemoryStream();
                        cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                        cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                        cs.FlushFinalBlock();
                        Encoding encoding = Encoding.UTF8;
                        ToReturn = encoding.GetString(ms.ToArray());
                    }
                    return ToReturn;
                }
                catch (Exception ae)
                {
                    throw new Exception(ae.Message, ae.InnerException);
                }
            }

            return $"{DecryptAES(inputText)}";
        }
    }
}
