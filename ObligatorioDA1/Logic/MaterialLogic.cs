using Domain;
using System;
using System.Drawing;
using Repository;

namespace Logic
{
    public class MaterialLogic
    {
        private MaterialRepository _repository = new MaterialRepository();
        public void CreateLambertian(Client someClient, string name, Color color)
        {
            Material materialToAdd = new Lambertian()
            {
                Owner = someClient,
                Name = name,
                Color = color
            };
            _repository.Add(materialToAdd);
        }

        public Material GetMaterialByName(string name)
        {
            return _repository.GetByName(name);
        }
    }
}