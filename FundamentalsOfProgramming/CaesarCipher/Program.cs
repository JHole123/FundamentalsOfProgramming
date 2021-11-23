using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace CaesarCipher
{
    class Program
    {
        static List<char> alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        static Language lang = Language.English;
        static List<string> ValidLanguages = new List<string>(new string[] { "e", "f" });
        static Dictionary<Language, string> CommonWords = new Dictionary<Language, string>();
        static void Main()
        {
            string cryptChoice = TakeInput<string>("Do you want to encrypt or decrypt? (e/d)", x => x == "e" || x == "d");
            int key = 0;
            if (cryptChoice == "e") key = TakeInput<int>("What is your key?", x => x == x); 
            string userDir = TakeInput<string>("What is your file directory?", x => x == x);
            if (cryptChoice == "e")
            {
                string encryptedText = Encrypt(File.ReadAllText(userDir), key);
                Console.WriteLine(encryptedText);
                File.WriteAllText(GetFileDirectory(userDir, cryptChoice), encryptedText);
            }
            if (cryptChoice == "d")
            {
                SetLang(TakeInput<string>("What is the intended language?", x => x.Length == 1 && ValidLanguages.Contains(x)));
                string plainText = BruteForce(File.ReadAllText(userDir));
                Console.WriteLine(plainText);
                File.WriteAllText(GetFileDirectory(userDir, cryptChoice), plainText);
            } 
            Console.WriteLine("Press anything to run again");
            Console.Read();
            Main();
        }

        static string GetFileDirectory(string _dir, string type)
        {
            string suffix = (type == "e") ? "Encrypted" : "Decrypted";
            return _dir.Replace(".txt", $"{suffix}.txt");
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
            List<string> words = new List<string>(File.ReadAllLines(CommonWords[lang]));
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
                Console.Write($"{question}\n");
                userInput = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            } while (!condition(userInput));
            return userInput;
        }

        static void SetupDictionary()
        {
            CommonWords.Add(Language.English, @"M:\Pogramming\FundamentalsOfProgramming\FundamentalsOfProgramming\CaesarCipher\englishCommonWords.txt");

        }

        static void SetLang(string _lang)
        {
            switch (_lang)
            {
                case "e": lang = Language.English; break;
                case "f": lang = Language.French; break;
            }
        }

    }

    enum Language
    {
        English,
        French
    }
}
