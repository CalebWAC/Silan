using System;
using System.Collections.Generic;
namespace Silan;

class Variables 
{
    // Variables
    public static Dictionary<string, string> stringVars = new Dictionary<string, string>();
    public static Dictionary<string, int> intVars = new Dictionary<string, int>();
    public static Dictionary<string, float> floatVars = new Dictionary<string, float>();
    public static Dictionary<string, bool> boolVars = new Dictionary<string, bool>();
    public static Dictionary<string, char> charVars = new Dictionary<string, char>();

    private SilanManager SilanManager = new SilanManager();

    public void AssignVar(List<string> words, string line) {
        if (words[3] == "=") {
            if (words[1] == "int" || words[1] == "ent") {
                if (words[4] == "readLine();") {
                    intVars.Add(words[2], Int32.Parse(Console.ReadLine()));
                } else {
                    intVars.Add(words[2], (int)Eval.Evaluate(words, false));
                }
            } else if (words[1] == "bool" || words[1] == "buleo") {
                try { boolVars.Add(words[2], bool.Parse(words[4])); }
                catch { boolVars.Add(words[2], bool.Parse(words[4].Substring(0, words[4].Length - 1))); }
            } else if (words[1] == "float" || words[1] == "floso") {
                floatVars.Add(words[2], (float)Eval.Evaluate(words, false));
            } else if (words[1] == "string") {
                if (words[4] == "readLine();" || words[4] == "readLine()") {
                    stringVars.Add(words[2], Console.ReadLine());
                } else {
                    stringVars.Add(words[2], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[2].Length) - 17));
                }
            } else if (words[1] == "char") {
                charVars.Add(words[2], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[2].Length) - 15)));
            } else {
                SilanManager.ThrowError("ERROR S3: Unrecognized type");
            }
        } else if (words[2] == "=") {
            try { try { boolVars.Add(words[1], bool.Parse(words[3])); }
                  catch { boolVars.Add(words[1], bool.Parse(words[3].Substring(0, words[3].Length - 1))); }} catch {
            try { intVars.Add(words[1], (int)Eval.Evaluate(words, true)); } catch {
            try { floatVars.Add(words[1], (float)Eval.Evaluate(words, true)); } catch {
            try { charVars.Add(words[1], char.Parse(line.Substring(line.IndexOf("'") + 1, (line.Length - words[1].Length) - 11))); } catch {
            try
            {
                if (words[3] == "readLine()" || words[3] == "readLine();")
                {
                    stringVars.Add(words[1], Console.ReadLine());
                }
                else
                {
                    stringVars.Add(words[1], line.Substring(line.IndexOf("\"") + 1, (line.Length - words[1].Length) - 10));
                }
            } catch {
                SilanManager.ThrowError("ERROR S3: Unrecognized type");
            }}}}}
        } else {
            SilanManager.ThrowError("ERROR S1: No '='");
        }
    }

    public void Redeclaration(List<string> words, string line) {
        if (words.Count > 1) {
            if (words[1] == "=") {
                if (stringVars.ContainsKey(words[0])) {
                    if (words[2] == "readLine();" || words[2] == "readLine()") {
                        stringVars[words[0]] = Console.ReadLine();
                    }
                    else {
                        stringVars[words[0]] = line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 6);
                    }
                } else if (intVars.ContainsKey(words[0])) {
                    if (words[2] == "readLine();" || words[2] == "readLine()") {
                        intVars[words[0]] = Int32.Parse(Console.ReadLine());
                    } else {
                        intVars[words[0]] = (int)Eval.ReEvaluate(words);
                    }
                } else if (boolVars.ContainsKey(words[0])) {
                    try { boolVars[words[0]] = bool.Parse(words[2]); }
                    catch { boolVars[words[0]] = bool.Parse(words[2].Substring(0, words[2].Length - 1)); }
                } else if (floatVars.ContainsKey(words[0])) {
                    floatVars[words[0]] = (float)Eval.ReEvaluate(words);
                } else if (charVars.ContainsKey(words[0])) {
                    charVars[words[0]] = char.Parse(words[2].Substring(1, words[2].Length - 2));
                } else {
                    Constants constants = new Constants();
                    bool isConst = constants.Check(words[0]);
                    if (!isConst) {
                        SilanManager.ThrowError("ERROR S2: Variable does not exist");
                    }
                }
            } else if (words[1].Contains('=')) {
                ReassignOps(words, line);
            }
        } else {
            Shorthand(words);
        }
    }

    private void ReassignOps(List<string> words, string line) {
        if (words[1] == "+=") {
            if (stringVars.ContainsKey(words[0])) {
                stringVars[words[0]] += line.Substring(line.IndexOf("\"") + 1, (line.Length - words[0].Length) - 7);
            } else if (intVars.ContainsKey(words[0])) {
                intVars[words[0]] += (int)Eval.ReEvaluate(words);
            } else if (floatVars.ContainsKey(words[0])) {
                floatVars[words[0]] += (float)Eval.ReEvaluate(words);
            } else {
                SilanManager.ThrowError("ERROR S2: Variable does not exist");
            }
        } else if (words[1] == "-=") {
            if (intVars.ContainsKey(words[0])) {
                intVars[words[0]] -= (int)Eval.ReEvaluate(words);
            } else if (floatVars.ContainsKey(words[0])) {
                floatVars[words[0]] -= (float)Eval.ReEvaluate(words);
            } else {
                SilanManager.ThrowError("ERROR S2: Variable does not exist");
            }
        } else if (words[1] == "*=") {
            if (intVars.ContainsKey(words[0])) {
                intVars[words[0]] *= (int)Eval.ReEvaluate(words);
            } else if (floatVars.ContainsKey(words[0])) {
                floatVars[words[0]] *= (float)Eval.ReEvaluate(words);
            } else {
                SilanManager.ThrowError("ERROR S2: Variable does not exist");
            }
        } else if (words[1] == "/=") {
            if (intVars.ContainsKey(words[0])) {
                intVars[words[0]] /= (int)Eval.ReEvaluate(words);
            } else if (floatVars.ContainsKey(words[0])) {
                floatVars[words[0]] /= (float)Eval.ReEvaluate(words);
            } else {
                SilanManager.ThrowError("ERROR S2: Variable does not exist");
            }
        } else if (words[1] == "%=") {
            if (intVars.ContainsKey(words[0])) {
                intVars[words[0]] %= (int)Eval.ReEvaluate(words);
            } else if (floatVars.ContainsKey(words[0])) {
                floatVars[words[0]] %= (float)Eval.ReEvaluate(words);
            } else {
                SilanManager.ThrowError("ERROR S2: Variable does not exist");
            }
        } 
    }

    private void Shorthand(List<string> words) {
        if (words[0].Contains("++")) {
            if (intVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                intVars[words[0].Substring(0, words[0].Length - 2)]++;
            } else if (floatVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                floatVars[words[0].Substring(0, words[0].Length - 2)]++;
            }
        } else if (words[0].Contains("--")) {
            if (intVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                intVars[words[0].Substring(0, words[0].Length - 2)]--;
            } else if (floatVars.ContainsKey(words[0].Substring(0, words[0].Length - 2))) {
                floatVars[words[0].Substring(0, words[0].Length - 2)]--;
            }
        } 
    }
}