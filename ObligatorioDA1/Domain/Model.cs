using System;
using System.Drawing;

namespace Domain
{
    public class Model
    {
        public Guid ModelId { get; set; } = Guid.NewGuid();
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public Figure Figure { get; set; }
        public Material Material { get; set; }
        public string Preview { get; set; }

        private const string EmptyNameMessage = "Model name should not be empty";
        private const string NullFigureMessage = "Figure should not be null";
        private const string DulplicateNameMessage = "There is already a model with this name";
        private const string NameEndsOrStartsWhitespaceMessage = "Model name should not start or end with whitespaces";
        private const string NullMaterialMessage = "Material should not be null";

        public HitRecord Hit(Ray ray, decimal tMin, decimal tMax, Vector position)
        {
            return Figure.Hit(ray, tMin, tMax, position);
        }

        public Ray Scatter(HitRecord hitRecord, Ray ray)
        {
            return Material.Scatter( hitRecord,ray);
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

        public void GeneratePreview()
        {
            PositionedModel positionedPreview = new PositionedModel
            {
                Model = new Model()
                {
                    Figure= this.Figure.GeneratePreviewFigure(),
                    Material = this.Material,
                },
                Position = new Vector
                {
                    X = 0,
                    Y = 0,
                    Z = -1
                }
            };
            GraphicsEngine graphics = new GraphicsEngine
            {
                Resolution = 75,
                MaxDepth = 30,
                SamplesPerPixel = 50
            };
            Preview = graphics.RenderModel(positionedPreview);
        }

        public void Validate()
        {
            ValidateName();
            ValidateMaterial();
            ValidateFigure();
        }

        private void ValidateMaterial()
        {
            if (Material == null)
                throw new ArgumentException(NullMaterialMessage);
        }

        private void ValidateFigure()
        {
            if (Figure == null)
                throw new ArgumentException(NullFigureMessage);
        }

        private void ValidateName()
        {
            ValidateEmptyName();
            ValidateWhitespaces();
        }

        private void ValidateWhitespaces()
        {
            if (Name.StartsWith(" ") || Name.EndsWith(" "))
                throw new ArgumentException(NameEndsOrStartsWhitespaceMessage);
        }

        private void ValidateEmptyName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException(EmptyNameMessage);
            }
        }

        public Image GetPreview()
        {
            try
            {
                return Utilities.ImageConverter.PpmToBitmap(Preview);
            }
            catch (ArgumentNullException e)
            {
                return new Bitmap(1,1);
            }
            
        }

    }


}