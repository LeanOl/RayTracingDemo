using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;
using Logic;

namespace Interface
{
    public partial class MaterialList : UserControl
    {
        public MaterialList()
        {
            InitializeComponent();
        }

        private void btnAddNewMaterial_Click(object sender, EventArgs e)
        {
            UserControl anAddMaterial = new AddMaterial();
            Parent.Controls.Add(anAddMaterial);
            Parent.Controls.Remove(this);
        }

        private void MaterialList_Load(object sender, EventArgs e)
        {
            try
            {
                Client activeUser = SessionLogic.Instance.GetActiveUser();
                List<Material> materials = MaterialLogic.Instance.GetClientMaterials(activeUser);
                foreach (var material in materials)
                {
                    MaterialListElement newMaterial = new MaterialListElement(material);
                    flpMaterials.Controls.Add(newMaterial);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            
        }
    }
}
