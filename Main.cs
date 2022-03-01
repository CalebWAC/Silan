using System.IO;
namespace Silan;

class Program
{      
    public static int lineNumber = 0;

    static void Main(string[] args)
    {
        // Creates a new Silan System object
        SilanManager silanManager = new SilanManager();
        
        // Sets file location to read
        string location = silanManager.SetFileLocation(args[0]);

        // Reads the file and stores it
        string[] lines = File.ReadAllLines(location);
        
        silanManager.DivideLines(lines);
    }
}