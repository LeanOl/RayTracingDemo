using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository
{
    public class ModelRepository
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
    }
}