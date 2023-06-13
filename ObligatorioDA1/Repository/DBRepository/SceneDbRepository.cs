using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Exceptions;

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
            try
            {
                _context.Clients.Attach(testScene.Proprietary);
                foreach (var positionedModel in testScene.ModelList)
                {
                    _context.Models.Attach(positionedModel.Model);
                }
                _context.Scenes.Add(testScene);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new DatabaseException("Database error", e);   
            }
            
        }

        public Scene GetByName(string newScene)
        {
            try
            {
                return _context.Scenes.FirstOrDefault(x =>
                    x.Name == newScene);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }

           
        }

        public Scene GetByName(string sceneDefaultName, Client proprietary)
        {
            try
            {
                return _context.Scenes.FirstOrDefault(x =>
                    x.Name == sceneDefaultName &&
                    x.Proprietary.ClientId == proprietary.ClientId);
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
            
        }

        public List<Scene> GetScenesByClient(Client someClient)
        {
            try
            {
                return _context.Scenes.Where(x => x.Proprietary.ClientId == someClient.ClientId)
                    .Include(scene => scene.ModelList)
                    .Include(scene => scene.ModelList.Select(model => model.Model))
                    .Include(scene => scene.ModelList.Select(model => model.Model.Figure))
                    .Include(scene => scene.ModelList.Select(model => model.Model.Material))
                    .ToList();
            }
            catch (Exception e)
            {
               throw new DatabaseException("Database error", e);
            }
            
        }

        public void Delete(Scene testScene)
        {
            try
            {
                _context.Scenes.Remove(testScene);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
            
        }

        public void Update(Scene testScene)
        {
            try
            {
                _context.Entry(testScene).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DatabaseException("Database error", e);
            }
        }
    }
}