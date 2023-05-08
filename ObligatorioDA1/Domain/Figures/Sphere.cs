namespace Domain
{
    public class Sphere : Figure
    {
        public decimal Radius { get; set; }

        public HitRecord Hit(Ray aRay, decimal tMin, decimal tMax, Vector center)
        {
            Vector originCenter = aRay.Origin.Subtract(center);
            decimal a = aRay.Direction.DotProduct(aRay.Direction);
            decimal b = 2 * originCenter.DotProduct(aRay.Direction);
            decimal c = originCenter.DotProduct(originCenter) - Radius * Radius;
            decimal discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                decimal t = (-b - (decimal)System.Math.Sqrt((double)discriminant)) / (2 * a);
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
    }
}