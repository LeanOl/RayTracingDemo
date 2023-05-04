using Domain;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using Repository;

namespace Logic
{
    public class MaterialLogic
    {
        private MaterialRepository _repository = new MaterialRepository();
        private const string FigureNameEmptyMessage = "Figure name should not be empty";
        private const string NameStartsWithWhitespaceMessage = "Figure name should not start or end with whitespaces";
        public void CreateLambertian(Client someClient, string name, Color color)
        {
            ValidateName(name);
            if (_repository.GetMaterialsByClient(someClient).Find(someMaterial => someMaterial.Name == name) != null)
                throw new DuplicateNameException("There is already a figure with this name");
            Material materialToAdd = new Lambertian()
            {
                Owner = someClient,
                Name = name,
                Color = color
            };
            _repository.Add(materialToAdd);
        }

        private void ValidateName(string name)
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

        public Material GetMaterialByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}