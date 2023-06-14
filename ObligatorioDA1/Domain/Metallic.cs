using System;
using Domain.GraphicsEngine;
using Domain.Utilities;

namespace Domain
{
    public class Metallic:Material
    {
        private Random _random = RandomGenerator.RandomInstance;
        public decimal Roughness { get; set; }
        public override Ray Scatter(HitRecord hitRecord, Ray rayIn)
        {
            Ray rayScattered = new Ray
            {
                Origin=new Vector {X=0,Y=0,Z=0}, 
                Direction = new Vector { X=0,Y=0,Z=0}
                    
            };
            Vector reflected = Reflect(rayIn.Direction.Unit(), hitRecord.Normal);
            rayScattered.Origin = hitRecord.IntersectionPoint;
            rayScattered.Direction = reflected.Add(Vector.RandomInUnitSphere(_random).Multiply(Roughness));
            if (rayScattered.Direction.DotProduct(hitRecord.Normal) > 0)
            {
                return rayScattered;
            }
            else
            {
                return null;
            }   
        }

        private Vector Reflect(Vector vectorV, Vector vectorN)
        {
            decimal dotN = vectorN.DotProduct(vectorV);
            return vectorV.Subtract(vectorN.Multiply(2 * dotN));
        }

        public override void Validate()
        {
            ValidateName();
            ValidateRoughness(this);
        }
        private static void ValidateRoughness(Metallic testMaterial)
        {
            if (testMaterial.Roughness < 0)
                throw new ArgumentException("Roughness should be more than 0");
        }
    }
}