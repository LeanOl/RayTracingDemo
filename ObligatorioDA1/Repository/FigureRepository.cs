
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository
{
    public class FigureRepository
    {
        private List<Figure> _figures { get; set; }

        public FigureRepository()
        {
            _figures = new List<Figure>();
        }
        public void AddFigure(Figure aFigure)
        {
            _figures.Add(aFigure);
        }

        public Figure GetFigureByName(string name)
        {
            return _figures.FirstOrDefault(aFigure => aFigure.Name == name);
        }

        public bool FigureExists(string name, string username)
        {
            foreach (Figure aFigure in _figures)
            {
                if (figureNameAndUsernameMatch(aFigure, name, username))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveFigureByName(string name, string username)
        {
            _figures.Remove(GetFigureByName(name));
        }

        private bool figureNameAndUsernameMatch(Figure aFigure, string name, string username)
        {
            string figureClientUsername = aFigure.Propietary.Username;
            string figureName = aFigure.Name;
            return ((figureName == name) && (figureClientUsername == username));
        }
    }
}
