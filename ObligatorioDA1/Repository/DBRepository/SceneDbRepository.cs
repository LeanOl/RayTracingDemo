using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository.DBRepository
{
    public class SceneDbRepository : ISceneRepository
    {
        private RayTracingContext _context;
        public SceneDbRepository(RayTracingContext context)
        {
            _context = context;
        }

        public void Add(Scene testScene)
        {
            _context.Clients.Attach(testScene.Proprietary);
            foreach (var positionedModel in testScene.ModelList)
            {
                _context.Models.Attach(positionedModel.Model);
            }
            _context.Scenes.Add(testScene);
            _context.SaveChanges();
        }

        public Scene GetByName(string newScene)
        {
            return _context.Scenes.FirstOrDefault(x => x.Name == newScene);
        }

        public Scene GetByName(string sceneDefaultName, Client proprietary)
        {
            return _context.Scenes.FirstOrDefault(x =>
                x.Name == sceneDefaultName &&
                x.Proprietary.Equals(proprietary));
        }

        public List<Scene> GetScenesByClient(Client someClient)
        {
            return _context.Scenes.Where(x => x.Proprietary.ClientId == someClient.ClientId).ToList();
        }

        public void Delete(Scene testScene)
        {
            throw new System.NotImplementedException();
        }
    }
}