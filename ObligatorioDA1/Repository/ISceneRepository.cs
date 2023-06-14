using System.Collections.Generic;
using Domain;
using Domain.GraphicsEngine;

namespace Repository
{
    public interface ISceneRepository
    {
        void Add(Scene testScene);
        Scene GetByName(string newScene);
        Scene GetByName(string sceneDefaultName, Client proprietary);
        List<Scene> GetScenesByClient(Client someClient);
        void Delete(Scene testScene);
        void Update(Scene testScene); 
        
    }
}