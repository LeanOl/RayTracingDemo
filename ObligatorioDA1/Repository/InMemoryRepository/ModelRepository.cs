using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository.InMemoryRepository
{
    public class ModelRepository : IModelRepository
    {
        private List<Model> models=new List<Model>();
        public Model GetModelByName(string name)
        {
            return models.FirstOrDefault(model => model.Name == name);
        }

        public void AddModel(Model model)
        {
            models.Add(model);
        }

        public List<Model> GetClientModels(Client proprietary)
        {
            return models.FindAll(model => model.Proprietary.Equals(proprietary));
        }

        public void DeleteModel(Model testModel)
        {
            models.Remove(testModel);
        }

        public bool IsMaterialUsed(Material materialToDelete)
        {
           return models.Any(model => model.Material.Equals(materialToDelete));
        }

        public bool IsFigureUsed(string name, string username)
        {
            return models.Any(model => model.Figure.Name == name && model.Figure.Proprietary.Username == username);
        }
    }
}