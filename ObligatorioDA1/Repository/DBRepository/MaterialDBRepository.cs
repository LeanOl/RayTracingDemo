using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Exceptions;

namespace Repository.DBRepository
{
    public class MaterialDbRepository : IMaterialRepository
    {
        private RayTracingContext _context;
        public MaterialDbRepository(RayTracingContext context)
        {
            _context = context;
        }

        public MaterialDbRepository()
        {
            _context = RayTracingContext.Instance;
        }


        public void Add(Material someMaterial)
        {
            try
            {
                _context.Clients.Attach(someMaterial.Proprietary);
                _context.Materials.Add(someMaterial);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }

        }

        public Material GetByName(string name)
        {
            try
            {
                return _context.Materials.FirstOrDefault(material => material.Name == name);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
            
        }

        public List<Material> GetMaterialsByClient(Client someClient)
        {
            try
            {
                return _context.Materials.Where(material => 
                        material.Proprietary.ClientId == someClient.ClientId
                        )
                    .ToList();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
        }

        public void Delete(Material materialToDelete)
        {
            try
            {
                _context.Materials.Remove(materialToDelete);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
            
        }
    }
}