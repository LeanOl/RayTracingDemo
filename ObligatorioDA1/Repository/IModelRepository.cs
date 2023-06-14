using System.Collections.Generic;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    public interface IModelRepository
    {
        Model GetModelByName(string name);
        void AddModel(Model model);
        List<Model> GetClientModels(Client proprietary);
        void DeleteModel(Model testModel);

        bool IsMaterialUsed(Material materialToDelete);
        bool IsFigureUsed(string name, string username);
    }
}