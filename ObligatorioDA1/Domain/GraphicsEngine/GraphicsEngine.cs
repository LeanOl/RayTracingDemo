using System;
using System.Collections.Generic;
using System.Drawing;

namespace Domain.GraphicsEngine
{
    public class GraphicsEngine
    {
        private int _resolution = 300;
        private int _height = 200;
        private int _samplesPerPixel = 50;
        private int _maxDepth = 20;
        private const double AspectRatio = 2d/3d;

        public int Resolution
        {
            get => _resolution;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _resolution = value;
                _height = (int)((double)_resolution * AspectRatio);
            }
        }


        public int SamplesPerPixel
        {
            get => _samplesPerPixel;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _samplesPerPixel = value;
            }
        }

        public int MaxDepth
        {
            get => _maxDepth;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _maxDepth = value;
            }
        }

        public Color ObtainColor(Ray ray, int depth, List<PositionedModel> elements)
        {
            HitRecord hitRecord = null;
            PositionedModel hitModel = null;
            double tMax = double.MaxValue;
            foreach (PositionedModel model in elements)
            {
                HitRecord hit = model.Hit(ray, 0.001, tMax, model.Position);
                if (hit != null)
                {
                    tMax = hit.T;
                    hitRecord = hit;
                    hitModel = model;
                }
            }

            if (hitRecord != null)
            {
                if (depth > 0)
                {
                    Ray scatteredRay = hitModel.Scatter(hitRecord,ray);
                    if(scatteredRay == null)
                    {
                        return Color.FromArgb(0, 0, 0);
                    }
                    Color color = ObtainColor(scatteredRay, depth - 1, elements);
                    Color attenuation = hitModel.GetColor();
                    int red = (int)(((color.R / 255d) * (attenuation.R / 255d)) * 255);
                    int green = (int)(((color.G / 255d) * (attenuation.G / 255d)) * 255);
                    int blue = (int)(((color.B / 255d) * (attenuation.B / 255d)) * 255);
                    return Color.FromArgb(red, green, blue);
                }
                else
                {
                    return Color.FromArgb(0, 0, 0);
                }
            }
            else
            {
                Vector directionUnit = ray.Direction.Unit();
                double posY = 0.5 * (directionUnit.Y + 1);
                Vector colorStart = new Vector { X = 1, Y = 1, Z = 1 };
                Vector colorEnd = new Vector { X = 0.5, Y = 0.7, Z = 1 };
                Vector colorToReturn = colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
                return Color.FromArgb((int)(colorToReturn.X * 255), (int)(colorToReturn.Y * 255),
                    (int)(colorToReturn.Z * 255));

            }

            ;
        }

        public string RenderScene(Scene testScene)
        {
            Bitmap bitmapToReturn = new Bitmap(_resolution, _height);
            Random random = new Random();
            for (int row = _height - 1; row >= 0; row--)
            {
                for (int column = 0; column < _resolution; column++)
                {
                    Vector pixelColor= new Vector{X=0,Y=0,Z=0};
                    for (int sample = 0; sample < _samplesPerPixel; sample++)
                    {
                        double u = (column + random.NextDouble()) / _resolution;
                        double v = (row + random.NextDouble()) / _height;
                        Ray ray = testScene.ActiveCamera.GetRay(u, v);
                        Color obtainedColor = ObtainColor(ray, _maxDepth, testScene.ModelList);
                        pixelColor.AddTo(new Vector
                            { X = obtainedColor.R / 255d, Y = obtainedColor.G / 255d, Z = obtainedColor.B / 255d });
                    }
                    pixelColor=pixelColor.Divide((double)_samplesPerPixel);
                    int red = (int)(pixelColor.X * 255);
                    int green = (int)(pixelColor.Y * 255);
                    int blue = (int)(pixelColor.Z * 255);
                    bitmapToReturn.SetPixel(column, row, Color.FromArgb(red, green, blue));
                    
                }
            }
            bitmapToReturn.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return Utilities.ImageConverter.ConvertToPpm(bitmapToReturn);
        }
        

        public string RenderModel(PositionedModel positionedModel)
        {
            Bitmap bitmapToReturn = new Bitmap(_resolution, _height);
            Vector vectorHorizontal = new Vector { X = 4, Y = 0, Z = 0 };
            Vector vectorVertical = new Vector { X = 0, Y = 2, Z = 0 };
            Vector vectorLowerLeftCorner = new Vector { X = -2, Y = -1, Z = -1 };
            Vector origin= new Vector { X = 0, Y = 0, Z = 0 };

            Random random = new Random();
            for (int row = _height - 1; row >= 0; row--)
            {
                for (int column = 0; column < _resolution; column++)
                {
                    Vector pixelColor = new Vector { X = 0, Y = 0, Z = 0 };
                    for (int sample = 0; sample < _samplesPerPixel; sample++)
                    {
                        double u = (column + random.NextDouble()) / _resolution;
                        double v = (row + random.NextDouble()) / _height;
                       
                        Vector horizontalPosition = vectorHorizontal.Multiply(u);
                        Vector verticalPosition = vectorVertical.Multiply(v);
                        var pointPosition = vectorLowerLeftCorner.Add(horizontalPosition).Add(verticalPosition);
                        Ray ray = new Ray{Origin = origin , Direction = pointPosition};
                        Color obtainedColor = ObtainColor(ray, _maxDepth, positionedModel);
                        pixelColor.AddTo(new Vector
                            { X = obtainedColor.R / 255d, Y = obtainedColor.G / 255d, Z = obtainedColor.B / 255d });
                    }
                    pixelColor = pixelColor.Divide(_samplesPerPixel);
                    int red = (int)(pixelColor.X * 255);
                    int green = (int)(pixelColor.Y * 255);
                    int blue = (int)(pixelColor.Z * 255);
                    bitmapToReturn.SetPixel(column, row, Color.FromArgb(red, green, blue));

                }
            }
            bitmapToReturn.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return Utilities.ImageConverter.ConvertToPpm(bitmapToReturn);
        }

        private Color ObtainColor(Ray ray, int depth, PositionedModel model)
        {
            HitRecord hitRecord = null;
            PositionedModel hitModel = null;
            double tMax = double.MaxValue;
            
            HitRecord hit = model.Hit(ray, 0.001, tMax, model.Position);
            if (hit != null)
            {
                tMax = hit.T;
                hitRecord = hit;
                hitModel = model;
            }
            

            if (hitRecord != null)
            {
                if (depth > 0)
                {
                    Ray scatteredRay = hitModel.Scatter(hitRecord,ray);
                    if(scatteredRay == null)
                        return Color.Black;
                    Color color = ObtainColor(scatteredRay, depth - 1, model);
                    Color attenuation = hitModel.GetColor();
                    int red = (int)(((color.R / 255d) * (attenuation.R / 255d)) * 255);
                    int green = (int)(((color.G / 255d) * (attenuation.G / 255d)) * 255);
                    int blue = (int)(((color.B / 255d) * (attenuation.B / 255d)) * 255);
                    return Color.FromArgb(red, green, blue);
                }
                else
                {
                    return Color.FromArgb(0, 0, 0);
                }
            }
            else
            {
                Vector directionUnit = ray.Direction.Unit();
                double posY = 0.5 * (directionUnit.Y + 1);
                Vector colorStart = new Vector { X = 1, Y = 1, Z = 1 };
                Vector colorEnd = new Vector { X = 0.5, Y = 0.7, Z = 1 };
                Vector colorToReturn = colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
                return Color.FromArgb((int)(colorToReturn.X * 255), (int)(colorToReturn.Y * 255),
                    (int)(colorToReturn.Z * 255));

            }
        }
    }
}