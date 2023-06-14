using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    public class FigureRepository : IFigureRepository
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

        public Figure GetFigureByNameAndUsername(string name, string username)
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
            _figures.Remove(GetFigureByNameAndUsername(name,username));
        }

        public List<Figure> GetFiguresByClient(Client client)
        {
            return _figures.FindAll(figure => figure.Proprietary.Equals(client));
        }

        private bool figureNameAndUsernameMatch(Figure aFigure, string name, string username)
        {
            string figureClientUsername = aFigure.Proprietary.Username;
            string figureName = aFigure.Name;

            return ((figureName == name) && (figureClientUsername == username));
        }
    }
}
