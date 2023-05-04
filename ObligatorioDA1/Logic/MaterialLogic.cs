using Domain;
using System;
using System.Collections.Generic;
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
        public void CreateLambertian(Client owner, string name, Color color)
        {
            ValidateName(name,owner);
            
            Material materialToAdd = new Lambertian()
            {
                Owner = owner,
                Name = name,
                Color = color
            };
            _repository.Add(materialToAdd);
        }

        private void ValidateDuplicateName(Client owner, string name)
        {
            List<Material> clientMaterials = _repository.GetMaterialsByClient(owner);
            Material materialWithSameName = clientMaterials.Find(someMaterial => someMaterial.Name == name);
            if ( materialWithSameName != null)
                throw new DuplicateNameException("There is already a figure with this name");
        }

        private void ValidateName(string name,Client owner)
        {
            ValidateEmptyName(name);
            ValidateStartsOrEndsWithWhitespace(name);
            ValidateDuplicateName(owner, name);
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