using System;
using System.Collections.Generic;
namespace Silan;

public class While
{
    private int ActiveWhiles = 0;
    
    private string[] Lines { get; set; }
    private int TempLineNumber { get; set; }
    private int End { get; set; }
    private SilanManager SilanManager = new SilanManager();

    public void WhileLoop(List<string> words, string[] lines)
    {
        ActiveWhiles++;
        TempLineNumber = Program.LineNumber;
        Lines = lines;
        
        while (Eval.IfEvaluate(words) == 1)
        {
            stack.Push($"while{ActiveWhiles}");
            while (!Lines[Program.LineNumber + 1].Contains("}") && stack.CheckTop($"while{ActiveWhiles}")) {
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
            End = Program.LineNumber;

            if (Lines[Program.LineNumber + 1].Contains("}"))
            {
                Program.LineNumber = TempLineNumber;
            }
        } 
        
        Program.LineNumber = End + 1;
        ActiveWhiles--;
    }
}