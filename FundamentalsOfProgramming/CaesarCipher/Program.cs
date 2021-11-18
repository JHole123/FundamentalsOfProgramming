using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace CaesarCipher
{
    class Program
    {
        static List<char> alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        static string dir = @"M:\Pogramming\FundamentalsOfProgramming\FundamentalsOfProgramming\CaesarCipher\commonWords.txt";
        static void Main()
        {
            string cryptChoice = TakeInput<string>("Do you want to encrypt or decrypt? (e/d)", x => x == "e" || x == "d");
            int key = 0;
            if (cryptChoice == "e") /*key = TakeInput<int>("What is your key?", x => x == x) - 1;*/ key = int.Parse(Console.ReadLine());
            string userDir = TakeInput<string>("What is your file directory?", x => x == x);
            if (cryptChoice == "e")
            {
                string encryptedText = Encrypt(File.ReadAllText(userDir), key);
                Console.WriteLine(encryptedText);
                File.WriteAllText(GetFileDirectory(userDir, cryptChoice), encryptedText);
            }
            if (cryptChoice == "d")
            {
                string plainText = BruteForce(File.ReadAllText(userDir));
                Console.WriteLine(plainText);
                File.WriteAllText(GetFileDirectory(userDir, cryptChoice), plainText);
            }
        }

        static string GetFileDirectory(string dir, string type)
        {
            string suffix = (type == "e") ? "Encrypted" : "Decrypted";
            return dir.Replace(".txt", $"{suffix}.txt");

            /*string ParentDirectory = Path.Combine(dir, "..");
            string _OrphanDirectory = dir.Split("\\")[dir.Split("\\").Length - 1];
            string ThornToBePruned = _OrphanDirectory.Substring(_OrphanDirectory.Length - 4, 4);
            string OrphanDirectory = _OrphanDirectory.Replace(ThornToBePruned, "");
            string Suffix = (type == "e") ? "Encrypted" : "Decrypted";
            return $"{ParentDirectory}\\{OrphanDirectory}{Suffix}.txt";*/
        }

        static string Encrypt(string @string, int key)
        {
            while (key < 0)
            {
                key += 26;
            }
            key %= 26;
            @string = @string.ToLower();
            string ciphertext = "";
            foreach (char c in @string)
            {
                if (char.IsLetter(c)) ciphertext += alphabet[(alphabet.IndexOf(c) + key) > 25 ? alphabet.IndexOf(c) + key - 26 : alphabet.IndexOf(c) + key];
                else ciphertext += c;
            }
            return ciphertext;
        }

        static string Decrypt(string @string, int key)
        {
            key *= -1;
            while (key < 0)
            {
                key += 26;
            }
            key %= 26;
            @string = @string.ToLower();
            string plaintext = "";
            foreach (char c in @string)
            {
                if (char.IsLetter(c)) plaintext += alphabet[(alphabet.IndexOf(c) + key) > 25 ? alphabet.IndexOf(c) + key - 26 : alphabet.IndexOf(c) + key];
                else plaintext += c;
            }
            return plaintext;
        }

        static string BruteForce(string @string)
        {
            int attemptedKey = 0;
            while (!IsEnglish(Decrypt(@string, attemptedKey).Split(' ')))
            {
                if (attemptedKey == 27) break;
                attemptedKey++;
            }
            if (attemptedKey == 27) return "Could not be calculated";
            else return Decrypt(@string, attemptedKey);
        }

        static bool IsEnglish(string[] @string)
        {
            List<string> words = new List<string>(File.ReadAllLines(dir));
            int englishWords = 0;
            foreach (string s in @string)
            {
                if (words.Contains(s)) englishWords++;
            }
            if (@string.Length /5 <englishWords) return true;
            return false;
        }

        public static T TakeInput<T>(string question, Func<T, bool> condition)
        {
            T userInput;
            do
            {
                Console.Clear();
                Console.Write($"{question}\n> ");
                string arg = Console.ReadLine().ToLower().Trim();
                userInput = Unsafe.As<string, T>(ref arg);
            } while (!condition(userInput));
            return userInput;
        }

    }
}
