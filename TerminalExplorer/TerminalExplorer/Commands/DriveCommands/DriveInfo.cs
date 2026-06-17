namespace TerminalExplorer;
using System.IO;
using System;

public class ImportantDriveInfos : ICommand
{
    public string Name => "driveinfo";

    public void Execute(string[] args)
    {

        DriveInfo[] allDrives = DriveInfo.GetDrives();
        {
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Ram)
                {
                }
                else {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady)
                {

                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
                
                }
            }


        }
    }

}