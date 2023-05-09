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
            //UserControl anEditScene = new EditScene();
            //Parent.Controls.Add(anEditScene);
            //Parent.Controls.Remove(this);
        }
    }
}
