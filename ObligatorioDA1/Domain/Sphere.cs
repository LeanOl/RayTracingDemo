using System;
using Domain.GraphicsEngine;

namespace Domain
{
    public class Sphere : Figure
    {
        public double Radius { get; set; }

        private string invalidRadiusMessage = "Radius must be a positive decimal number";
        public override HitRecord Hit(Ray aRay, double tMin, double tMax, Vector center)
        {
            Vector originCenter = aRay.Origin.Subtract(center);
            double a = aRay.Direction.DotProduct(aRay.Direction);
            double b = 2 * originCenter.DotProduct(aRay.Direction);
            double c = originCenter.DotProduct(originCenter) - Radius * Radius;
            double discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                double t = (-b - System.Math.Sqrt(discriminant)) / (2 * a);
                Vector intersectionPoint = aRay.PointAt(t);
                Vector normal = intersectionPoint.Subtract(center).Divide(Radius);
                if (t < tMax && t > tMin)
                {
                    return new HitRecord { T = t, IntersectionPoint = intersectionPoint, Normal = normal };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public override Figure GeneratePreviewFigure()
        {
            return new Sphere { Radius = 0.65 };
        }

        public override void Validate()
        {
            base.Validate();
            if (Radius <= 0)
            {
                throw new ArgumentException(invalidRadiusMessage);
            }
        }
    }
}