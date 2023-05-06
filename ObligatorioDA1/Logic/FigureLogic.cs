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
            FigureRepository _repository = new FigureRepository();
        }

        public void CreateFigure(Figure aFigure)
        {
            throw new NotImplementedException();
        }

        public bool FigureExists(string name)
        {
            throw new NotImplementedException();
        }

    }
}