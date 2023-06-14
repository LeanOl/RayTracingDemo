using System.Collections.Generic;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    public interface IMaterialRepository
    {
        void Add(Material someMaterial);
        Material GetByName(string name);
        List<Material> GetMaterialsByClient(Client someClient);
        void Delete(Material materialToDelete);
       

    }
}