using System;
using System.Drawing;
using System.Windows.Forms;
using Domain;
using Logic;

namespace Interface
{
    public partial class AddMaterial : UserControl
    {
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Client proprietary = SessionLogic.Instance.GetActiveUser();
                int red = int.Parse(txtRed.Text);
                int green = int.Parse(txtGreen.Text);
                int blue = int.Parse(txtBlue.Text);
                string materialName = txtMaterialName.Text;
                Color materialColor = Color.FromArgb(red, green, blue);
                if (rbLambertian.Checked)
                {
                    MaterialLogic.Instance.CreateLambertian(proprietary, materialName,materialColor);
                }
                else
                {
                    double roughness = double.Parse(txtRoughness.Text);
                    Metallic aMetallic = new Metallic
                    {
                        Name= materialName,
                        Color=materialColor,
                        Roughness=roughness,
                        Proprietary=proprietary
                    };
                    MaterialLogic.Instance.CreateMetallic(aMetallic);
                }

                UserControl aMaterialList = new MaterialList();
                Parent.Controls.Add(aMaterialList);
                Parent.Controls.Remove(this);
            }
            catch (FormatException)
            {
                lblErrorMessage.Text = "Colors should be numeric";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text=ex.Message;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl aMaterialList = new MaterialList();
            Parent.Controls.Add(aMaterialList);
            Parent.Controls.Remove(this);
        }

        private void btnAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbMetallic_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMetallic.Checked)
            {
                txtRoughness.Text = "";
                txtRoughness.Visible = true;
                lblRoughness.Visible = true;
            }
            else
            {
                txtRoughness.Visible = false;
                lblRoughness.Visible = false;
            }
        }
    }
}
