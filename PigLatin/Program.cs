using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userContinue = true;
            Console.WriteLine("Welcome to the Pig Latin Translator!");


            while (userContinue)
            {
                Console.WriteLine("\nEnter a line to be translated: \n");

                string userInput = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter a line to be translated.");
                    continue;
                }
                else
                {
                    string[] words = userInput.Split(' ');

                    Console.WriteLine(); //spacing between user input and output

                    foreach (string word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            //so spaces between words don't display or break the program
                        }
                        else if

                            (IsUpperCase(word) && word.Any(char.IsLetter) && HasNoSymbols(word))
                        {
                            word.ToLower();
                            char[] lineInput = word.ToCharArray();
                            if (IsAVowel(lineInput[0]))
                            {
                                Console.Write(word + "WAY ");
                            }
                            else
                            {
                                Console.Write(PigTranslate(word).ToUpper() + " ");
                            }
                        }
                        else if (IsTitleCase(word) && word.Any(char.IsLetter) && HasNoSymbols(word))
                        {
                            word.ToLower();
                            char[] lineInput = word.ToCharArray();
                            if (IsAVowel(lineInput[0]))
                            {
                                Console.Write(word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + "way" + " ");
                            }
                            else
                            {
                                string translated = PigTranslate(word);
                                Console.Write(translated.Substring(0, 1).ToUpper() + translated.Substring(1).ToLower() + " ");
                            }
                        }

                        //default is lowercase, if word fails uppercase/titlecase conditions

                        else if (word.Any(char.IsLetter) && HasNoSymbols(word))
                        {
                            word.ToLower();
                            char[] lineInput = word.ToCharArray();
                            if (IsAVowel(lineInput[0]))
                            {
                                Console.Write(word.ToLower() + "way" + " ");
                            }
                            else
                            {
                                Console.Write(PigTranslate(word).ToLower() + " ");
                            }
                        }
                        else
                        {
                            Console.WriteLine(word);
                        }
                    }

                    while (userContinue)
                    {
                        Console.WriteLine("\n\nTranslate another line? (y/n)\n");
                        string proceed = Console.ReadLine().Trim().ToLower();

                        if (proceed == "n")
                        {
                            Console.WriteLine("\nOkay, bye!");
                            userContinue = false;
                        }
                        else if (proceed == "y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            continue;
                        }
                    }
                }
            }
        }

        public static bool IsAVowel(char a)
        {
            if (a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u'
             || a == 'A' || a == 'E' || a == 'I' || a == 'O' || a == 'U')
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static int CheckForConsonantIndex(string line)
        {
            char[] letters = line.ToCharArray();
            int i = -1;
            foreach (char letter in letters)
            {
                i++;
                if (IsAVowel(letter) == true)
                {
                    return i;
                }
            }
            return 0;
        }
        public static string PigTranslate(string userInput)
        {
            userInput.ToLower();
            int i = CheckForConsonantIndex(userInput);
            string pigTranslate = userInput.Substring(i) + userInput.Substring(0, i) + "ay";

            return pigTranslate;
        }
        public static bool HasNoSymbols(string word)
        {
            char at = '@';
            char percentage = '%';
            char hash = '#';
            char carrot = '^';
            char and = '&';
            char star = '*';
            char dollar = ':';

            if (word.Contains(at) || word.Contains(percentage) || word.Contains(hash) || word.Contains(carrot) ||
                word.Contains(and) || word.Contains(star) || word.Contains(dollar))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsUpperCase(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!Char.IsUpper(word[i]))
                    return false;
            }
            return true;
        }
        public static bool IsTitleCase(string word)
        {
            if (Char.IsUpper(word[0]))
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (!Char.IsLower(word[i]))
                        return false;
                }
                return true;

            }
            else
                return false;
        }
    }
}

