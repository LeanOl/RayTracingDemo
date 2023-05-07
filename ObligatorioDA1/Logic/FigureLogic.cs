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
            if (ValidFigure(aFigure))
            {
                _repository.AddFigure(aFigure);
            }
        }

        public bool FigureExists(string name)
        {
            return _repository.FigureExists(name);
        }

        public void CreateSphere(Sphere aSphere)
        {
            if (ValidSphere(aSphere))
            {
                CreateFigure(aSphere);
            }
        }

        public void RemoveFigure(string name)
        {
            _repository.RemoveFigureByName(name);
        }

        private bool ValidSphere(Sphere aSphere)
        {
            if(aSphere.Radius > 0)
            {
                return true;
            }
            else
            {
                string invalidRadiusMessage = "Radius must be a positive decimal number";
                throw new ArgumentException(invalidRadiusMessage);
            }
        }

        private bool ValidFigure(Figure aFigure)
        {
            NameNotEmpty(aFigure.Name);
            NameDoesntStartWithNameOrSpaces(aFigure.Name);

            if (_repository.FigureExists(aFigure.Name))
            {
                string figureAlreadyExistsMessage = "A figure with that name already exists";
                throw new ElementAlreadyExistsException(figureAlreadyExistsMessage);
            }
            
            return true;
        }

        private void NameNotEmpty(string name)
        {
            if (name.Length <= 0)
            {
                string invalidEmptyNameMessage = "The name must not be empty";
                throw new ArgumentException(invalidEmptyNameMessage);
            }
        }
            
        private void NameDoesntStartWithNameOrSpaces(string name)
        {
            if (name.StartsWith(" ") || name.EndsWith(" "))
            {
                string invalidNameWithSpacesMessage = "Name must not start or end with spaces";
                throw new ArgumentException(invalidNameWithSpacesMessage);
            }
        }

    }
}