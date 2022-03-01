using System.Collections.Generic;
namespace Silan;

class stack {
    private static List<string> stackList = new List<string>();

    public static void Push(string toPush) {
        stackList.Add(toPush);
    }

    public static void Pop() {
        stackList.RemoveAt(stackList.Count - 1);
    }

    public static bool CheckTop(string top) {
        return stackList[^1] == top;
    }
}