using System;
using System.Drawing;

namespace Domain
{
    public abstract class Material
    {
        public Client Propietary { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public override bool Equals(Object obj)
        {
            Material materialToCompare = obj as Material;
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Name == materialToCompare.Name;
            }
        }

    }
}