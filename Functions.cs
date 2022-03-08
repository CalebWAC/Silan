using System;
namespace Silan;

class Functions
{
    private static SilanManager SilanManager = new SilanManager();
    public static bool CheckFunc(string word, string line)
    {
        if (word.Contains("print(")) {
            print(line, word);
            return true;
        } else if (word.Contains("println(")) {
            println(line, word);
            return true;
        } else {
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
}