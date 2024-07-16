using System;
using System.IO;

namespace SIV;

public static class Logger
{
    private static readonly string LogPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

    public static void LogException(Exception ex)
    {
        if (!Directory.Exists(LogPath))
        {
            Directory.CreateDirectory(LogPath);
        }

        string filePath = Path.Combine(LogPath, $"Log_{DateTime.Now:yyyyMMDD}.txt");

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine("-----------------------------------------------------------------------------");
            sw.WriteLine($"Date: {DateTime.Now}");
            sw.WriteLine();

            while (ex != null)
            {
                sw.WriteLine(ex.GetType().FullName);
                sw.WriteLine($"Message: {ex.Message}");
                sw.WriteLine($"StackTrace: {ex.StackTrace}");
                
                ex = ex.InnerException;
            }
        }
    }
}