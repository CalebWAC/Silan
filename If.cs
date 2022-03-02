using System.Collections.Generic;
namespace Silan;

public class If
{
    public void ExecuteIfStatement(List<string> words, string[] lines)
    {
        if (Eval.IfEvaluate(words) == 1) {
            
        } else {
            int lineN = 0;
            stack.Push("if");
            foreach (string lino in lines) {
                if (lines[lineN].Contains("}") && stack.CheckTop("if") && lineN > Program.LineNumber) {
                    Program.LineNumber = lineN;
                    break;
                }
                lineN++;
            }
            stack.Pop();
        }
    }
}