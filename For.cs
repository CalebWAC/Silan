using System;
using System.Collections.Generic;
namespace Silan;

class For
{
    private string[] Lines { get; set; }
    private int TempLineNumber { get; set; }

    private int _end;
    private int End
    {
        get
        {
            return this._end;
        }
        set
        {
          //Console.WriteLine("End: " + value);
          _end = value;
        }
    }

    private string Increment { get; set; }
    public SilanManager SilanManager = new SilanManager();

    public void ForLoop(string[] lines, string line, List<string> words) {
        if ((line.Contains("(var ") || line.Contains("var ")) && line.Contains(" = ")) {
            TempLineNumber = Program.LineNumber;
            End = Program.LineNumber;
            Increment = words[8].Substring(1, words[8].Length - 1);
            try { Variables.intVars.Remove(words[2]); } catch {}
            Variables.intVars.Add(words[2], 0);

            Lines = lines;
            
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
        }
    }

    public void lessThan(List<string> words) {
        if (Increment == "++)" || Increment == "++")
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i < Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        }
    }

    public void greaterThan(List<string> words) {
        if (Increment == "++)" || Increment == "++")
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i > Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        }
    }

    public void lessEqual(List<string> words) {
        if (Increment == "++)" || Increment == "++")
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i++) {
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        } else {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1)); i <= Int32.Parse(words[7].Substring(0, words[7].Length - 1)); i--) { 
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for")) {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();
                    
                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }
                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            } 
            Program.LineNumber = End + 1;
        }
    }

    public void greaterEqual(List<string> words)
    {
        if (Increment == "++)" || Increment == "++")
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1));
                 i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1));
                 i++)
            {
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for"))
                {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();

                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }

                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            }

            Program.LineNumber = End + 1;
        }
        else
        {
            for (int i = Int32.Parse(words[4].Substring(0, words[4].Length - 1));
                 i >= Int32.Parse(words[7].Substring(0, words[7].Length - 1));
                 i--)
            {
                stack.Push("for");
                while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop("for"))
                {
                    // Parses next line in loop
                    string lineL = Lines[Program.LineNumber + 1].Trim();

                    // Splits line into words
                    List<string> wordsL = new List<string>();
                    wordsL = SilanManager.SplitLines(lineL.Trim());

                    // Evaluate and runs for each word
                    stack.Pop();

                    Program.LineNumber++;
                    SilanManager.ExecuteLine(wordsL, lineL.Trim(), Lines);
                }

                Variables.intVars[words[2]]++;
                End = Program.LineNumber;
                Program.LineNumber = TempLineNumber;
            }

            Program.LineNumber = End + 1;
        }
    }
}