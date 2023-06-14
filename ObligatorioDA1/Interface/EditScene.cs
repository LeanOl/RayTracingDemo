using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;
using Domain.GraphicsEngine;
using Logic;

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
                picRenderedImage.Image = value.GetPreviewImage();
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
            try
            {
                flpModels.Parent = this;
                flpPositionedModels.Parent = this;
                Client proprietary = SceneToEdit.Proprietary;
                List<Model> availableModels = ModelLogic.Instance.GetClientModels(proprietary);
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            try
            {
                SceneLogic.Instance.UpdatePreviewNoDefocus(SceneToEdit);
                picRenderedImage.Image = SceneToEdit.GetPreviewImage();
                SceneLogic.Instance.UpdateScene(SceneToEdit);
                lblLastRendered.Text = SceneToEdit.LastRendered.ToString();
                lblOutdatedWarning.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        public void UpdatePositionedModels()
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
                double aperture = Convert.ToDouble(txtAperture.Text);
                SceneLogic.Instance.UpdateCameraSettings(SceneToEdit, lookFrom, lookAt, fov, aperture);
                ClearTextboxes();
                SceneToEdit.LastModified = DateTime.Now;
                SceneLogic.Instance.UpdateScene(SceneToEdit);
                lblOutdatedWarning.Visible = true;
            }
            catch (ArgumentOutOfRangeException)
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
            txtAperture.Text = "";
        }

        private void btnRenderDefocus_Click(object sender, EventArgs e)
        {
            SceneLogic.Instance.UpdatePreviewDefocus(SceneToEdit);
            SceneLogic.Instance.UpdateScene(SceneToEdit);
            picRenderedImage.Image = SceneToEdit.GetPreviewImage();
            lblLastRendered.Text = SceneToEdit.LastRendered.ToString();
            lblOutdatedWarning.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image |*.jpg|Png Image|*.png|Ppm Image|*.ppm";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            try
            {

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        SceneLogic.Instance.SavePreviewAsJpg(SceneToEdit, saveFileDialog1.FileName);
                        break;
                    case 2:
                        SceneLogic.Instance.SavePreviewAsPng(SceneToEdit, saveFileDialog1.FileName);
                        break;
                    case 3:
                        SceneLogic.Instance.SavePreviewAsPpm(SceneToEdit, saveFileDialog1.FileName);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
