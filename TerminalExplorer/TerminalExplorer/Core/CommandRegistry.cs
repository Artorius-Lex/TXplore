namespace TerminalExplorer;

public class CommandRegistry
{
    private readonly Dictionary<string, ICommand> commands = new();

    public void Register(ICommand command)
    {
        commands[command.Name] = command;
    }

    public void Execute(string name, string[] args)
    {
        if (commands.TryGetValue(name, out var command))
        {
            command.Execute(args);
        }
        else
        {
            Console.WriteLine($"Unknown command: {name}");
        }
    }
}