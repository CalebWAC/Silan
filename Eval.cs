using System;
using System.Collections.Generic;
using org.matheval;
namespace Silan;

class Eval 
{
    public static decimal Evaluate(List<string> words) {
        Expression e = new Expression();
        string toAdd = "";
        int count = 0;
        foreach (string vorto in words) {
            if (count > 3) {
                toAdd += vorto;
            }
            count++;
        }
        if (toAdd.Contains(';')) toAdd = toAdd.Substring(0, toAdd.Length - 1);
        e.SetFomular(toAdd);
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
        return (decimal)e.Eval();
    }
}