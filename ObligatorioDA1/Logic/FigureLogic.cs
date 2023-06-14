using Domain.GraphicsEngine;
using Exceptions;
using Repository;
using System.Collections.Generic;
using Domain;
using Repository.DBRepository;
using Repository.InMemoryRepository;

namespace Logic
{
    public class FigureLogic
    {
        private IFigureRepository _repository;
        private ModelLogic _modelLogic = ModelLogic.Instance;

        public FigureLogic()
        {
            _repository = new FigureDBRepository();
        }

        public FigureLogic(IFigureRepository repository, IModelRepository modelRepository)
        {
            _repository = repository;
            _modelLogic = new ModelLogic(modelRepository);
        }

        public static FigureLogic Instance { get; } = new FigureLogic();

        public static void Reset()
        {
            Instance._repository = new FigureRepository();
        }
        
        public void CreateFigure(Figure aFigure)
        {
            if (ValidFigure(aFigure))
            {
                _repository.AddFigure(aFigure);
            }
        }

        public bool FigureExists(string name, string username)
        {
            return _repository.FigureExists(name, username);
        }

        public void RemoveFigure(string name, string username)
        {
            ValidateUsed(name, username);
            _repository.RemoveFigureByName(name, username);
        }

        private void ValidateUsed(string name, string username)
        {
            if (_modelLogic.IsFigureUsed(name, username))
                throw new CannotDeleteException("This figure is used in a model");
        }

        public List<Figure> GetFiguresByClient(Client proprietary)
        {
            return _repository.GetFiguresByClient(proprietary);
        }

        private bool ValidFigure(Figure aFigure)
        {
            aFigure.Validate();

            if (_repository.FigureExists(aFigure.Name, aFigure.Proprietary.Username))
            {
                string figureAlreadyExistsMessage = "A figure with that name already exists";
                throw new ElementAlreadyExistsException(figureAlreadyExistsMessage);
            }
            
            return true;
        }
    }
}