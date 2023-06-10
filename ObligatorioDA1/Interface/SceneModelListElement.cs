using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using Domain;

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
                picPreview.Image = value.GetPreview();
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
            try
            {
                string inputX = Interaction.InputBox("Enter the X coordinate", "X coordinate", "0", 0, 0);
                decimal x = Convert.ToDecimal(inputX);
                string inputY = Interaction.InputBox("Enter the Y coordinate", "Y coordinate", "0", 0, 0);
                decimal y = Convert.ToDecimal(inputY);
                string inputZ = Interaction.InputBox("Enter the Z coordinate", "Z coordinate", "0", 0, 0);
                decimal z = Convert.ToDecimal(inputZ);
                Vector position = new Vector { X = x, Y = y, Z = z };
                ParentScene.AddPositionedModel(ModelToDisplay, position);
                ParentScene.LastModified = DateTime.Now;
                EditScene editScene = Parent.Parent as EditScene;
                editScene.UpdatePositionedModels();
                editScene.MakeWarningVisible();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid coordinates");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
