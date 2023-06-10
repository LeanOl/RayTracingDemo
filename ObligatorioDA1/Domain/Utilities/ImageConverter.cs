using System.Drawing;
using System.IO;

namespace Domain.Utilities
{
    public class ImageConverter
    {
        public static Bitmap PpmToBitmap(string ppm)
        {
            using (var reader = new StringReader(ppm))
            {
                string magicNumber = reader.ReadLine();
                string size = reader.ReadLine();
                string maxColorValue = reader.ReadLine();

                string[] sizeParts = size.Split(' ');
                int width = int.Parse(sizeParts[0]);
                int height = int.Parse(sizeParts[1]);

                Bitmap bitmap = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string pixelColor = reader.ReadLine();
                        string[] pixelColorParts = pixelColor.Split(' ');
                        int r = int.Parse(pixelColorParts[0]);
                        int g = int.Parse(pixelColorParts[1]);
                        int b = int.Parse(pixelColorParts[2]);

                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                return bitmap;
            }
        }
        public static string ConvertToPpm(Image image)
        {
            using (var writer = new StringWriter())
            {
                writer.Write($"P3\n{image.Width} {image.Height}\n255\n");
                Bitmap bmp = new Bitmap(image);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        writer.Write($"{pixel.R} {pixel.G} {pixel.B} ");
                        writer.Write("\n");
                    }
                }

                return writer.ToString();
            }
        

       
        }
    }
}