using System.Collections.Generic;
using System.Linq;
using Domain;

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
            _context = new RayTracingContext();
        }


        public void Add(Material someMaterial)
        {
            _context.Clients.Attach(someMaterial.Proprietary);
            _context.Materials.Add(someMaterial);
            _context.SaveChanges();
        }

        public Material GetByName(string name)
        {
            return _context.Materials.FirstOrDefault(material => material.Name == name);
        }

        public List<Material> GetMaterialsByClient(Client someClient)
        {
            return _context.Materials.Where(material => material.Proprietary.ClientId == someClient.ClientId).ToList();
        }

        public void Delete(Material materialToDelete)
        {
            _context.Materials.Remove(materialToDelete);
            _context.SaveChanges();
        }
    }
}