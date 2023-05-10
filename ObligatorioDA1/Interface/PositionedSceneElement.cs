using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

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
            Instance.InstanceSceneLogic.DeleteModelFromScene(ParentScene, PositionedModelToDisplay);
            Dispose();
        }
    }
}
