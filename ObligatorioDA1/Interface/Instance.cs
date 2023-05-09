using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;


namespace Interface
{
    static class Instance
    {
        public static ClientLogic InstanceClientLogic { get; } = new ClientLogic();
        public static SessionLogic InstanceSessionLogic { get; } = new SessionLogic(InstanceClientLogic);
        public static FigureLogic InstanceFigureLogic { get; } = new FigureLogic();
        public static MaterialLogic InstanceMaterialLogic { get; } = new MaterialLogic();
        public static SceneLogic InstanceSceneLogic { get; } = new SceneLogic();


    }
}
