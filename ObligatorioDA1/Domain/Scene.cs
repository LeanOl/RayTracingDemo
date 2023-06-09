using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Domain
{
    public class Scene
    {
        
        public Guid SceneId { get; set; }
        public Image Preview { get; set; }
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PositionedModel> ModelList { get; set; }
        public int CameraFov { get; set; } = -1;
        public Vector CameraLookFrom { get; set; }
        public Vector CameraLookAt { get; set; }
        public double CameraAperture { get; set; } = -1;
        public Camera ActiveCamera { get; set; }
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

        public void UpdateCameraSettings(Vector lookFrom, Vector lookAt, int fov, double aperture)
        {
            ValidateFov(fov);
            ValidateAperture(aperture);
            CameraLookFrom = lookFrom;
            CameraLookAt = lookAt;
            CameraFov = fov;
            CameraAperture = Math.Truncate(aperture*10) / 10;
        }

        private void ValidateAperture(double aperture)
        {
            if (aperture < 0 || aperture > 3)
                throw new System.ArgumentOutOfRangeException("Aperture", "Aperture must be a between 0 and 3");
        }
        private void ValidateFov(int fov)
        {
            if (fov < 1 || fov > 160)
                throw new System.ArgumentOutOfRangeException("FieldOfView", "FOV must be between 1 and 160");
        }

        public void RenderPreviewNoDefocus()
        {
            ActiveCamera = new NoDefocusCamera();

            if (CameraFov != -1)
                ActiveCamera.FieldOfView = CameraFov;
            if (CameraLookFrom != null)
                ActiveCamera.LookFrom = CameraLookFrom;
            if(CameraLookAt != null)
                ActiveCamera.LookAt = CameraLookAt;

            GraphicsEngine graphics = new GraphicsEngine();
            Preview= graphics.RenderScene(this);
        }

        public void RenderPreviewDefocus()
        {
            ActiveCamera = new DefocusCamera();
            if (CameraFov != -1)
                ActiveCamera.FieldOfView = CameraFov;
            if (CameraLookFrom != null)
                ActiveCamera.LookFrom = CameraLookFrom;
            if (CameraLookAt != null)
                ActiveCamera.LookAt = CameraLookAt;
            if (CameraAperture != -1)
                ActiveCamera.Aperture = CameraAperture;
            GraphicsEngine graphics = new GraphicsEngine();
            Preview = graphics.RenderScene(this);
        }

        public void SavePreviewAsJpg(string path)
        {
            Utilities.ImageSaver.SaveImageAsJpg(path, Preview);
        }

        public void SavePreviewAsPng(string path)
        {
            Utilities.ImageSaver.SaveImageAsPng(path, Preview);
        }

        public void SavePreviewAsPpm(string path)
        {
            Utilities.ImageSaver.SaveImageAsPpm(path, Preview);
        }
    }
}

    
