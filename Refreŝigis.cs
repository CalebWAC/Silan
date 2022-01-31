using System;
using System.IO;
using System.Collections.Generic;
using org.matheval;

namespace Silan
{
    class Program
    {      
        public static int lineNumber = 0;
      
        static void Run(string word, List<string> words, string line, string[] lines) {
            if (word == words[0]) {
                
            switch (word) {
                // Keywords

                case "var":
                    Variables.AssignVar(words, line);
                    break;

                case "func":
                    break;

                case "if":
                    if (Eval.IfEvaluate(words) == 1) {
                        
                    } else {
                        int lineN = 0;
                        foreach (string lino in lines) {
                            if (lines[lineN].Contains("}") && lineN > lineNumber) {
                                lineNumber = lineN + 1;
                                break;
                            }
                            lineN++;
                        }
                    }
                    break;

                case "while":
                    break;
                case "do":
                    break;
                case "switch":
                    break;
                    
                case "for":
                    if (line.Contains("(var i = ")) {
                        int tempLineNumber = lineNumber;
                        for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)) - 1; i++) { 
                            while (!lines[lineNumber + 1].Contains("}")) {
                                    // Parses next line in loop
                                    string lineL = lines[lineNumber + 1];
                                    while (lineL[0] == ' ') {
                                        lineL = lineL.Substring(1, lineL.Length - 1);
                                    }

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
                                            Run(wordL, wordsL, lineL, lines);
                                            lineNumber++;
                                        }
                                    } catch {}
                                }
                                lineNumber = tempLineNumber;
                            }
                            
                        } 
                    break;
                    
                case "class":
                    break;
                case "import":
                    break;


                default:

                    // Functions

                    // print()
                    bool funcRan = Functions.CheckFunc(word, line);
                    
                    if (funcRan == false) { 
                        // Variable Redeclaration (including shorthand operators)
                        Variables.Redeclaration(words, line);
                    }
                    break;

            }
            }
            words.Clear();
        }
      
        static void DivideLines(string[] lines, List<string> words) {
            // Splits lines in file
            string line;
            foreach (string lineLoop in lines) {
                // Removes initial tabs
                line = lineLoop;
                if (line != "") {
                    while (line[0] == ' ') {
                        line = line.Substring(1, line.Length - 1);
                    }
                }

                // Splits line into words
                string word1 = "";
                foreach (char character in line) {
                    if (character == ' ') {
                        words.Add(word1);
                        word1 = "";
                    } else if (/*character == ';' || */character == '\n') {
                        words.Add(word1);
                        break;
                    } else if (character != '\t') {
                        word1 += character;
                    }
                } words.Add(word1);

                if (lineNumber != Array.IndexOf(lines, line)) {
                    continue;
                }

                // Evaluate and runs for each word
                try {
                    foreach (string word in words) {
                        // Run(word, words, line, lines, stringVars, intVars, floatVars, boolVars, charVars);
                        //lines[lineNumber] = line;
                        /* Console.Write($"{lines[lineNumber]} ");
                        // Console.WriteLine(lineNumber); */
                        // Run(word, words, lines[lineNumber].Trim(), lines, stringVars, intVars, floatVars, boolVars, charVars);
                        Run(word, words, line, lines);
                        lineNumber++;
                    }
                } catch {}
            }
        }
      
        static void Main(string[] args)
        {
            // Sets file location to read
            string location = "";
            try {
                location = args[0];
            } catch {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR S0: Invalid file location");
                Console.ResetColor();
                System.Environment.Exit(1);
            }
            
            // Reads the file and stores it
            string[] lines = System.IO.File.ReadAllLines(location);
            List<string> words = new List<string>();
          
            DivideLines(lines, words);
        }
    }
}
