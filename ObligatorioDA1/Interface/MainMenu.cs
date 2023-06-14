using System;
using System.Windows.Forms;
using Logic;

namespace Interface
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionLogic.Instance.LogOut();
            SignIn signIn = new SignIn();
            Hide();
            signIn.Show();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFigures_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl aFigureList = new FigureList();
            controlPanel.Controls.Add(aFigureList);
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl aMaterialList = new MaterialList();
            controlPanel.Controls.Add(aMaterialList);
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl aModelList = new ModelList();
            controlPanel.Controls.Add(aModelList);
        }

        private void btnScenes_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl aSceneList = new SceneList();
            controlPanel.Controls.Add(aSceneList);

        }
    }
}
