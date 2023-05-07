using Domain;
using Exceptions;
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
            string figureAlreadyExistsMessage = "A figure with that name already exists";
            string invalidNameWithSpacesMessage = "Name must not start or end with spaces";
            string invalidEmptyNameMessage = "The name must not be empty";

            if (!FigureExists(aFigure.Name))
            {
                if(aFigure.Name.Length > 0)
                {
                    if(!aFigure.Name.StartsWith(" ") && !aFigure.Name.StartsWith(" "))
                    {
                        _repository.AddFigure(aFigure);
                    }
                    else
                    {
                        throw new ArgumentException(invalidNameWithSpacesMessage);
                    }
                }
                else
                {
                    throw new ArgumentException(invalidEmptyNameMessage);
                }
            }
            else
            {
                throw new ElementAlreadyExistsException(figureAlreadyExistsMessage);
            }
        }

        public bool FigureExists(string name)
        {
            return _repository.FigureExists(name);
        }

        public void CreateSphere(Sphere aSphere)
        {
            if (aSphere.Radius < 0)
            {
                string invalidRadiusMessage = "Radius must be a positive decimal number";
                throw new ArgumentException(invalidRadiusMessage);
            } 
        }

        public void RemoveFigure(string name)
        {
            _repository.RemoveFigureByName(name);
        }
    }
}