using System;
using System.Collections.Generic;
using Domain;
using Repository;

namespace Logic
{
    public class ModelLogic
    {
        private ModelRepository _modelRepository = new ModelRepository();
        private const string EmptyNameMessage = "Model name should not be empty";
        
        public void CreateModel(string name, Client proprietary, Figure figure, Material material)
        {
            ValidateName(name, proprietary);
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material
            };
            _modelRepository.AddModel(model);
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
                throw new ArgumentException("There is already a model with this name");
        }

        private static void ValidateWhitespaces(string name)
        {
            if (name.StartsWith(" ") || name.EndsWith(" "))
                throw new ArgumentException("Model name should not start or end with whitespaces");
        }

        private static void ValidateEmptyName(string model1)
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
    }
}