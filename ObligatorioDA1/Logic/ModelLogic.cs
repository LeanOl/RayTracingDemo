using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Domain;
using Repository;

namespace Logic
{
    public class ModelLogic
    {
        private ModelRepository _modelRepository = new ModelRepository();
        private const string EmptyNameMessage = "Model name should not be empty";
        private const string NullFigureMessage = "Figure should not be null";
        private const string DulplicateNameMessage = "There is already a model with this name";
        private const string NameEndsOrStartsWhitespaceMessage = "Model name should not start or end with whitespaces";
        private const string NullMaterialMessage = "Material should not be null";

        public void CreateModel(string name, Client proprietary, Figure figure, Material material)
        {
            ValidateName(name, proprietary);
            ValidateFigure(figure);
            ValidateMaterial(material);
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material
            };
            _modelRepository.AddModel(model);
        }
        public void CreateModelWithPreview(string name, Client proprietary, Figure figure, Material material)
        {
            ValidateName(name, proprietary);
            ValidateFigure(figure);
            ValidateMaterial(material);
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material,
            };
            model.GeneratePreview();
            _modelRepository.AddModel(model);

        }

        private void ValidateMaterial(Material material)
        {
            if (material == null)
                throw new ArgumentException(NullMaterialMessage);
        }

        private void ValidateFigure(Figure figure)
        {
            if (figure == null)
                throw new ArgumentException(NullFigureMessage);
        }

        private void ValidateName(string name, Client proprietary)
        {
            ValidateEmptyName(name);
            ValidateWhitespaces(name);
            ValidateDuplicateName(name, proprietary);
        }

        private void ValidateDuplicateName(string name, Client proprietary)
        {
            List<Model> clientModels= _modelRepository.GetClientModels(proprietary);
            bool isNameDuplicated = clientModels.Exists(m => m.Name == name);
            if (isNameDuplicated)
                throw new ArgumentException(DulplicateNameMessage);
        }

        private void ValidateWhitespaces(string name)
        {
            if (name.StartsWith(" ") || name.EndsWith(" "))
                throw new ArgumentException(NameEndsOrStartsWhitespaceMessage);
        }

        private void ValidateEmptyName(string model1)
        {
            if (string.IsNullOrWhiteSpace(model1))
            {
                throw new ArgumentException(EmptyNameMessage);
            }
        }

        public Model GetModelByName(string model1)
        {
            return _modelRepository.GetModelByName(model1);
        }


        public List<Model> GetClientModels(Client proprietary)
        {
           return _modelRepository.GetClientModels(proprietary);
        }

        public void DeleteModel(Model getModelByName)
        {
            _modelRepository.DeleteModel(getModelByName);
        }
    }
}