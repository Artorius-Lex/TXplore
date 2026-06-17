using System;
using System.Linq;
using TerminalExplorer;

public class AtlasApp
{
    // --- Notiz: Hier speichern wir unsere Textbefehle (wie "help", "files")
    private readonly CommandRegistry registry = new();
    
    // --- Notiz: Das Dictionary für die Hotkeys. Ordnet einer Taste (ConsoleKey) einen Befehl (string) zu.
    // Später kann das leicht durch eine Konfigurationsdatei vom Benutzer angepasst werden.
    private readonly HotkeyRegistry hotkeys = new();

    public AtlasApp()
    {
        registry.Register(new FilesCommand());
        registry.Register(new HelpCommand());
        registry.Register(new HelloWorldCommand()); // <-- Test-Befehl für das Text-Terminal registriert
        registry.Register(new AllInformationsOfTheDrive());
        registry.Register(new ImportantDriveInfos());
        // --- Notiz: Beispiel-Hotkeys registrieren.
        // H -> Führt den "help" Befehl aus
        // F -> Führt den "files" Befehl aus
        hotkeys.Register(ConsoleKey.H, "help");
        hotkeys.Register(ConsoleKey.F, "files");
        hotkeys.Register(ConsoleKey.Spacebar, "helloworld"); // <-- Test-Befehl für die Leertaste registriert
        
    }

    public void Run()
    {
        Console.WriteLine("ATLAS");
        Console.WriteLine("Drücke Hotkeys für direkte Befehle.");
        Console.WriteLine("Drücke 'T' um den Text-Modus (atlas>) zu starten, 'Escape' zum Beenden.");
        Console.WriteLine();

        while (true)
        {
            // --- Notiz: Das Programm wartet hier auf EINE Taste, ohne sie direkt auf der Konsole auszugeben (durch Parameter 'true').
            var keyInfo = Console.ReadKey(true);

            // Beenden der Schleife und damit des Programms, wenn Escape gedrückt wird
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }

            // --- Notiz: Wenn der Benutzer "t" drückt, wechseln wir in den Text-Modus.
            if (keyInfo.Key == ConsoleKey.T)
            {
                RunTextCommandMode();
                continue;
            }

            // --- Notiz: Wir suchen in unserm Hotkeys-Dictionary nach dem passenden Command-String.
            // Wurde die Taste registriert, führen wir den Befehl über die CommandRegistry aus.
            if (hotkeys.TryGetCommand(keyInfo.Key, out string commandName))
            {
                Console.WriteLine($"[Hotkey {keyInfo.Key}]"); 
                registry.Execute(commandName, Array.Empty<string>());
            }
        }
    }

    private void RunTextCommandMode()
    {
        Console.Write("atlas> ");

        // --- Notiz: Hier wartet das Programm auf ein normales Text Command (das mit ENTER bestätigt wird).
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return;

        string[] parts = input.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries);

        string command = parts[0].ToLower();

        string[] args = parts
            .Skip(1)
            .ToArray();

        registry.Execute(command, args);
        
        // --- Notiz: Nach der Ausführung des Befehls endet diese Methode und die while(true)-Schleife in Run() läuft weiter.
        // Das Programm wartet wieder auf Hotkeys.
    }
}