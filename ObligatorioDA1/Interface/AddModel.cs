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
    public partial class AddModel : UserControl
    {
        public AddModel()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserControl aModelList = new ModelList();
            Parent.Controls.Add(aModelList);
            Parent.Controls.Remove(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl aModelList = new ModelList();
            Parent.Controls.Add(aModelList);
            Parent.Controls.Remove(this);
        }
    }
}
