using System;
using System.Collections.Generic;
using System.Linq;

namespace Silan;

public class Constants
{
    // Constants
    public static Dictionary<string, string> stringConsts= new Dictionary<string, string>(); 
    public static Dictionary<string, int> intConsts = new Dictionary<string, int>();
    public static Dictionary<string, float> floatConsts = new Dictionary<string, float>();
    public static Dictionary<string, bool> boolConsts = new Dictionary<string, bool>();
    public static Dictionary<string, char> charConsts = new Dictionary<string, char>();
    
    private SilanManager SilanManager = new SilanManager();

    public void AssignConst(List<string> words, string line) {
        if (words[3] == "=") {
            if (words[1] == "int" || words[1] == "ent") {
                if (words[4] == "readLine();") {
                    intConsts.Add(words[2], Int32.Parse(Console.ReadLine()));
                } else {
                    intConsts.Add(words[2], (int)Eval.Evaluate(words, false));
                }
            } else if (words[1] == "bool" || words[1] == "buleo") {
                try { boolConsts.Add(words[2], bool.Parse(words[4])); }
                catch { boolConsts.Add(words[2], bool.Parse(words[4].Substring(0, words[4].Length - 1))); }
            } else if (words[1] == "float" || words[1] == "floso") {
                floatConsts.Add(words[2], (float)Eval.Evaluate(words, false));
            } else if (words[1] == "string") {
                if (words[4] == "readLine();" || words[4] == "readLine()") {
                    stringConsts.Add(words[2], Console.ReadLine());
                } else {
                    stringConsts.Add(words[2], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[2].Length) - 19));
                }
            } else if (words[1] == "char") {
                charConsts.Add(words[2], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[2].Length) - 17)));
            } else {
                SilanManager.ThrowError("ERROR S3: Unrecognized type");
            }
        } else if (words[2] == "=") {
            try { try { boolConsts.Add(words[1], bool.Parse(words[3])); }
                  catch { boolConsts.Add(words[1], bool.Parse(words[3].Substring(0, words[3].Length - 1))); }} catch {
            try { intConsts.Add(words[1], (int)Eval.Evaluate(words, true)); } catch {
            try { floatConsts.Add(words[1], (float)Eval.Evaluate(words, true)); } catch {
            try { charConsts.Add(words[1], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[1].Length) - 11))); } catch {
            try
            {
                if (words[3] == "readLine()" || words[3] == "readLine();")
                {
                    stringConsts.Add(words[1], Console.ReadLine());
                }
                else
                {
                    stringConsts.Add(words[1], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[1].Length) - 10));
                }
            } catch {
                SilanManager.ThrowError("ERROR S3: Unrecognized type");
            }}}}}
        } else {
            SilanManager.ThrowError("ERROR S1: No '='");
        }
    }

    public bool Check(string variable)
    {
        if (stringConsts.Keys.Contains(variable) || intConsts.Keys.Contains(variable) || floatConsts.Keys.Contains(variable) || boolConsts.Keys.Contains(variable) || charConsts.Keys.Contains(variable))
        {
            SilanManager.ThrowError("ERROR S5: Constant cannot be reassigned");
            return true;
        }

        return false;
    }
}