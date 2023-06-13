using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;

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
            return _context.Models.FirstOrDefault(model => model.Name == name);
        }

        public void AddModel(Model model)
        {
            _context.Clients.Attach(model.Proprietary);
            _context.Figures.Attach(model.Figure);
            _context.Materials.Attach(model.Material);
            _context.Models.Add(model);
            _context.SaveChanges();
        }

        public List<Model> GetClientModels(Client proprietary)
        {
            return _context.Models.Where(model => model.Proprietary.ClientId == proprietary.ClientId)
                .Include(model=> model.Material)
                .Include(model => model.Figure )
                .ToList();
        }

        public void DeleteModel(Model testModel)
        {
           _context.Models.Remove(testModel);
           _context.SaveChanges();
        }

        public bool IsMaterialUsed(Material materialToDelete)
        {
            return _context.Models.Any(model => model.Material.MaterialId == materialToDelete.MaterialId);
        }
    }
}