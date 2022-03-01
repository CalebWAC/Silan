using System;
using System.Collections.Generic;
namespace Silan;

class SilanManager
{
    public void ThrowError(string message) 
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        Environment.Exit(1);
    }

    public string SetFileLocation(string file)
    {
        try {
            return file;
        } catch {
            ThrowError("ERROR S0: Invalid file location");
        }

        return null;
    }

    public List<string> SplitLines(string line)
    {
        List<string> words = new List<string>();
        
        // Splits line into words
        string tempWord = "";
        foreach (char character in line) {
            if (character == ' ') {
                words.Add(tempWord);
                tempWord = "";
            } else if (character == '\n') {
                words.Add(tempWord);
                break;
            } else if (character != '\t') {
                tempWord += character;
            }
        } 
        words.Add(tempWord);

        return words;
    }

    public void DivideLines(string[] lines)
    {

        List<string> words = new List<string>();
        
        // Splits lines in file
        foreach (string line in lines) {
            if (line == "\n" || line == "") {
                Program.lineNumber++;
                continue;
            }

            words = SplitLines(line);

            // Skips over line if not on that line number
            if (Program.lineNumber != Array.IndexOf(lines, line)) {
                continue;
            }

            // Evaluates and runs for each word
            ExecuteLine(words, line, lines);
            Program.lineNumber++;
        }
    }
    
    public void ExecuteLine(List<string> words, string line, string[] lines) {
        switch (words[0]) {
            // Keywords

            case "var":
                Variables variables = new Variables();
                variables.AssignVar(words, line); 
                break;
            
            case "func":
                break;
            
            case "if":
                if (Eval.IfEvaluate(words) == 1) {

                } else {
                    int lineN = 0;
                    stack.Push("if");
                    foreach (string lino in lines) {
                        if (lines[lineN].Contains("}") && stack.CheckTop("if")) {
                            Program.lineNumber = lineN + 1;
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
                For forObject = new For();
                forObject.ForLoop(lines, line, words); 
                break;
                
            case "class":
                break;
            case "import":
                break;


            default:
                // Functions
                bool funcRan = Functions.CheckFunc(words[0], line);
                
                // Variable Redeclaration (including shorthand operators
                if (funcRan == false)
                {
                    Variables redeclaration = new Variables();
                    redeclaration.Redeclaration(words, line);
                }
                break;

        }
        words.Clear();
    }
}