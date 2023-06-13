using Domain;
using System.Collections.Generic;


namespace Repository
{
    public interface IFigureRepository
    {
        void AddFigure(Figure aFigure);
        Figure GetFigureByNameAndUsername(string name, string username);
        bool FigureExists(string name, string username);
        void RemoveFigureByName(string name, string username);
        List<Figure> GetFiguresByClient(Client client);
    }
}