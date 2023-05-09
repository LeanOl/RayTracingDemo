using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class SceneRepository
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

        public object GetByName(string sceneDefaultName, Client proprietary)
        {
            return _scenes.FirstOrDefault(x => 
                x.Name == sceneDefaultName &&
                x.Proprietary.Equals(proprietary));
        }
    }
}
