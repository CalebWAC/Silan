using System;
using System.IO;
using System.Collections.Generic;
using org.matheval;

namespace Silan
{
    class Program
    {      
        public static int lineNumber = 0;
      
        static decimal Evaluate(List<string> words) {
            Expression e = new Expression();
            string toAdd = "";
            int count = 0;
            foreach (string vorto in words) {
                if (count > 3) {
                    toAdd += vorto;
                }
                count++;
            }
            e.SetFomular(toAdd); 
            return (decimal)e.Eval();
        }
        static decimal ReEvaluate(List<string> words) {
            Expression e = new Expression();
            string toAdd = "";
            int count = 0;
            foreach (string vorto in words) {
                if (count > 1) {
                    toAdd += vorto;
                }
                count++;
            }
            e.SetFomular(toAdd); 
            return (decimal)e.Eval();
        }
      
        static void Run(string word, List<string> words, string line, string[] lines, Dictionary<string, string> stringVars, Dictionary<string, int> intVars, Dictionary<string, float> floatVars, Dictionary<string, bool> boolVars, Dictionary<string, char> charVars) {
            if (word == words[0]) {
                            
            switch (word) {
                // Keywords

                case "var":
                    if (words[3] == "=") {
                        if (words[1] == "int" || words[1] == "ent") {
                            intVars.Add(words[2], (int)Evaluate(words));
                        } else if (words[1] == "bool" || words[1] == "buleo") {
                            boolVars.Add(words[2], bool.Parse(words[4]));
                        } else if (words[1] == "float" || words[1] == "floso") {
                            floatVars.Add(words[2], (float)Evaluate(words));
                        } else if (words[1] == "string") {
                            stringVars.Add(words[2], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[2].Length) - 17));
                        } else if (words[1] == "char") {
                            charVars.Add(words[2], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[2].Length) - 15)));
                        } else {
                            Console.WriteLine("ERROR S3: Unrecognized type");
                        }
                    } else {
                        Console.WriteLine("ERROR S1: No '='");
                    }
                    break;

                case "func":
                    break;
                case "if":
                    break;
                case "while":
                    break;
                case "do":
                    break;
                case "switch":
                    break;
                case "for":
                    if (line.Contains("(var i = ")) {
                        //Console.WriteLine(line);
                        //Console.WriteLine(words[7].Substring(0, words[7].Length));
                        for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                            //int n = lineNumber;
                            foreach (string lineF in lines) {
                                string word1 = "";
                                List<string> wordsF = new List<string>();
                                if (line.IndexOf(lineF) > lineNumber) {
                                    Console.WriteLine(lineF);
                                    foreach (char character in lineF) {
                                        if (character == ' ') {
                                            wordsF.Add(word1);
                                            word1 = "";
                                        } else if (/*character == ';' || */character == '\n') {
                                            wordsF.Add(word1);
                                            break;
                                        } else {
                                            word1 += character;
                                        }
                                    }
                                    Run(word1, wordsF, lineF, lines, stringVars, intVars, floatVars, boolVars, charVars);
                                    lineNumber++;
                                } else if (lineF.Contains("}")) {
                                    // Console.WriteLine("I have hit the }");
                                    break;
                                }
                            }
                        }
                      
                        /* int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1));
                        while (i < Int32.Parse(words[7].Substring(0, words[7].Length - 1))) {
                            Console.WriteLine(words[words.IndexOf(word) + 1]);
                            Run(words[words.IndexOf(word) + 1], words, line, lines, stringVars, intVars, floatVars, boolVars, charVars);
                            i++;
                        } */
                    }
                    break;
                case "class":
                    break;
                case "import":
                    break;


                default:

                    // Functions

                    if (word.Contains("print(") || word.Contains("druck(") || word.Contains("presu(")) {
                        if (word[6] == char.Parse("\"")) {
                            Console.WriteLine(line.Substring(7, line.Length - 10));
                        } else {
                            string toPrint = "";
                            try { toPrint = stringVars[line.Substring(6, line.Length - 8)]; } catch {
                            try { toPrint = (boolVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                            try { toPrint = (floatVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {  
                            try { toPrint = (intVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                            try { toPrint = (charVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {  
                            }}}}}
                            Console.WriteLine(toPrint);
                        }
                    } else { 
                        // Variable Redeclaration (including shorthand operators)
                        if (words.Count > 1) {
                            if (words[1] == "=") {
                                if (stringVars.ContainsKey(words[0])) {
                                    stringVars[words[0]] = line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 6);
                                } else if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] = (int)ReEvaluate(words);
                                } else if (boolVars.ContainsKey(words[0])) {
                                    boolVars[words[0]] = bool.Parse(words[2]);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] = (float)ReEvaluate(words);
                                } else if (charVars.ContainsKey(words[0])) {
                                    charVars[words[0]] = char.Parse(words[2].Substring(1, words[2].Length - 2));
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } else if (words[1] == "+=") {
                                if (stringVars.ContainsKey(words[0])) {
                                    stringVars[words[0]] += line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 7
                                                                          );
                                } else if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] += (int)ReEvaluate(words);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] += (float)ReEvaluate(words);
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } else if (words[1] == "-=") {
                                if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] -= (int)ReEvaluate(words);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] -= (float)ReEvaluate(words);
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } else if (words[1] == "*=") {
                                if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] *= (int)ReEvaluate(words);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] *= (float)ReEvaluate(words);
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } else if (words[1] == "/=") {
                                if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] /= (int)ReEvaluate(words);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] /= (float)ReEvaluate(words);
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } else if (words[1] == "%=") {
                                if (intVars.ContainsKey(words[0])) {
                                    intVars[words[0]] %= (int)ReEvaluate(words);
                                } else if (floatVars.ContainsKey(words[0])) {
                                    floatVars[words[0]] %= (float)ReEvaluate(words);
                                } else {
                                    Console.WriteLine("ERROR S2: Variable does not exist");
                                }
                            } 
                        }

                        if (words[0].Contains("++")) {
                            if (intVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                                intVars[words[0].Substring(0, words[0].Length - 2)]++;
                            } else if (floatVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                                floatVars[words[0].Substring(0, words[0].Length - 2)]++;
                            }
                        } else if (words[0].Contains("--")) {
                            if (intVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                                intVars[words[0].Substring(0, words[0].Length - 2)]--;
                            } else if (floatVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                                floatVars[words[0].Substring(0, words[0].Length - 2)]--;
                            }
                        }
                    }
                    break;

            }
            }
            words.Clear();
        }
      
        static void DivideLines(string[] lines, List<string> words) {
            // Variables
            Dictionary<string, string> stringVars = new Dictionary<string, string>();
            Dictionary<string, int> intVars = new Dictionary<string, int>();
            Dictionary<string, float> floatVars = new Dictionary<string, float>();
            Dictionary<string, bool> boolVars = new Dictionary<string, bool>();
            Dictionary<string, char> charVars = new Dictionary<string, char>();
          
            foreach (string line in lines) {
                string word1 = "";
                // String[] words =  line.Split(" ")
                foreach (char character in line) {
                    if (character == ' ') {
                        words.Add(word1);
                        word1 = "";
                    } else if (/*character == ';' || */character == '\n') {
                        words.Add(word1);
                        break;
                    } else {
                        word1 += character;
                    }
                }
                try {
                    foreach (string word in words) {
                        Run(word, words, line, lines, stringVars, intVars, floatVars, boolVars, charVars);
                        lineNumber++;
                    }
                } catch {}
            }
        }
      
        static void Main(string[] args)
        {   
            Save.Clear();
            string location = "";
            try {
                location = args[0];
            } catch {
                Console.WriteLine("ERROR S0: Invalid file location");
                System.Environment.Exit(1);
            }
            
            string[] lines = System.IO.File.ReadAllLines(location);
            List<string> words = new List<string>();
          
            DivideLines(lines, words);
        }
    }
}