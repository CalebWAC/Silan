using System;
using System.Collections.Generic;
using org.matheval;

namespace Silan
{
    class For 
    {
        public static void ForLoop(string[] lines, string line, List<string> words, string word, int lineNumber) {
            if (line.Contains("(var i = ")) {
                int tempLineNumber = lineNumber;
                string increment = words[8];

                switch (words[6]) {
                    case "<": lessThan(lines, line, words, word, increment, lineNumber, tempLineNumber); break;
                    case ">": greaterThan(lines, line, words, word, increment, lineNumber, tempLineNumber); break;
                    case "<=": lessEqual(lines, line, words, word, increment, lineNumber, tempLineNumber); break;
                    case ">=": greaterEqual(lines, line, words, word, increment, lineNumber, tempLineNumber); break;
                }
            }
        }

        public static void lessThan(string[] lines, string line, List<string> words, string word, string increment, int lineNumber, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i++) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i--) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            }
        }

        public static void greaterThan(string[] lines, string line, List<string> words, string word, string increment, int lineNumber, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i++) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i--) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            }
        }

        public static void lessEqual(string[] lines, string line, List<string> words, string word, string increment, int lineNumber, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i++) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i--) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            }
        }

        public static void greaterEqual(string[] lines, string line, List<string> words, string word, string increment, int lineNumber, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i++) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i--) { 
                    while (!lines[lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[lineNumber + 1];

                        // Splits line into words
                        string word2 = "";
                        List<string> wordsL = new List<string>();
                        foreach (char character in lineL) {
                            if (character == ' ') {
                                wordsL.Add(word2);
                                word2 = "";
                            } else if (/*character == ';' || */character == '\n') {
                                wordsL.Add(word2);
                                break;
                            } else if (character != '\t') {
                                word2 += character;
                            }
                        } wordsL.Add(word2);

                        // Evaluate and runs for each word
                        try {
                            foreach (string wordL in wordsL) {
                                Program.Run(wordL, wordsL, lineL.Trim(), lines);
                                lineNumber++;
                            }
                        } catch {}
                        lineNumber = tempLineNumber;
                    }
                } 
            }
        }
    }
}