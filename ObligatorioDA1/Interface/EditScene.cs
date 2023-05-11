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
    public partial class EditScene : UserControl
    {
        private Scene _sceneToEdit;
        public Scene SceneToEdit { get =>_sceneToEdit;
            set
            {
                _sceneToEdit = value;
                lblSceneName.Text = value.Name;
                lblLastRendered.Text = value.LastRendered.ToString();
                picRenderedImage.Image = value.Preview;
                if(value.LastModified > value.LastRendered)
                    lblOutdatedWarning.Visible = true;

            }
                                                                                                                   
        }
        public EditScene(Scene scene)
        {
            InitializeComponent();
            SceneToEdit = scene;
            flpModels.Parent = this;
            flpPositionedModels.Parent = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl aSceneList= new SceneList();
            Parent.Controls.Add(aSceneList);
            Parent.Controls.Remove(this);
        }

        private void EditScene_Load(object sender, EventArgs e)
        {
            flpModels.Parent = this;
            flpPositionedModels.Parent = this;
            Client proprietary = SceneToEdit.Proprietary;
            List<Model> availableModels = Instance.InstanceModelLogic.GetClientModels(proprietary);
            List<PositionedModel> sceneModels = SceneToEdit.ModelList;
            foreach (Model model in availableModels)
            {
               SceneModelListElement newElement = new SceneModelListElement(model);
               newElement.ParentScene = SceneToEdit;
               flpModels.Controls.Add(newElement);
               
               
            }

            foreach (PositionedModel model in sceneModels)
            {
                PositionedSceneElement newElement = new PositionedSceneElement(model);
                newElement.ParentScene = SceneToEdit;
                flpPositionedModels.Controls.Add(newElement);
            }
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            Instance.InstanceSceneLogic.UpdatePreview(SceneToEdit);
            picRenderedImage.Image = SceneToEdit.Preview;
            lblLastRendered.Text = SceneToEdit.LastRendered.ToString();
            lblOutdatedWarning.Visible= false;
        }

        public void UpdatePositionedModels()
        {
            flpPositionedModels.Controls.Clear();
            List<PositionedModel> sceneModels = SceneToEdit.ModelList;
            foreach (PositionedModel model in sceneModels)
            {
                PositionedSceneElement newElement = new PositionedSceneElement(model);
                newElement.ParentScene = SceneToEdit;
                flpPositionedModels.Controls.Add(newElement);
            }
        }

        public void MakeWarningVisible()
        {
            lblOutdatedWarning.Visible = true;
        }

        private void btnUpdateCamera_Click(object sender, EventArgs e)
        {
            try
            {
                int fov = Convert.ToInt32(txtFov.Text);
                decimal lookFromX = Convert.ToDecimal(txtLookFromX.Text);
                decimal lookFromY = Convert.ToDecimal(txtLookFromY.Text);
                decimal lookFromZ = Convert.ToDecimal(txtLookFromZ.Text);
                Vector lookFrom= new Vector{X= lookFromX, Y= lookFromY, Z= lookFromZ};
                decimal lookAtX = Convert.ToDecimal(txtLookAtX.Text);
                decimal lookAtY = Convert.ToDecimal(txtLookAtY.Text);
                decimal lookAtZ = Convert.ToDecimal(txtLookAtZ.Text);
                Vector lookAt = new Vector { X = lookAtX, Y = lookAtY, Z = lookAtZ };
                Instance.InstanceSceneLogic.UpdateCameraSettings(SceneToEdit, lookFrom, lookAt, fov);
                ClearTextboxes();
                SceneToEdit.LastModified = DateTime.Now;
                lblOutdatedWarning.Visible = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("ERROR: FOV should be between 1 and 160");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void ClearTextboxes()
        {
            txtFov.Text = "";
            txtLookFromX.Text = "";
            txtLookFromY.Text = "";
            txtLookFromZ.Text = "";
            txtLookAtX.Text = "";
            txtLookAtY.Text = "";
            txtLookAtZ.Text = "";
        }
    }
}
