using System.Collections.Generic;
using System.Drawing;
using Domain;
using Domain.GraphicsEngine;
using Repository;
using Repository.DBRepository;
using Repository.InMemoryRepository;
using ImageConverter = Domain.Utilities.ImageConverter;

namespace Logic
{
    public class SceneLogic
    {
        private ISceneRepository _repository;

        private SceneLogic()
        {
            _repository = new SceneRepository();
        }

        public SceneLogic(ISceneRepository repository)
        {
            _repository = repository;
        }

        public static SceneLogic Instance { get; } = new SceneLogic();

        public static void Reset()
        {
            Instance._repository = new SceneRepository();
        }
        public void CreateEmptyScene(Client proprietary)
        {
            Scene emptyScene;
            Camera sceneCamera = new NoDefocusCamera();
            Bitmap defaultPreview = new Bitmap(300, 200);
            Graphics gfx = Graphics.FromImage(defaultPreview);
            gfx.Clear(Color.Gray);
            string defaultPreviewPpm= ImageConverter.ConvertToPpm(defaultPreview);
            string sceneDefaultName= GenerateSceneDefaultName(proprietary);
            

            emptyScene = new Scene
            {
                Name = sceneDefaultName,
                Proprietary = proprietary,
                CreationDate = System.DateTime.Now,
                LastModified = System.DateTime.Now,
                LastRendered = System.DateTime.Now,
                ModelList = new List<PositionedModel>(),
                Preview = defaultPreviewPpm
            };
            _repository.Add(emptyScene);
            
        }

        private string GenerateSceneDefaultName(Client proprietary)
        {
            string sceneDefaultName = "Empty Scene";
            if (_repository.GetByName(sceneDefaultName,proprietary) != null)
            {
                int i = 1;
                while (_repository.GetByName(sceneDefaultName + " " + i,proprietary) != null)
                {
                    i++;
                }
                sceneDefaultName = sceneDefaultName + " " + i;
            }

            return sceneDefaultName;
        }

        public void UpdateScene(Scene testScene)
        {
            _repository.Update(testScene);
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

        public void UpdateCameraSettings(Scene scene, Vector lookFrom, Vector lookAt, int fov,double aperture)
        {
            
            scene.UpdateCameraSettings(lookFrom, lookAt, fov, aperture);
        }

        public void UpdatePreviewNoDefocus(Scene scene)
        {
            scene.RenderPreviewNoDefocus();
        }

        public void UpdatePreviewDefocus(Scene scene)
        {
            scene.RenderPreviewDefocus();
        }
        public void DeleteScene(Scene testScene)
        {
            _repository.Delete(testScene);
        }

        public void SavePreviewAsPpm(Scene scene, string path)
        {
            scene.SavePreviewAsPpm(path);
        }

        public void SavePreviewAsPng(Scene scene, string path)
        {
            scene.SavePreviewAsPng(path);
        }

        public void SavePreviewAsJpg(Scene scene, string path)
        {
            scene.SavePreviewAsJpg(path);
        }

        public bool IsModelUsed(Model model)
        {
            List<Scene> userScenes = _repository.GetScenesByClient(model.Proprietary);

            return userScenes.Exists(scene => scene.ModelList.Exists(positionedModel =>
                positionedModel.Model.Name == model.Name &&
                positionedModel.Model.Proprietary.Username == model.Proprietary.Username));
        }
    }
}