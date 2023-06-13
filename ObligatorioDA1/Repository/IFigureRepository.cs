using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
