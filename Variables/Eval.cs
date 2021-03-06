using System;
using System.Collections.Generic;
using org.matheval;
namespace Silan;

class Eval 
{
    public static decimal Evaluate(List<string> words, bool inferenced) {
        Expression e = new Expression();
        string toAdd = "";
        int count = 0;
        foreach (string vorto in words) {
            if (!inferenced) {
                if (count > 3) {
                    toAdd += vorto;
                }
            } else {
                if (count > 2) {
                    toAdd += vorto;
                }
            }
            count++;
        }
        if (toAdd.Contains(';')) toAdd = toAdd.Substring(0, toAdd.Length - 1);
        e.SetFomular(toAdd);

        CheckToBind(e);
        
        return (decimal)e.Eval();
    }
    
    public static decimal ReEvaluate(List<string> words) {
        Expression e = new Expression();
        string toAdd = "";
        int count = 0;
        foreach (string vorto in words) {
            if (count > 1) {
                toAdd += vorto;
            }
            count++;
        }
        e.SetFomular(toAdd); 
        return e.Eval<Decimal>();
    }
    
    public static decimal IfEvaluate(List<string> words) {
        Expression e = new Expression();
        string toAdd = "IF";
        int count = 0;
        foreach (string vorto in words) {
            if (count > 0 && vorto != "{") {
                toAdd += vorto;
            }
            count++;
        }
        toAdd = toAdd.Substring(0, toAdd.Length - 1);
        toAdd += ", 1 + 0, 0 + 0)";
        e.SetFomular(toAdd);
        
        CheckToBind(e);
        
        return (decimal)e.Eval();
    }

    public static void CheckToBind(Expression e)
    {
        List<string> variables = e.getVariables();
        foreach (string variable in variables)
        {
            try { e.Bind(variable, Variables.intVars[variable]); } catch {
            try { e.Bind(variable, Variables.floatVars[variable]); } catch {
            try { e.Bind(variable, Variables.boolVars[variable]); } catch {
            try { e.Bind(variable, Variables.stringVars[variable]); } catch {
            try { e.Bind(variable, Variables.charVars[variable]); } catch {
            try { e.Bind(variable, Constants.intConsts[variable]); } catch {
            try { e.Bind(variable, Constants.floatConsts[variable]); } catch {
            try { e.Bind(variable, Constants.boolConsts[variable]); } catch {
            try { e.Bind(variable, Constants.stringConsts[variable]); } catch {
            try { e.Bind(variable, Constants.charConsts[variable]); } catch {
                                    
                SilanManager silanManager = new SilanManager();
                silanManager.ThrowError("ERROR S2: Variable does not exist");
            }}}}}}}}}}
        }
    }
}