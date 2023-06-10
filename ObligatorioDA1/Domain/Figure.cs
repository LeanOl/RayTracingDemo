using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public abstract class Figure
    {
        
        public Guid FigureId { get; set; }
        public virtual Client Proprietary { get; set; }
        public string Name { get; set; }

        public abstract HitRecord Hit(Ray aRay, decimal tMin, decimal tMax, Vector center);

        public abstract Figure GeneratePreviewFigure();

        public virtual void Validate()
        {
            NameNotEmpty();
            NameDoesntStartWithNameOrSpaces();
        }

        private void NameNotEmpty()
        {
            if (Name.Length <= 0)
            {
                string invalidEmptyNameMessage = "The name must not be empty";
                throw new ArgumentException(invalidEmptyNameMessage);
            }
        }
        private void NameDoesntStartWithNameOrSpaces()
        {
            if (Name.StartsWith(" ") || Name.EndsWith(" "))
            {
                string invalidNameWithSpacesMessage = "Name must not start or end with spaces";
                throw new ArgumentException(invalidNameWithSpacesMessage);
            }
        }
    }
}