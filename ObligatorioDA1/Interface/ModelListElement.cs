using System;
using System.Windows.Forms;
using Domain;
using Logic;

namespace Interface
{
    public partial class ModelListElement : UserControl
    {
        private Model _model;

        public Model ModelToDisplay
        {
            set
            {
                _model = value;
                lblModelName.Text = value.Name;
                lblFigure.Text = value.Figure.Name;
                lblMaterial.Text = value.Material.Name;
                picPreview.Image = value.Preview;
            }
        }
        public ModelListElement(Model model)
        {
            InitializeComponent();
            ModelToDisplay = model;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ModelLogic.Instance.DeleteModel(_model);
            Dispose();
        }
    }
}
