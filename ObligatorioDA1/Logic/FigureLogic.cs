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
            _repository.AddFigure(aFigure);
        }

        public bool FigureExists(string name)
        {
            return _repository.FigureExists(name);
        }

    }
}