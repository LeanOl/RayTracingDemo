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
    public partial class SceneList : UserControl
    {
        public SceneList()
        {
            InitializeComponent();
        }

        private void btnAddNewScene_Click(object sender, EventArgs e)
        {
            Client proprietary = Instance.InstanceSessionLogic.GetActiveUser();
            Instance.InstanceSceneLogic.CreateEmptyScene(proprietary);
            LoadScenePanel();
            //UserControl anEditScene = new EditScene();
            //Parent.Controls.Add(anEditScene);
            //Parent.Controls.Remove(this);
        }

        private void SceneList_Load(object sender, EventArgs e)
        {
            LoadScenePanel();
        }

        private void LoadScenePanel()
        {
            flpMaterials.Controls.Clear();
            Client activeUser = Instance.InstanceSessionLogic.GetActiveUser();
            List<Scene> scenes = Instance.InstanceSceneLogic.GetClientScenes(activeUser);
            scenes = scenes.OrderByDescending(scene => scene.LastModified).ToList();
            foreach (var scene in scenes)
            {
                SceneListElement newScene = new SceneListElement(scene);
                flpMaterials.Controls.Add(newScene);
            }
        }
    }
}
