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
    public partial class AddMaterial : UserControl
    {
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserControl aMaterialList = new MaterialList();
            Parent.Controls.Add(aMaterialList);
            Parent.Controls.Remove(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl aMaterialList = new MaterialList();
            Parent.Controls.Add(aMaterialList);
            Parent.Controls.Remove(this);
        }
    }
}
