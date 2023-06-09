using Domain;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Repository;

namespace Logic
{
    public class MaterialLogic
    {
        private MaterialRepository _repository;

        private MaterialLogic()
        {
            _repository=new MaterialRepository();
        }

        public static MaterialLogic Instance { get; } = new MaterialLogic();

        public static void Reset()
        {
            Instance._repository = new MaterialRepository();
        }

        public void CreateLambertian(Client proprietary, string name, Color color)
        {
            
            Material materialToAdd = new Lambertian()
            {
                Proprietary = proprietary,
                Name = name,
                Color = color
            };
            materialToAdd.Validate();
            ValidateDuplicateName(proprietary, name);
            _repository.Add(materialToAdd);
        }

        private void ValidateDuplicateName(Client proprietary, string name)
        {
            List<Material> clientMaterials = _repository.GetMaterialsByClient(proprietary);
            Material materialWithSameName = clientMaterials.Find(someMaterial => someMaterial.Name == name);
            if ( materialWithSameName != null)
                throw new DuplicateNameException("There is already a figure with this name");
        }

        

        public Material GetMaterialByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<Material> GetClientMaterials(Client proprietary)
        {
            return _repository.GetMaterialsByClient(proprietary);
        }

        public void DeleteMaterial(Material materialToDelete)
        {
            _repository.Delete(materialToDelete);
        }

        public void CreateMetallic(Metallic testMaterial)
        {
            testMaterial.Validate();
            _repository.Add(testMaterial);
        }


    }
}