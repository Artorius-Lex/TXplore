using System;

namespace TerminalExplorer;

public class HelloWorldCommand : ICommand
{
    public string Name => "helloworld";

    public void Execute(string[] args)
    {
        Console.WriteLine("Hello, World! Das ist ein Test-Befehl.");
    }
}
