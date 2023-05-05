
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
    }
}
