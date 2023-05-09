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
            Bitmap defaultPreview = new Bitmap(50, 50);
            Graphics gfx = Graphics.FromImage(defaultPreview);
            gfx.FillRectangle(Brushes.Gray, 0, 0, 50, 50);
            if (_repository.GetByName("Empty Scene") != null)
            {
                int i = 1;
                while (_repository.GetByName("Empty Scene " + i) != null)
                {
                    i++;
                }
                emptyScene = new Scene
                {
                    Name = "Empty Scene " + i,
                    Proprietary = proprietary,
                    Camera = sceneCamera,
                    CreationDate = System.DateTime.Now,
                    LastModified = System.DateTime.Now,
                    LastRendered = System.DateTime.Now,
                    ModelList = new List<PositionedModel>(),
                    Preview = defaultPreview
                };
                _repository.Add(emptyScene);
                return;
            }
            emptyScene = new Scene
            {
                Name = "Empty Scene",
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

        public Scene GetSceneByName(string emptyScene)
        {
            return _repository.GetByName(emptyScene);
        }
    }
}