﻿using System.Drawing;
using System.IO;

namespace SIV.Core;

/// <summary>
/// A classe oferece funcionalidades para trabalhar com imagens, facilitando o carregamento e a conversão de imagens para arrays de bytes.
/// </summary>
public class ImageHelper
{
    /// <summary>
    /// Carrega uma imagem a partir de um caminho de arquivo especificado.
    /// </summary>
    /// <param name="filePath">O caminho para o arquivo de imagem.</param>
    /// <returns>Retorna um objeto Image carregado do arquivo especificado.</returns>
    public static Image LoadImageFromFile(string filePath)
    {
        return Image.FromFile(filePath);
    }
    
    /// <summary>
    /// Converte um objeto Image em um array de bytes. 
    /// </summary>
    /// <param name="image">A imagem a ser convertida.</param>
    /// <returns>Retorna um array de bytes representando a imagem.</returns>
    public static byte[] ConvertImageToByteArray(Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}