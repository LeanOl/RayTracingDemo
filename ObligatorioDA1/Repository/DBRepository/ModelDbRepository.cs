using System.Collections.Generic;
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
            _context = new RayTracingContext();
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
            throw new System.NotImplementedException();
        }

        public void DeleteModel(Model testModel)
        {
            throw new System.NotImplementedException();
        }
    }
}