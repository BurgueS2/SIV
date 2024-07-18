using System;
using System.IO;

namespace SIV.Core;

/// <summary>
/// A classe é responsável por registrar exceções em um arquivo de log.
/// Ela fornece uma maneira centralizada de capturar e armazenar detalhes de exceções que ocorrem durante a execução do aplicativo.
/// </summary>
public static class Logger
{
    private static readonly string LogPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

    /// <summary>
    /// Registra uma exceção no arquivo de log. Se o diretório do arquivo de log não existir, ele será criado.
    /// O arquivo de log é nomeado com a data atual para facilitar a organização e a busca por logs específicos.
    /// </summary>
    /// <param name="ex">A exceção capturada que será registrada no arquivo de log.</param>
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