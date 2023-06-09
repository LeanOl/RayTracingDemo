using System;
using System.Windows.Forms;
using Domain;
using Logic;

namespace Interface
{
    public partial class AddSphere : UserControl
    {
        public AddSphere()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                Client proprietary = SessionLogic.Instance.GetActiveUser();
                string name = txtFigureName.Text;
                decimal radius = decimal.Parse(txtFigureRadius.Text);

                Sphere aSphere = new Sphere()
                {
                    Propietary = proprietary,
                    Name = name,
                    Radius = radius
                };
            
                FigureLogic.Instance.CreateFigure(aSphere);


                UserControl aFigureList = new FigureList();
                Parent.Controls.Add(aFigureList);
                Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl aFigureList = new FigureList();
            Parent.Controls.Add(aFigureList);
            Parent.Controls.Remove(this);
        }

        private void AddSphere_Load(object sender, EventArgs e)
        {

        }
    }
}
