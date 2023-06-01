using System;
using System.Drawing;

namespace Domain
{
    public abstract class Material
    {
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        private const string FigureNameEmptyMessage = "Figure name should not be empty";
        private const string NameStartsWithWhitespaceMessage = "Figure name should not start or end with whitespaces";

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

        public abstract Ray Scatter(HitRecord hitRecord, Ray ray);

        public abstract void Validate();

        protected void ValidateName(string name)
        {
            ValidateEmptyName(name);
            ValidateStartsOrEndsWithWhitespace(name);
            
        }

        private void ValidateStartsOrEndsWithWhitespace(string name)
        {
            if (name.StartsWith(" ") || name.EndsWith(" "))
            {

                throw new ArgumentException(NameStartsWithWhitespaceMessage);
            }
        }

        private void ValidateEmptyName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(FigureNameEmptyMessage);
            }
        }
    }
}