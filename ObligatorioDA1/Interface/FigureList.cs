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

        private void lstbFigures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FigureList_Load(object sender, EventArgs e)
        {
            Client activeUser = Instance.InstanceSessionLogic.GetActiveUser();
            List<Figure> figures = Instance.InstanceFigureLogic.GetFiguresByClient(activeUser);

            foreach (Figure figure in figures)
            {
                FigureListElement newFigure = new FigureListElement(figure);
                flpFigures.Controls.Add(newFigure);
            }
        }
    }
}
