using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Domain.GraphicsEngine;
using Logic;

namespace Interface
{
    public partial class SceneList : UserControl
    {
        public SceneList()
        {
            InitializeComponent();
        }

        private void btnAddNewScene_Click(object sender, EventArgs e)
        {
            try
            {
                Client proprietary = SessionLogic.Instance.GetActiveUser();
                SceneLogic.Instance.CreateEmptyScene(proprietary);
                LoadScenePanel();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error");
            }
            
        }

        private void SceneList_Load(object sender, EventArgs e)
        {
            LoadScenePanel();
            flpMaterials.Parent = this;
        }

        private void LoadScenePanel()
        {
            try
            {
                flpMaterials.Controls.Clear();
                Client activeUser = SessionLogic.Instance.GetActiveUser();
                List<Scene> scenes = SceneLogic.Instance.GetClientScenes(activeUser);
                scenes = scenes.OrderByDescending(scene => scene.LastModified).ToList();
                foreach (var scene in scenes)
                {
                    SceneListElement newScene = new SceneListElement(scene);
                    flpMaterials.Controls.Add(newScene);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

          
        }
    }
}
