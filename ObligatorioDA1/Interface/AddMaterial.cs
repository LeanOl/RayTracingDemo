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
                Client proprietary = Instance.InstanceSessionLogic.GetActiveUser();
                int red = int.Parse(txtRed.Text);
                int green = int.Parse(txtGreen.Text);
                int blue = int.Parse(txtBlue.Text);
                string materialName = txtMaterialName.Text;

                Color materialColor = Color.FromArgb(red, green, blue);
                Instance.MateriaLogic.CreateLambertian(proprietary, materialName, materialColor);
                UserControl aMaterialList = new MaterialList();
                Parent.Controls.Add(aMaterialList);
                Parent.Controls.Remove(this);
            }
            catch (FormatException ex)
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
    }
}
