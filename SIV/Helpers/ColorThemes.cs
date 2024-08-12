using System.Collections.Generic;
using System.Drawing;

namespace SIV.Helpers;

public abstract class ColorThemes
{
    public static Color PrimaryColor { get; set; }
    
    public static readonly List<string> ColorList =
    [
        "#C4EEF2",
        "#B0D5D9",
        "#8BD9D9"
    ];

    public static Color ChangeBrightness(Color color, double correctionFactor)
    {
        double red = color.R;
        double green = color.G;
        double blue = color.B;

        if (correctionFactor < 0) // Diminui a luminosidade
        {
            correctionFactor = 1 + correctionFactor;
            red *= correctionFactor;
            green *= correctionFactor;
            blue *= correctionFactor;
        }
        else // Aumenta a luminosidade
        {
            red = (255 - red) * correctionFactor + red;
            green = (255 - green) * correctionFactor + green;
            blue = (255 - blue) * correctionFactor + blue;
        }
        
        return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
    }
}