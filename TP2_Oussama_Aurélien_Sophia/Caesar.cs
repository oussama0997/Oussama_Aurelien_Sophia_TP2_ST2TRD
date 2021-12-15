using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Oussama_Aurélien_Sophia
{
    class Caesar
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            int number;
            bool conversion = int.TryParse(key, out number);
            if (conversion == false)
            {
                throw new ArgumentException("You entered a wrong key, please enter an integer");
            }
            if (string.IsNullOrEmpty(inputText))
            {
                throw new ArgumentException("Input cannot be null");
            }
            return toDecrypt ? Decrypt(inputText, number) : Encrypt(inputText, number);
        }

        private static string Encrypt(string inputText, int key)
        {
            string output = "";
            foreach (char ch in inputText)
                output += cipher(ch, key);
            return output;
        }
        public static char cipher(char ch, int clé)
        {
            char c = Convert.ToChar((int)ch + clé);
            return c;
        }

        private static string Decrypt(string inputText, int key)
        {
            return Encrypt(inputText, -key);
        }
    }
}
