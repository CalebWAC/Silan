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
            if (word == words[0] && word != "}") {
                
            switch (word) {
                // Keywords

                case "var": 
                    Variables.AssignVar(words, line); break;

                case "func":
                    break;

                case "if":
                    if (Eval.IfEvaluate(words) == 1) {

                    } else {
                        int lineN = 0;
                        stack.Push("if");
                        foreach (string lino in lines) {
                            if (lines[lineN].Contains("}") && stack.CheckTop("if")) {
                                lineNumber = lineN + 1;
                                break;
                            }
                            lineN++;
                        }
                        stack.Pop();
                    }
                    break;

                case "while":
                    break;
                case "do":
                    break;
                case "switch":
                    break;
                    
                case "for": 
                    For.ForLoop(lines, line, words, word); break;
                    
                case "class":
                    break;
                case "import":
                    break;


                default:

                    // Functions
                    bool funcRan = Functions.CheckFunc(word, line);
                    
                    // Variable Redeclaration (including shorthand operators
                    if (funcRan == false) {
                        Variables.Redeclaration(words, line);
                    }
                    break;

            }
            }
            words.Clear();
        }
      
        static void Main(string[] args)
        {
            // Sets file location to read
            string location = "";
            try {
                location = args[0];
            } catch {
                SilSystem.ThrowError("ERROR S0: Invalid file location");
            }
            
            // Reads the file and stores it
            string[] lines = System.IO.File.ReadAllLines(location);
            List<string> words = new List<string>();
          
            SilSystem.DivideLines(lines, words);
        }
    }
}
