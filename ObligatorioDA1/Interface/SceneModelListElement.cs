using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using Domain;
using System.Reflection;

namespace Interface
{
    
    public partial class SceneModelListElement : UserControl
    {
        private Model _model;
        public Model ModelToDisplay
        {
            set
            {
                _model = value;
                lblModelName.Text = value.Name;
                picPreview.Image = value.Preview;
            }
            get => _model;

        }
        public Scene ParentScene { get; set; }
        public SceneModelListElement(Model model)
        {
            InitializeComponent();
            ModelToDisplay = model;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string inputX = Interaction.InputBox("Enter the X coordinate", "X coordinate", "0", 0, 0);
            decimal x = Convert.ToDecimal(inputX);
            string inputY = Interaction.InputBox("Enter the Y coordinate", "Y coordinate", "0", 0, 0);
            decimal y = Convert.ToDecimal(inputY);
            string inputZ = Interaction.InputBox("Enter the Z coordinate", "Z coordinate", "0", 0, 0);
            decimal z = Convert.ToDecimal(inputZ);
            Vector position = new Vector{X=x,Y=y,Z=z};
            ParentScene.AddPositionedModel(ModelToDisplay,position);
            ParentScene.LastModified = DateTime.Now;
            EditScene editScene= Parent.Parent as EditScene;
            editScene.UpdatePositionedModels();
            editScene.MakeWarningVisible();
        }

    }
}
