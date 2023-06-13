using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;

namespace Repository.DBRepository
{
    public class SceneDbRepository : ISceneRepository
    {
        private RayTracingContext _context;

        public SceneDbRepository()
        {
            _context = RayTracingContext.Instance;
        }
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
                x.Proprietary.ClientId == proprietary.ClientId);
        }

        public List<Scene> GetScenesByClient(Client someClient)
        {
            return _context.Scenes.Where(x => x.Proprietary.ClientId == someClient.ClientId)
                .Include(scene => scene.ModelList)
                .Include(scene => scene.ModelList.Select(model => model.Model))
                .Include(scene => scene.ModelList.Select(model => model.Model.Figure))
                .Include(scene => scene.ModelList.Select(model => model.Model.Material))
                .ToList();
        }

        public void Delete(Scene testScene)
        {
            _context.Scenes.Remove(testScene);
            _context.SaveChanges();
        }

        public void Update(Scene testScene)
        {
            _context.Entry(testScene).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}