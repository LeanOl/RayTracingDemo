using System;
using Domain;
using Repository;

namespace Logic
{
    public class ModelLogic
    {
        private ModelRepository _modelRepository = new ModelRepository();
        private const string EmptyNameMessage = "Model name should not be empty";
        
        public void CreateModel(string model1, Client proprietary, Figure figure, Material material)
        {
            if (string.IsNullOrWhiteSpace(model1))
            {
                throw new ArgumentException(EmptyNameMessage);
            }
            Model model = new Model()
            {
                Name = model1,
                Proprietary = proprietary,
                Figure = figure,
                Material = material
            };
            _modelRepository.AddModel(model);
        }

        public Model GetModelByName(string model1)
        {
            return _modelRepository.GetModelByName(model1);
        }
    }
}