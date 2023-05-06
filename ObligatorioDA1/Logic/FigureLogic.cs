using Domain;
using Repository;
using System;

namespace DomainLogicTest
{
    public class FigureLogic
    {
        private FigureRepository _repository;

        public FigureLogic()
        {
            _repository = new FigureRepository();
        }

        public void CreateFigure(Figure aFigure)
        {
            if (!FigureExists(aFigure.Name))
            {
                _repository.AddFigure(aFigure);
            }
            else
            {
                //Exception (This comment is temporary)
            }
        }

        public bool FigureExists(string name)
        {
            return _repository.FigureExists(name);
        }

        public void CreateSphere()
        {
            throw new NotImplementedException();
        }

        public void RemoveFigure(string name)
        {
            throw new NotImplementedException();
        }
    }
}