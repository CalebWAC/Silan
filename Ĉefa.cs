using System;
using System.IO;
using System.Collections.Generic;
using org.matheval;

namespace Silan
{
    class Program
    {      
        public static int lineNumber = 0;
      
        public static void Run(string word, List<string> words, string line, string[] lines) {
            if (word == words[0]) {
                
            switch (word) {
                // Keywords

                case "var": Variables.AssignVar(words, line); break;

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
                    
                case "for": For.ForLoop(lines, line, words, word, lineNumber); break;
                    
                case "class":
                    break;
                case "import":
                    break;


                default:

                    // Functions
                    bool funcRan = Functions.CheckFunc(word, line);
                    
                    /*if (funcRan == false) { 
                        // Variable Redeclaration (including shorthand operators)
                        Variables.Redeclaration(words, line);
                    }*/
                    break;

            }
            }
            words.Clear();
        }
      
        static void DivideLines(string[] lines, List<string> words) {
            // Splits lines in file
            foreach (string line in lines) {
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
                        Run(word, words, line.Trim(), lines);
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
