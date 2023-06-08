using System;
using Domain.Utilities;

namespace Domain
{
    public class Lambertian : Material
    {
        private Random _random = RandomGenerator.RandomInstance;
        public override Ray Scatter(HitRecord hitRecord, Ray ray)
        {
            Vector target = hitRecord.IntersectionPoint.Add(hitRecord.Normal).Add(Vector.RandomInUnitSphere(_random));
            Vector scatterDirection = target.Subtract(hitRecord.IntersectionPoint);
            Ray scatteredRay = new Ray { Origin = hitRecord.IntersectionPoint, Direction = scatterDirection };
            return scatteredRay;
        }

        public override void Validate()
        {
            ValidateName(this.Name);
        }
    }
}