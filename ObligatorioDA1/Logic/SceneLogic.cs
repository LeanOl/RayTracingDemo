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
            Camera sceneCamera = new Camera();
            Bitmap defaultPreview = new Bitmap(50, 50);
            Graphics gfx = Graphics.FromImage(defaultPreview);
            gfx.FillRectangle(Brushes.Gray, 0, 0, 50, 50);
            Scene emptyScene = new Scene
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