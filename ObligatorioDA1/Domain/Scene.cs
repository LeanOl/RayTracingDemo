using System;
using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public class Scene
    {
        public Image Preview { get; set; }
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PositionedModel> ModelList { get; set; }
        public Camera Camera { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastRendered { get; set; }

        public override bool Equals(object obj)
        {
            Material materialToCompare = obj as Material;
            if (materialToCompare == null)
            {
                return false;
            }
            else
            {
                return (Name == materialToCompare.Name) && (Proprietary.Equals(materialToCompare.Proprietary));
            }
        }
        public override int GetHashCode()
        {
            return Proprietary.GetHashCode();
        }

        public void AddPositionedModel(Model model, Vector position)
        {
            PositionedModel modelToAdd = new PositionedModel { Model = model, Position = position };
            ModelList.Add(modelToAdd);
        }
    }
}

    
