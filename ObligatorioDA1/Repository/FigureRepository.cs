
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
                if (aFigure.Name == name && aFigure.Propietary.Username == username)
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

    }
}
