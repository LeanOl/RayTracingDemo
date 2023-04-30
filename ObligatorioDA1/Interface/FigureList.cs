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
    public partial class FigureList : UserControl
    {
        public FigureList()
        {
            InitializeComponent();
        }

        private void btnAddNewFigure_Click(object sender, EventArgs e)
        {
            
            
            UserControl anAddSphere = new AddSphere();
            Parent.Controls.Add(anAddSphere);
            Parent.Controls.Remove(this);

        }
    }
}
