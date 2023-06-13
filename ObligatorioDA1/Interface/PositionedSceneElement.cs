using System;
using System.Windows.Forms;
using Domain;
using Logic;

namespace Interface
{
    public partial class PositionedSceneElement : UserControl
    {
        private PositionedModel _positionedModel;

        public PositionedModel PositionedModelToDisplay
        {
            set
            {
                _positionedModel = value;
                lblModelName.Text = value.Model.Name;
                lblPosition.Text = value.Position.ToString();
                
            }
            get => _positionedModel;
        }
        public Scene ParentScene { get; set; }
        public PositionedSceneElement(PositionedModel model)
        {
            InitializeComponent();
            PositionedModelToDisplay = model;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SceneLogic.Instance.DeleteModelFromScene(ParentScene, PositionedModelToDisplay);
            SceneLogic.Instance.UpdateScene(ParentScene);
            EditScene editScene = Parent.Parent as EditScene;
            editScene.MakeWarningVisible();
            Dispose();
        }
    }
}
