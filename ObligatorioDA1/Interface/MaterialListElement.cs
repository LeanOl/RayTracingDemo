using System;
using System.Windows.Forms;
using Domain;
using Logic;

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
                if (_material is Metallic)
                {
                    Metallic aMetallic = _material as Metallic;
                    lblRoughness.Text = $@"Roughness: {aMetallic.Roughness}";
                }
                lblType.Text= value.GetType().Name;
            }
        }
        public MaterialListElement(Material material)
        {
            InitializeComponent();
            MaterialToDisplay=material;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialLogic.Instance.DeleteMaterial(_material);
                Dispose();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
