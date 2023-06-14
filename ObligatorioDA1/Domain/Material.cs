using System;
using System.Drawing;
using Domain.GraphicsEngine;

namespace Domain
{
    public abstract class Material
    {
        public Guid MaterialId { get; set; } = Guid.NewGuid();
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public virtual Client Proprietary { get; set; } 
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Color Color
        {
            get => Color.FromArgb(ColorR, ColorG, ColorB);
            set
            {
                ColorR = value.R;
                ColorG = value.G;
                ColorB = value.B;
            }
        }


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

        protected void ValidateName()
        {
            ValidateEmptyName();
            ValidateStartsOrEndsWithWhitespace();
        }

        private void ValidateStartsOrEndsWithWhitespace()
        {
            if (Name.StartsWith(" ") || Name.EndsWith(" "))
            {

                throw new ArgumentException(NameStartsWithWhitespaceMessage);
            }
        }

        private void ValidateEmptyName()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException(FigureNameEmptyMessage);
            }
        }
    }
}