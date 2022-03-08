using System;
using System.Collections.Generic;
using System.Net.Sockets;
using org.matheval.Node;

namespace Silan;

class SilanManager
{
    private bool isCommented = false;
    
    public void ThrowError(string message) 
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Beep();
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
        foreach (char character in line.Trim()) {
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

    public void IterateOverLines(string[] lines)
    {

        List<string> words = new List<string>();
        
        // Splits lines in file
        while (Program.LineNumber != lines.Length) {
            words = SplitLines(lines[Program.LineNumber]);

            // Verifies the code is not
            if (!isCommented)
            {
                // Evaluates and runs for each word
                ExecuteLine(words, lines[Program.LineNumber].Trim(), lines);
            } else { // Checks if it is uncommented
                foreach (string word in words) {
                    if (word.Contains("*/"))
                    {
                        isCommented = false;
                    }
                }
            }

            Program.LineNumber++;
            words.Clear();
        }
    }
    
    public void ExecuteLine(List<string> words, string line, string[] lines) {
        switch (words[0]) {
            // Keywords

            case "var":
                Variables variables = new Variables();
                variables.AssignVar(words, line); 
                break;
            
            case "const":
                Constants constants = new Constants();
                constants.AssignConst(words, line);
                break;
            
            case "func":
                break;
            
            case "if":
                If ifObject = new If();
                ifObject.ExecuteIfStatement(words, lines);
                break;
            
            case "else":
                Else:
                If elseObject = new If();
                if (If.ifRan == true) {
                    elseObject.SkipOverElse(lines);
                }
                break;
            case "}": // Runs else if the user typed "} else {"
                try
                {
                    if (words[1] == "else")
                    {
                        goto Else;
                    }
                } catch {}

                break;

            case "while":
                While whileObject = new While();
                whileObject.WhileLoop(words, lines);
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

            // Multi-line comment
            case "/*":
                isCommented = true;
                break;

            default:
                // Functions
                bool funcRan = Functions.CheckFunc(words[0], line);
                
                // Variable Redeclaration (including shorthand operators)
                if (funcRan == false)
                {
                    Variables redeclaration = new Variables();
                    redeclaration.Redeclaration(words, line);
                }
                break;

        }
    }
}