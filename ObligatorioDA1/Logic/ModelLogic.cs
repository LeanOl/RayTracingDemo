using System;
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
            ValidateEmptyName(name);
            if (name.StartsWith(" "))
                throw new ArgumentException("Model name should not start or end with whitespaces");
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material
            };
            _modelRepository.AddModel(model);
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