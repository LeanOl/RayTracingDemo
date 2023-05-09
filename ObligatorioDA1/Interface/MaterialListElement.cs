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
    public partial class MaterialListElement : UserControl
    {
        private Material _material;
        public Material MaterialToDisplay {

            set
            {
                _material=value;
                lblMaterialName.Text = value.Name;
                lblBlue.Text=value.Color.B.ToString();
                lblRed.Text = value.Color.R.ToString();
                lblGreen.Text= value.Color.G.ToString();
                picColorPreview.BackColor = value.Color;
            }
        }
        public MaterialListElement(Material material)
        {
            InitializeComponent();
            MaterialToDisplay=material;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            Instance.InstanceMaterialLogic.DeleteMaterial(_material);
            Dispose();
        }
    }
}
