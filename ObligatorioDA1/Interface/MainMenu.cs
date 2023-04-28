using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnFigures_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl figureList = new FigureList();
            controlPanel.Controls.Add(figureList);
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl materialList = new MaterialList();
            controlPanel.Controls.Add(materialList);
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl modelList = new ModelList();
            controlPanel.Controls.Add(modelList);
        }

        private void btnScenes_Click(object sender, EventArgs e)
        {
            controlPanel.Controls.Clear();
            UserControl sceneList = new SceneList();
            controlPanel.Controls.Add(sceneList);
        }
    }
}
