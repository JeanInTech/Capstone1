using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

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
                Console.WriteLine("\nEnter a line to be translated: ");

                string userInput = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter a line to be translated.");
                    continue;
                }
                else
                {
                    string[] words = userInput.ToLower().Split(' ');

                    Console.WriteLine(); //spacing between user input and output

                    foreach (string word in words)
                    {
                        if (word.Any(char.IsLetter) && NoSymbols(word))
                        {
                            char[] lineInput = word.ToCharArray();
                            if (IsAVowel(lineInput[0]))
                            {
                                Console.Write(word + "way" + " ");
                            }
                            else if (word.Any(char.IsDigit))
                            {
                                Console.WriteLine(word + "");
                            }
                            else
                            {
                                Console.Write(PigTranslate(word) + " ");
                            }
                        }
                        else
                        {
                            Console.WriteLine(word);
                        }
                    }

                    while (userContinue)
                    {
                        Console.WriteLine("\n\nTranslate another line? (y/n)");
                        string proceed = Console.ReadLine().Trim();

                        if (proceed == "n")
                        {
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
        public static int VowelAfterConsonantIndex(string line)
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
                else
                {
                    continue;
                }
            }
            return 0;
        }
        public static string PigTranslate(string userInput)
        {
            int i = VowelAfterConsonantIndex(userInput);
            string pigTranslate = userInput.Substring(i) + userInput.Substring(0, i) + "ay";

            return pigTranslate;
        }
        public static bool NoSymbols(string word)
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
        public static string wordCase(string original, string translated)
        {
            /*
            char[] originalArray = original.ToCharArray();
            int i = 0;
            foreach(char letter in originalArray)
            {
                
            }

            string filler = "idk";
            return filler;*/
        }
    }
}

