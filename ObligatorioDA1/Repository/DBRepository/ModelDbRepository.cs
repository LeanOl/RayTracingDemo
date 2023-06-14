using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.GraphicsEngine;
using Exceptions;

namespace Repository.DBRepository
{
    public class ModelDbRepository : IModelRepository
    {
        RayTracingContext _context;

        public ModelDbRepository(RayTracingContext context)
        {
            _context = context;
        }

        public ModelDbRepository()
        {
            _context = RayTracingContext.Instance;
        }
        public Model GetModelByName(string name)
        {
            try
            {
                return _context.Models.FirstOrDefault(model => model.Name == name);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
            
        }

        public void AddModel(Model model)
        {
            try
            {
                _context.Clients.Attach(model.Proprietary);
                _context.Figures.Attach(model.Figure);
                _context.Materials.Attach(model.Material);
                _context.Models.Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error",e);
            }


        }

        public List<Model> GetClientModels(Client proprietary)
        {
            try
            {
                return _context.Models.Where(model => model.Proprietary.ClientId == proprietary.ClientId)
                    .Include(model => model.Material)
                    .Include(model => model.Figure)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }

            
        }

        public void DeleteModel(Model testModel)
        {
            try
            {
                _context.Models.Remove(testModel);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
        }

        public bool IsMaterialUsed(Material materialToDelete)
        {
            try
            {
                return _context.Models.Any(model => model.Material.MaterialId == materialToDelete.MaterialId);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
        }

        public bool IsFigureUsed(string name, string username)
        {
            try
            {
                return _context.Models.Any(model =>
                    model.Figure.Name == name 
                    && model.Proprietary.Username == username);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }

        }
    }
}