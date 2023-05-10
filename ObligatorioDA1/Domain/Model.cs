using System.Drawing;

namespace Domain
{
    public class Model
    {
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public Figure Figure { get; set; }
        public Material Material { get; set; }
        public Image Preview { get; set; }

        public HitRecord Hit(Ray ray, decimal tMin, decimal tMax, Vector position)
        {
            return Figure.Hit(ray, tMin, tMax, position);
        }

        public Ray Scatter( HitRecord hitRecord)
        {
            return Material.Scatter( hitRecord);
        }

        public Color GetColor()
        {
            return Material.Color;
        }

        public override bool Equals(object obj)
        {
            Model modelToCompare = obj as Model;
            if (modelToCompare == null)
            {
                return false;
            }
            else
            {
                return (Name == modelToCompare.Name) && (Proprietary.Equals(modelToCompare.Proprietary));
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
    
    
}