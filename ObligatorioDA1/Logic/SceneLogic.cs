using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Domain;
using Repository;

namespace Logic
{
    public class SceneLogic
    {
        private SceneRepository _repository = new SceneRepository();
        public void CreateEmptyScene(Client proprietary)
        {
            Scene emptyScene;
            Camera sceneCamera = new Camera();
            Bitmap defaultPreview = new Bitmap(300, 200);
            Graphics gfx = Graphics.FromImage(defaultPreview);
            gfx.Clear(Color.Gray);
            string sceneDefaultName= GenerateSceneDefaultName(proprietary);
            

            emptyScene = new Scene
            {
                Name = sceneDefaultName,
                Proprietary = proprietary,
                Camera = sceneCamera,
                CreationDate = System.DateTime.Now,
                LastModified = System.DateTime.Now,
                LastRendered = System.DateTime.Now,
                ModelList = new List<PositionedModel>(),
                Preview = defaultPreview
            };
            _repository.Add(emptyScene);
            
        }

        private string GenerateSceneDefaultName(Client proprietary)
        {
            string sceneDefaultName = "Empty Scene";
            if (_repository.GetByName(sceneDefaultName,proprietary) != null)
            {
                int i = 1;
                while (_repository.GetByName(sceneDefaultName + " " + i) != null)
                {
                    i++;
                }
                sceneDefaultName = sceneDefaultName + " " + i;
            }

            return sceneDefaultName;
        }

        public Scene GetSceneByName(string emptyScene)
        {
            return _repository.GetByName(emptyScene);
        }

        public List<Scene> GetClientScenes(Client proprietary)
        {
            return _repository.GetScenesByClient(proprietary);
        }

        public void AddModelToScene(Scene testScene, Model testModel, Vector position)
        {
            testScene.AddPositionedModel(testModel, position);
        }

        public void DeleteModelFromScene(Scene scene, PositionedModel model)
        {
            scene.RemovePositionedModel(model);
        }

        public void ChangeCameraSettings(Scene scene, Vector lookFrom, Vector lookAt, int fov)
        {
            scene.UpdateCameraSettings(lookFrom, lookAt, fov);
        }
    }
}