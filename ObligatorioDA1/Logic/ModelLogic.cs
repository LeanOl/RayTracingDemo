using System;
using System.Collections.Generic;
using Domain;
using Repository;
using Repository.DBRepository;

namespace Logic
{
    public class ModelLogic
    {
        private IModelRepository _modelRepository;
        private const string DuplicateNameMessage = "There is already a model with this name";

        private ModelLogic()
        {
            _modelRepository = new ModelDbRepository();
        }

        public ModelLogic(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public static ModelLogic Instance { get; } = new ModelLogic();

        public static void Reset()
        {
            Instance._modelRepository = new ModelRepository();
        }

        public void CreateModel(string name, Client proprietary, Figure figure, Material material)
        {
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material
            };

            model.Validate();
            ValidateDuplicateName(name, proprietary);

            _modelRepository.AddModel(model);
        }
        public void CreateModelWithPreview(string name, Client proprietary, Figure figure, Material material)
        {
            
            Model model = new Model()
            {
                Name = name,
                Proprietary = proprietary,
                Figure = figure,
                Material = material,
            };

            model.Validate();
            ValidateDuplicateName(name, proprietary);

            model.GeneratePreview();
            _modelRepository.AddModel(model);
        }

        private void ValidateDuplicateName(string name, Client proprietary)
        {
            List<Model> clientModels= _modelRepository.GetClientModels(proprietary);
            bool isNameDuplicated = clientModels.Exists(m => m.Name == name);
            if (isNameDuplicated)
                throw new ArgumentException(DuplicateNameMessage);
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

        public bool IsMaterialUsed(Material materialToDelete)
        {
            return _modelRepository.IsMaterialUsed(materialToDelete);
        }
    }
}