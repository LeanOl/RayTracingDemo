using System.Drawing;
using System.IO;

namespace Domain.Utilities
{
    public class ImageSaver
    {
        public static void SaveImageAsJpg(string path, Image image)
        {
            image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static void SaveImageAsPpm(string path, Image image)
        {
            ConvertToPpm(image,path);
        }

        public static void SaveImageAsPng(string path, Image image)
        {
            image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }

        private static void ConvertToPpm(Image image, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write($"P3\n{image.Width} {image.Height}\n255\n");
                Bitmap bmp = new Bitmap(image);
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        writer.Write($"{pixel.R} {pixel.G} {pixel.B} ");
                    }
                    writer.Write("\n");
                }
            }
        }
    }
}