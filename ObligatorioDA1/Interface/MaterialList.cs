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
            Client activeUser = Instance.InstanceSessionLogic.GetActiveUser();
            List<Material> materials= Instance.InstanceMaterialLogic.GetClientMaterials(activeUser);
            foreach (var material in materials)
            {
                MaterialListElement newMaterial = new MaterialListElement(material);
                flpMaterials.Controls.Add(newMaterial);
            }
            
        }
    }
}
