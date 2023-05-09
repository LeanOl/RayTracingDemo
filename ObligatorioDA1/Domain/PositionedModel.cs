using System.Drawing;

namespace Domain
{
    public class PositionedModel
    {
        public Vector Position { get; set; }
        public Model Model { get; set; }

        public HitRecord Hit(Ray ray, decimal tMin, decimal tMax,Vector position)
        {
            return Model.Hit(ray, tMin, tMax, position);
        }
        public Ray Scatter(HitRecord hitRecord)
        {
            return Model.Scatter(hitRecord);
        }

        public Color GetColor()
        {
            return Model.GetColor();
        }
    }
}