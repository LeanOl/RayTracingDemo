using System;
using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public class GraphicsEngine
    {
        private int _resolution = 300;
        private int _samplesPerPixel=50;
        private int _maxDepth=20;

        public int Resolution
        {
            get => _resolution;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _resolution = value;
            }
        }


        public int SamplesPerPixel
        {
            get=>_samplesPerPixel;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException();
                _samplesPerPixel = value;
            }
        }

        public int MaxDepth
        {
            get=>_maxDepth;
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
            decimal tMax = decimal.MaxValue; 
            foreach (PositionedModel model in elements)
            {
                HitRecord hit = model.Hit(ray, 0.001m, tMax, model.Position);
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
                    Ray scatteredRay = hitModel.Scatter(hitRecord);
                    Color color = ObtainColor(scatteredRay, depth - 1, elements);
                    Color attenuation = hitModel.GetColor();
                    int red= (int) (((color.R / 255m) * (attenuation.R / 255m))*255);
                    int green= (int) (((color.G / 255m) * (attenuation.G / 255m))*255);
                    int blue= (int) (((color.B / 255m) * (attenuation.B / 255m))*255);
                    return Color.FromArgb(red,green,blue);
                }
                else
                {
                    return Color.FromArgb(0, 0, 0);
                }
            }
            else
            {
                Vector directionUnit=ray.Direction.Unit();
                decimal posY = 0.5m * (directionUnit.Y + 1);
                Vector colorStart=new Vector { X=1,Y=1,Z=1};
                Vector colorEnd=new Vector { X=0.5m,Y=0.7m,Z=1};
                Vector colorToReturn = colorStart.Multiply(1-posY).Add(colorEnd.Multiply(posY));
                return Color.FromArgb((int)(colorToReturn.X*255),(int)(colorToReturn.Y*255),(int)(colorToReturn.Z*255));
                
            };
        }
    }
}