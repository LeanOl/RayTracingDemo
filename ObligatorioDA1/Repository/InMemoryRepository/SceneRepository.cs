using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository.InMemoryRepository
{
    public class SceneRepository : ISceneRepository
    {
        private List<Scene> _scenes = new List<Scene>();
        public void Add(Scene testScene)
        {
            _scenes.Add(testScene);
        }

        public Scene GetByName(string newScene)
        {
            return _scenes.FirstOrDefault(x => x.Name == newScene);
        }

        public Scene GetByName(string sceneDefaultName, Client proprietary)
        {
            return _scenes.FirstOrDefault(x => 
                x.Name == sceneDefaultName &&
                x.Proprietary.Equals(proprietary));
        }

        public List<Scene> GetScenesByClient(Client someClient)
        {
            return _scenes.FindAll(x => x.Proprietary.Equals(someClient));
        }

        public void Delete(Scene testScene)
        {
            _scenes.Remove(testScene);
        }

        public void Update(Scene testScene)
        {
            _scenes.Remove(testScene);
            _scenes.Add(testScene);
        }
    }
}
