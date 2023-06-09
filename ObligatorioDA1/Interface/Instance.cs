using Logic;


namespace Interface
{
    static class Instance
    {
        public static ClientLogic InstanceClientLogic { get; } = ClientLogic.Instance;
        public static SessionLogic InstanceSessionLogic { get; } = SessionLogic.Instance;
        public static FigureLogic InstanceFigureLogic { get; } = FigureLogic.Instance;
        public static MaterialLogic InstanceMaterialLogic { get; } = MaterialLogic.Instance;
        public static SceneLogic InstanceSceneLogic { get; } = SceneLogic.Instance;
        public static ModelLogic InstanceModelLogic { get; } = ModelLogic.Instance;


    }
}
