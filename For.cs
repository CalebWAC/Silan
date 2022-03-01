using System;
using System.Collections.Generic;
using org.matheval;

namespace Silan
{
    class For 
    {
        public static bool waitOne = false;

        public static void ForLoop(string[] lines, string line, List<string> words, string word) {
            if (line.Contains("(var i = ")) {
                int tempLineNumber = Program.lineNumber;
                int end = Program.lineNumber;
                string increment = words[8];
                Variables.intVars.Add("i", 0);
                switch (words[6]) {
                    case "<":
                        lessThan(lines, line, words, word, increment, tempLineNumber, end); break;
                    case ">": 
                        greaterThan(lines, line, words, word, increment, tempLineNumber); break;
                    case "<=": 
                        lessEqual(lines, line, words, word, increment, tempLineNumber); break;
                    case ">=": 
                        greaterEqual(lines, line, words, word, increment, tempLineNumber); break;
                    default: // DEVERR - DEVeloper ERRor
                        Console.WriteLine("DEVERR: no valid operator"); break;
                }

                waitOne = true;
            }
        }

        public static void lessThan(string[] lines, string line, List<string> words, string word, string increment, int tempLineNumber, int end) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                    stack.Push("for");

                    // while (!lines[Program.lineNumber + 1].Contains("}")) {
                    while (!lines[Program.lineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Variables.intVars["i"]++;
                    stack.Pop();
                    end = Program.lineNumber;
                    Program.lineNumber = tempLineNumber;
                } Program.lineNumber = end + 1;
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            }
        }

        public static void greaterThan(string[] lines, string line, List<string> words, string word, string increment, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            }
        }

        public static void lessEqual(string[] lines, string line, List<string> words, string word, string increment, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            }
        }

        public static void greaterEqual(string[] lines, string line, List<string> words, string word, string increment, int tempLineNumber) {
            if (increment == "i++)") {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            } else {
                for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                    while (!lines[Program.lineNumber + 1].Contains("}")) {
                        // Parses next line in loop
                        string lineL = lines[Program.lineNumber + 1].Trim();

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
                                Program.lineNumber++;
                            }
                        } catch {}
                    }
                    Program.lineNumber = tempLineNumber;
                } 
            }
        }
    }
}