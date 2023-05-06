using System;
using System.Drawing;

namespace Domain
{
    public abstract class Material
    {
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public override bool Equals(Object obj)
        {
            Material materialToCompare = obj as Material;
            if (materialToCompare == null)
            {
                return false;
            }
            else
            {
                return (Name == materialToCompare.Name) && (Proprietary.Equals(materialToCompare.Proprietary)) ;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}