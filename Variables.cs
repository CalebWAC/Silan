using System;
using System.Collections.Generic;

namespace Silan 
{
    class Variables 
    {
        // Variables
        public static Dictionary<string, string> stringVars = new Dictionary<string, string>();
        public static Dictionary<string, int> intVars = new Dictionary<string, int>();
        public static Dictionary<string, float> floatVars = new Dictionary<string, float>();
        public static Dictionary<string, bool> boolVars = new Dictionary<string, bool>();
        public static Dictionary<string, char> charVars = new Dictionary<string, char>();

        public static void AssignVar(List<string> words, string line) {
            if (words[3] == "=") {
                if (words[1] == "int" || words[1] == "ent") {
                    intVars.Add(words[2], (int)Eval.Evaluate(words));
                } else if (words[1] == "bool" || words[1] == "buleo") {
                    boolVars.Add(words[2], bool.Parse(words[4]));
                } else if (words[1] == "float" || words[1] == "floso") {
                    floatVars.Add(words[2], (float)Eval.Evaluate(words));
                } else if (words[1] == "string") {
                    if (words[4] == "readLine();") {
                        stringVars.Add(words[2], Console.ReadLine());
                    } else {
                        stringVars.Add(words[2], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[2].Length) - 17));
                    }
                } else if (words[1] == "char") {
                    charVars.Add(words[2], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[2].Length) - 15)));
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S3: Unrecognized type");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR S1: No '='");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }

        public static void Redeclaration(List<string> words, string line) {
            if (words.Count > 1) {
                if (words[1] == "=") {
                    if (stringVars.ContainsKey(words[0])) {
                        stringVars[words[0]] = line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 6);
                    } else if (intVars.ContainsKey(words[0])) {
                        intVars[words[0]] = (int)Eval.ReEvaluate(words);
                    } else if (boolVars.ContainsKey(words[0])) {
                        boolVars[words[0]] = bool.Parse(words[2]);
                    } else if (floatVars.ContainsKey(words[0])) {
                        floatVars[words[0]] = (float)Eval.ReEvaluate(words);
                    } else if (charVars.ContainsKey(words[0])) {
                        charVars[words[0]] = char.Parse(words[2].Substring(1, words[2].Length - 2));
                    } else {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR S2: Variable does not exist");
                        Console.ResetColor();
                        Environment.Exit(1);
                    }
                } else if (words[1].Contains('=')) {
                    ReassignOps(words, line);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S4: Unknown Operation");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else {
                Shorthand(words);
            }
        }

        private static void ReassignOps(List<string> words, string line) {
            if (words[1] == "+=") {
                if (stringVars.ContainsKey(words[0])) {
                    stringVars[words[0]] += line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 7);
                } else if (intVars.ContainsKey(words[0])) {
                    intVars[words[0]] += (int)Eval.ReEvaluate(words);
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] += (float)Eval.ReEvaluate(words);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S2: Variable does not exist");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else if (words[1] == "-=") {
                if (intVars.ContainsKey(words[0])) {
                    intVars[words[0]] -= (int)Eval.ReEvaluate(words);
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] -= (float)Eval.ReEvaluate(words);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S2: Variable does not exist");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else if (words[1] == "*=") {
                if (intVars.ContainsKey(words[0])) {
                    intVars[words[0]] *= (int)Eval.ReEvaluate(words);
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] *= (float)Eval.ReEvaluate(words);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S2: Variable does not exist");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else if (words[1] == "/=") {
                if (intVars.ContainsKey(words[0])) {
                    intVars[words[0]] /= (int)Eval.ReEvaluate(words);
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] /= (float)Eval.ReEvaluate(words);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S2: Variable does not exist");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } else if (words[1] == "%=") {
                if (intVars.ContainsKey(words[0])) {
                    intVars[words[0]] %= (int)Eval.ReEvaluate(words);
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] %= (float)Eval.ReEvaluate(words);
                } else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR S2: Variable does not exist");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            } 
        }

        private static void Shorthand(List<string> words) {
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
            } else {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR S4: Unknown Operation");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }
    }
}