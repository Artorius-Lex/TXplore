namespace TerminalExplorer;

public class HotkeyRegistry
{
    private readonly Dictionary<ConsoleKey, string> hotkeys = new();

    public void Register(ConsoleKey key, string command)
    {
        hotkeys[key] = command;
    }

    public bool TryGetCommand(ConsoleKey key, out string command)
    {
        return hotkeys.TryGetValue(key, out command);
    }
}