using System;
using System.Collections.Generic;
namespace Silan;

class Functions
{
    private static SilanManager SilanManager = new SilanManager();
    private static List<string> UserDefinedFunctions = new List<string>();
    
    public static bool CheckFunc(string word, string line, string[] lines)
    {
        if (word.Contains("print(")) {
            print(line, word);
            return true;
        } else if (word.Contains("println(")) {
            println(line, word);
            return true;
        } 
        
        // Imports
        else if (Game.IsActive) {
            Game game = new Game();
            game.CheckFunc(word, line);
            return true;
        } 
        
        
        // User defined functions
        else {
            foreach (string function in UserDefinedFunctions)
            {
                if (word.Contains(function) || word.Substring(0, word.Length).Contains(function))
                {
                    Functions functionObj = new Functions();
                    functionObj.RunUserDefinedFunction(lines, function);
                }
            }
            return false;
        }
    }

    private static void print(string line, string word) 
    {
        if (word[6] == char.Parse("\"")) {
            Console.Write(line.Substring(7, line.Length - 10));
        } else {
            string toPrint = "";
            // For variables
            try { toPrint = Variables.stringVars[line.Substring(6, line.Length - 8)]; } catch {
            try { toPrint = (Variables.boolVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
            try { toPrint = (Variables.floatVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {  
            try { toPrint = (Variables.intVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
            try { toPrint = (Variables.charVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                
            // For constants
            try { toPrint = Constants.stringConsts[line.Substring(6, line.Length - 8)]; } catch { 
            try { toPrint = (Constants.boolConsts[line.Substring(6, line.Length - 8)]).ToString(); } catch {
            try { toPrint = (Constants.floatConsts[line.Substring(6, line.Length - 8)]).ToString(); } catch {
            try { toPrint = (Constants.intConsts[line.Substring(6, line.Length - 8)]).ToString(); } catch { 
            try { toPrint = (Constants.charConsts[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                
            SilanManager.ThrowError("ERROR S2: Variable does not exist"); }}}}}}}}}}
            Console.Write(toPrint);
        }
    }

    private static void println(string line, string word)
    {
        if (word[8] == char.Parse("\"")) {
            if (!line.Contains("  ")) {
                Console.WriteLine(line.Substring(9, line.Length - 12));
            } else {
                Console.WriteLine(line.Substring(13, line.Length - 16));
            }
        } else {
            string toPrint = "";
            // For variables
            try { toPrint = Variables.stringVars[line.Substring(8, line.Length - 10)]; } catch {
            try { toPrint = (Variables.boolVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {
            try { toPrint = (Variables.floatVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {  
            try { toPrint = (Variables.intVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {
            try { toPrint = (Variables.charVars[line.Trim().Substring(8, line.Length - 10)]).ToString(); } catch {  
            
            // For constants
            try { toPrint = Constants.stringConsts[line.Substring(8, line.Length - 10)]; } catch { 
            try { toPrint = (Constants.boolConsts[line.Substring(8, line.Length - 10)]).ToString(); } catch {
            try { toPrint = (Constants.floatConsts[line.Substring(8, line.Length - 10)]).ToString(); } catch {
            try { toPrint = (Constants.intConsts[line.Substring(8, line.Length - 10)]).ToString(); } catch { 
            try { toPrint = (Constants.charConsts[line.Substring(8, line.Length - 10)]).ToString(); } catch {
           
            SilanManager.ThrowError("ERROR S2: Variable does not exist"); }}}}}}}}}}
            Console.WriteLine(toPrint);
        }
    }

    public void AddNewFunction(string[] lines, List<string> words)
    {
        if (words[1] == "int" || words[1] == "bool" || words[1] == "float" || words[1] == "string" || words[1] == "char") {
            UserDefinedFunctions.Add(words[2].Substring(0, words[2].Length - 2));
        } else {
            UserDefinedFunctions.Add(words[1]);
        }

        SkipOverDeclarationLines(lines);
    }

    public void SkipOverDeclarationLines(string[] lines)
    {
        int lineN = 0;
        stack.Push("func");
        foreach (string line in lines)
        {
            if (lines[lineN].Contains("}") && stack.CheckTop("func") && lineN > Program.LineNumber)
            {
                Program.LineNumber = lineN;
                break;
            }

            lineN++;
        }

        stack.Pop();
    }

    public void RunUserDefinedFunction(string[] lines, string name)
    {
        bool foundIt = false;
        bool inFunc = false;
        
        foreach (string line in lines)
        {
            if (line.Contains(name) && foundIt == false) {
                Program.LineNumber = Array.IndexOf(lines, line);
                foundIt = true;
                inFunc = true;
                stack.Push("func");
            } else if (line.Contains(name) && foundIt && !inFunc) {
                lines[Array.IndexOf(lines, line)] = "// " + line;
                break;
            } else if (line.Contains("}") && stack.CheckTop("func")) {
                inFunc = false;
            } else if (!inFunc) {
                lines[Array.IndexOf(lines, line)] = "// " + line;
            }
        }
    }
}