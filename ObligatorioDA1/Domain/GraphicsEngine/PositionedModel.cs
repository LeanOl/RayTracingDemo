using System;
using System.Drawing;

namespace Domain.GraphicsEngine
{
    public class PositionedModel
    {
        public Guid PositionedModelId { get; set; } = Guid.NewGuid();
        public Vector Position { get; set; }
        public Model Model { get; set; }

        public HitRecord Hit(Ray ray, double tMin, double tMax,Vector position)
        {
            return Model.Hit(ray, tMin, tMax, position);
        }
        public Ray Scatter(HitRecord hitRecord, Ray ray)
        {
            return Model.Scatter(hitRecord,ray);
        }

        public Color GetColor()
        {
            return Model.GetColor();
        }
        public override bool Equals(object obj)
        {
            PositionedModel modelToCompare = obj as PositionedModel;
            if (modelToCompare == null)
            {
                return false;
            }
            else
            {
                return Model.Equals(modelToCompare.Model) 
                       && Position.X == modelToCompare.Position.X
                       && Position.Y == modelToCompare.Position.Y
                       && Position.Z == modelToCompare.Position.Z;
                       
            }
        }

        public override int GetHashCode()
        {
            return Model.GetHashCode();
        }

    }
}