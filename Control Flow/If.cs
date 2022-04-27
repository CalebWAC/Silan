using System;
using System.Collections.Generic;
namespace Silan;

public class If
{
    public static bool ifRan = false;
    
    public void ExecuteIfStatement(List<string> words, string[] lines)
    {
        if (Eval.IfEvaluate(words) == 1) {
            ifRan = true;
        } else { 
            int lineN = 0;
            stack.Push("if");
            foreach (string line in lines)
            {
                if (lines[lineN].Contains("}") && stack.CheckTop("if") && lineN > Program.LineNumber)
                {
                    Program.LineNumber = lineN;
                    break;
                }

                lineN++;
            }

            stack.Pop();
        }
    }

    public void SkipOverElse(string[] lines)
    {
        int lineN = 0;
        stack.Push("else");
        foreach (string line in lines)
        {
            if (lines[lineN].Contains("}") && stack.CheckTop("else") && lineN > Program.LineNumber)
            {
                Program.LineNumber = lineN;
                break;
            }

            lineN++;
        }

        stack.Pop();
    }
}