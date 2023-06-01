namespace Domain
{
    public class Lambertian : Material
    {
        public override Ray Scatter(HitRecord hitRecord, Ray ray)
        {
            Vector target = hitRecord.IntersectionPoint.Add(hitRecord.Normal).Add(Vector.RandomInUnitSphere());
            Vector scatterDirection = target.Subtract(hitRecord.IntersectionPoint);
            Ray scatteredRay = new Ray { Origin = hitRecord.IntersectionPoint, Direction = scatterDirection };
            return scatteredRay;
        }
    }
}