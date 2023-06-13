using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Domain;

namespace Repository.DBRepository
{
    public class FigureDBRepository : IFigureRepository
    {
        private RayTracingContext _context;

        public FigureDBRepository(RayTracingContext context)
        {
            _context = context;
        }

        public FigureDBRepository()
        {
            _context = RayTracingContext.Instance;
        }

        public void AddFigure(Figure aFigure)
        {
            _context.Clients.Attach(aFigure.Proprietary);
            _context.Figures.Add(aFigure);
            _context.SaveChanges();
        }
        public Figure GetFigureByNameAndUsername(string name, string username)
        {
            return _context.Figures.FirstOrDefault(aFigure => aFigure.Name == name && aFigure.Proprietary.Username == username);
        }
        public bool FigureExists(string name, string username)
        {
            Figure aFigure = _context.Figures.FirstOrDefault(figure => figure.Name == name && figure.Proprietary.Username == username);
         
            if(aFigure == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveFigureByName(string name, string username)
        {
            Figure aFigure = _context.Figures.FirstOrDefault(figure => figure.Name == name && figure.Proprietary.Username == username);
            if (aFigure != null)
            {
                _context.Figures.Remove(aFigure);
                _context.SaveChanges();
            }
        }
        public List<Figure> GetFiguresByClient(Client client)
        {
            return _context.Figures.ToList();
        }
    }
}