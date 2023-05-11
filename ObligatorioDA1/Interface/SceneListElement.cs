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
using Logic;

namespace Interface
{
    public partial class SceneListElement : UserControl
    {
        private Scene _scene;

        public Scene SceneToDisplay
        {
            set
            {
                _scene = value;
                lblSceneName.Text = value.Name;
                lblLastModification.Text = value.LastModified.ToString();
                Image generatedPreview = value.Preview.GetThumbnailImage(75, 
                                                     50, () => false, 
                                            IntPtr.Zero);
                picPreview.Image = generatedPreview;
            }
        }

        public SceneListElement(Scene scene)
        {
            InitializeComponent();
            SceneToDisplay = scene;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Control parentControl = Parent.Parent;
            parentControl.Controls.Clear();
            UserControl anEditScene = new EditScene(_scene);
            parentControl.Controls.Add(anEditScene);
            
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Instance.InstanceSceneLogic.DeleteScene(_scene);
            Dispose();
        }
    }
}
