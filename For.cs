using System;
using System.Collections.Generic;
namespace Silan;

class For
{
    // private static int ActiveFors = 0;
    private string[] Lines { get; set; }
    private int TempLineNumber { get; set; }
    private int End { get; set; }
    private string Increment { get; set; }
    public SilanManager SilanManager = new SilanManager();

    public void ForLoop(string[] lines, string line, List<string> words) {
        if (line.Contains("(var ") && line.Contains(" = ")) {
            TempLineNumber = Program.lineNumber;
            End = Program.lineNumber;
            Increment = words[8].Substring(1, words[8].Length - 1);
            Variables.intVars.Add(words[2], 0);

            Lines = lines;
            // ActiveFors++;
            
            switch (words[6]) {
                case "<":
                    lessThan(words); break;
                case ">": 
                    greaterThan(words); break;
                case "<=": 
                    lessEqual(words); break;
                case ">=": 
                    greaterEqual(words); break;
                default: // DEVERR - DEVeloper ERRor
                    Console.WriteLine("DEVERR: no valid operator"); break;
            }

            // ActiveFors--;
        }
    }

    public void lessThan(List<string> words) {
        if (Increment == "++)" || Increment == "++")
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                stack.Push("for");

                // while (!Lines[Program.lineNumber + 1].Contains("}")) {
                while (!Lines[Program.lineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Variables.intVars["i"]++;
                // stack.Pop();
                End = Program.lineNumber;
                Program.lineNumber = TempLineNumber;
            } Program.lineNumber = End + 1;
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Variables.intVars["i"]++;
                stack.Pop();
                End = Program.lineNumber;
                Program.lineNumber = TempLineNumber;
            } Program.lineNumber = End + 1;
        }
    }

    public void greaterThan(List<string> words) {
        if (Increment == "i++)") {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());
                    
                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        }
    }

    public void lessEqual(List<string> words) {
        if (Increment == "i++)") {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        }
    }

    public void greaterEqual(List<string> words) {
        if (Increment == "i++)") {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) { ;
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                while (!Lines[Program.lineNumber + 1].Contains("}")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.lineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                    Program.lineNumber++;
                }
                Program.lineNumber = TempLineNumber;
            } 
        }
    }
}