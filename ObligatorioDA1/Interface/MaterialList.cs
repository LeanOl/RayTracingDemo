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
    }
}
