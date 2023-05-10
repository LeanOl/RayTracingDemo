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
            Scene sceneToCompare = obj as Scene;
            if (sceneToCompare == null)
            {
                return false;
            }
            else
            {
                return (Name == sceneToCompare.Name) && (Proprietary.Equals(sceneToCompare.Proprietary));
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Proprietary.GetHashCode();
        }

        public void AddPositionedModel(Model model, Vector position)
        {
            PositionedModel modelToAdd = new PositionedModel { Model = model, Position = position };
            ModelList.Add(modelToAdd);
        }

        public void RemovePositionedModel(PositionedModel model)
        {
            ModelList.Remove(model);
        }

        public void UpdateCameraSettings(Vector lookFrom, Vector lookAt, int fov)
        {
            Camera.LookAt = lookAt;
            Camera.LookFrom = lookFrom;
            Camera.FieldOfView = fov;
        }
    }
}

    
