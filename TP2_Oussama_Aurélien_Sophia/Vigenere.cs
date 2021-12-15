using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Oussama_Aurélien_Sophia
{
    class Vigenere
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            int i = 0;
            bool test = true;
            while (i < key.Length)
            {
                if ((char)(key[i]) > 122 || (char)(key[i]) <= 64 || (((char)(key[i]) > 90) & ((char)(key[i]) < 97)))
                {
                    test=false;
                }
                i += 1;
            }
            if ((test==false) || (string.IsNullOrEmpty(key)))
            {
                throw new ArgumentException("Please enter an alphabetic key");
            }
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ArgumentException("Input cannot be null");
            }
            return toDecrypt ? Decrypt(inputText, key) : Encrypt(inputText, key);
        }

        private static string Encrypt(string inputText, string key)
        {
            string encrypt = "";
            string upperText = inputText.ToUpper();
            string upperKey = key.ToUpper();

            for (int i = 0; i < upperText.Length; i++)
            {
                if ((char)(upperText[i]) > 122 || (char)(upperText[i]) <= 64 || (((char)(upperText[i]) > 90) & ((char)(upperText[i]) < 97)))
                {
                    encrypt += (char)(upperText[i]);
                }
                else 
                    encrypt += (char)((((short)upperKey[i % upperKey.Length] + (short)upperText[i]) % 26) + 65);
            }
            return encrypt;
        }

        private static string Decrypt(string inputText, string key)
        {
            string decrypt = "";
            string upperText = inputText.ToUpper();
            string upperKey = key.ToUpper();

            for (int i = 0; i < upperText.Length; i++)
            {
                if ((char)(upperText[i]) > 122 || (char)(upperText[i]) <= 64 || (((char)(upperText[i]) > 90) & ((char)(upperText[i]) < 97)))
                {
                    decrypt += (char)(upperText[i]);
                }
                else 
                    decrypt += (char)((mod(((short)upperText[i] - (short)(upperKey[i % upperKey.Length])), 26)) + 65);
            }
            return decrypt;
        }

        private static int mod(int k, int n)
        {
            return ((k %= n) < 0) ? k + n : k;
        }
    }
}
