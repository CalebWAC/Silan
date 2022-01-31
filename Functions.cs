using System;
using System.Collections.Generic;
using org.matheval;

namespace Silan 
{
    class Functions
    {
        public static bool CheckFunc(string word, string line)
        {
            if (word.Contains("print(") || word.Contains("druck(") || word.Contains("presu(")) {
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
                try { toPrint = Variables.stringVars[line.Substring(6, line.Length - 8)]; } catch {
                try { toPrint = (Variables.boolVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                try { toPrint = (Variables.floatVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {  
                try { toPrint = (Variables.intVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {
                try { toPrint = (Variables.charVars[line.Substring(6, line.Length - 8)]).ToString(); } catch {  
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR S2: Variable does not exist");
                Console.ResetColor();
                Environment.Exit(1);}}}}}
                Console.Write(toPrint);
            }
        }

        private static void println(string line, string word)
        {
            if (word[8] == char.Parse("\"")) {
                Console.WriteLine(line.Substring(9, line.Length - 12));
            } else {
                string toPrint = "";
                try { toPrint = Variables.stringVars[line.Substring(8, line.Length - 10)]; } catch {
                try { toPrint = (Variables.boolVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {
                try { toPrint = (Variables.floatVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {  
                try { toPrint = (Variables.intVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {
                try { toPrint = (Variables.charVars[line.Substring(8, line.Length - 10)]).ToString(); } catch {  
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR S2: Variable does not exist");
                Console.ResetColor();
                Environment.Exit(1);}}}}}
                Console.WriteLine(toPrint);
            }
        }
    }
}