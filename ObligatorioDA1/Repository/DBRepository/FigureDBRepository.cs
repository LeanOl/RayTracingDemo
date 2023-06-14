using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

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
            try
            {
                _context.Clients.Attach(aFigure.Proprietary);
                _context.Figures.Add(aFigure);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
            
        }
        public Figure GetFigureByNameAndUsername(string name, string username)
        {
            try
            {
                return _context.Figures.FirstOrDefault(aFigure => aFigure.Name == name && aFigure.Proprietary.Username == username);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
            
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
            try
            {
                Figure aFigure = _context.Figures.FirstOrDefault(figure => figure.Name == name && figure.Proprietary.Username == username);
                if (aFigure != null)
                {
                    _context.Figures.Remove(aFigure);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
            
        }
        public List<Figure> GetFiguresByClient(Client client)
        {
            try
            {
                return _context.Figures.Where(figure => figure.Proprietary.ClientId == client.ClientId).ToList();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }
        }
    }
}