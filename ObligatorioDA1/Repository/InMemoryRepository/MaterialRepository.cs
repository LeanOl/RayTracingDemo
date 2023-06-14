using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository.InMemoryRepository
{
    public class MaterialRepository : IMaterialRepository
    {
        private List<Material> Materials { get;} = new List<Material>();
        public void Add(Material someMaterial)
        {
            Materials.Add(someMaterial);
        }

        public Material GetByName(string name)
        {
            return Materials.FirstOrDefault(someMaterial => someMaterial.Name == name);
        }

        public List<Material> GetMaterialsByClient(Client someClient)
        {
            return Materials.FindAll(someMaterial => someMaterial.Proprietary.Equals(someClient));
        }

        public void Delete(Material materialToDelete)
        {
            Materials.Remove(materialToDelete);
        }
    }
}
