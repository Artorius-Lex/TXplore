namespace TerminalExplorer;

public class FilesCommand : ICommand
{
    public string Name => "files";

    public void Execute(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();

        Console.WriteLine();
        Console.WriteLine(currentDirectory);
        Console.WriteLine();

        foreach (string directory in Directory.GetDirectories(currentDirectory))
        {
            Console.WriteLine("[DIR]  " + Path.GetFileName(directory));
        }

        foreach (string file in Directory.GetFiles(currentDirectory))
        {
            Console.WriteLine("[FILE] " + Path.GetFileName(file));
        }

        Console.WriteLine();
    }
}