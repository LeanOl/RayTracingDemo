using System;
using System.Collections.Generic;
using Domain;
using Exceptions;
using Repository;
using Repository.DBRepository;
using Repository.InMemoryRepository;

namespace Logic
{
    public class ModelLogic
    {
        private IModelRepository _modelRepository;
        private SceneLogic _sceneLogic;
        private const string DuplicateNameMessage = "There is already a model with this name";

        private ModelLogic()
        {
            _modelRepository = new ModelDbRepository();
            _sceneLogic = SceneLogic.Instance;
        }

        public ModelLogic(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public ModelLogic(IModelRepository modelRepository,SceneLogic sceneLogic)
        {
            _modelRepository = modelRepository;
            _sceneLogic = sceneLogic;
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
            if(_sceneLogic.IsModelUsed(getModelByName))
                throw new CannotDeleteException("This model is used by a scene");
            _modelRepository.DeleteModel(getModelByName);
        }

        public bool IsMaterialUsed(Material materialToDelete)
        {
            return _modelRepository.IsMaterialUsed(materialToDelete);
        }

        public bool IsFigureUsed(string name, string username)
        {
            return _modelRepository.IsFigureUsed(name, username);
        }
    }
}