namespace TerminalExplorer;


public class HelpCommand : ICommand
{
    public string Name => "help";

    public void Execute(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        Console.WriteLine("help");
        Console.WriteLine("files");
        Console.WriteLine("exit");
        Console.WriteLine();
    }
}