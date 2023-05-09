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
    public partial class FigureListElement : UserControl
    {

        private Figure _figure;
        
        public Figure FigureToDisplay
        {
            set
            {
                Sphere sphere = (Sphere)value;
                _figure = sphere;
                lblName.Text = sphere.Name;
                lblRadius.Text = sphere.Radius.ToString();
            }
        }
        public FigureListElement(Figure figure)
        {
            InitializeComponent();
            FigureToDisplay = figure;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_click(object sender, EventArgs e)
        {
            try
            {
                Instance.InstanceFigureLogic.RemoveFigure(_figure.Name , _figure.Propietary.Username);
                Dispose();
            }catch (Exception ex)
            {
                string title = "Figure could not be deleted";
                string message = ex.Message;
                MessageBox.Show(message,title);
            }
        }

        private void FigureListElement_Load(object sender, EventArgs e)
        {

        }
    }
}
