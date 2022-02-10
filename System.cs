using System;
using System.Collections.Generic;

namespace Silan
{
    class SilSystem
    {
        public static void ThrowError(string message) 
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            System.Environment.Exit(1);
        }

        public static void DivideLines(string[] lines, List<string> words) {
            // Splits lines in file
            foreach (string line in lines) {
                if (line == "\n" || line == "") {
                    Program.lineNumber++;
                    continue;
                }

                // Splits line into words
                string tempWord = "";
                foreach (char character in line) {
                    if (character == ' ') {
                        words.Add(tempWord);
                        tempWord = "";
                    } else if (character == '\n') {
                        words.Add(tempWord);
                        break;
                    } else if (character != '\t') {
                        tempWord += character;
                    }
                } words.Add(tempWord);

                List<string> tempWords = new List<string>();
                foreach (string word in words) {
                    tempWords.Add(word);
                }
                foreach (string word in tempWords) {
                    if (word == "") {
                        words.RemoveAt(words.IndexOf(word));
                    }
                }

                // Skips over line if not on that line number
                if (Program.lineNumber != Array.IndexOf(lines, line)) {
                    continue;
                }

                // Evaluate and runs for each word
                try {
                    foreach (string word in words) {
                        Program.Run(word, words, line, lines);
                        Program.lineNumber++;
                    }
                } catch {}
            }
        }
    }
}