using System.Drawing;
using System.IO;

namespace SIV.Registers.Employees;

public class ImageHelper
{
    public static Image LoadImageFromFile(string filePath)
    {
        return Image.FromFile(filePath);
    }
    
    public static byte[] ConvertImageToByteArray(Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}