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
    public partial class EditScene : UserControl
    {
        public EditScene()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl aSceneList= new SceneList();
            Parent.Controls.Add(aSceneList);
            Parent.Controls.Remove(this);
        }
    }
}
