using System.Collections.Generic;
using Domain;

namespace Repository
{
    public interface IModelRepository
    {
        Model GetModelByName(string name);
        void AddModel(Model model);
        List<Model> GetClientModels(Client proprietary);
        void DeleteModel(Model testModel);
        
    }
}