using System.IO;
namespace Silan;

class Program
{
    public static int LineNumber = 0;
    
    static void Main(string[] args)
    {
        // Creates a new Silan System object
        SilanManager SilanManager = new SilanManager();
        
        // Sets file location to read
        string location = "";
        try
        {
            location = SilanManager.SetFileLocation(args[0]);
        }
        catch
        {
            SilanManager.ThrowError("ERROR S0: Invalid file location");
        }

        // Reads the file and stores it
        string[] lines = File.ReadAllLines(location);
        
        SilanManager.IterateOverLines(lines);
    }
}