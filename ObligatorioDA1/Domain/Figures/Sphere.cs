namespace Domain
{
    public class Sphere : Figure
    {
        public int Radius { get; set; }

        public HitRecord Hit(Ray aRay, int i, int i1, Vector center)
        {
            Vector originCenter = aRay.Origin.Subtract(center);
            decimal a = aRay.Direction.DotProduct(aRay.Direction);
            decimal b = 2 * originCenter.DotProduct(aRay.Direction);
            decimal c = originCenter.DotProduct(originCenter) - Radius * Radius;
            decimal discriminant = b * b - 4 * a * c;
            return new HitRecord();
        }
    }
}