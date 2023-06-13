using Domain;
using Exceptions;
using Repository;
using System.Collections.Generic;

namespace Logic
{
    public class FigureLogic
    {
        private IFigureRepository _repository;

        public FigureLogic()
        {
            _repository = new FigureRepository();
        }

        public FigureLogic(IFigureRepository repository)
        {
            _repository = repository;
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
            _repository.RemoveFigureByName(name, username);
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