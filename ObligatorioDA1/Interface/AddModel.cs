using System;
using System.Windows.Forms;
using Domain;
using Domain.GraphicsEngine;
using Logic;

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
            Client user = SessionLogic.Instance.GetActiveUser();
            try
            {
                if (chkPreview.Checked)
                {
                    ModelLogic.Instance.CreateModelWithPreview(txtName.Text,
                        user,
                        cbxFigure.SelectedValue as Figure,
                        cbxMaterial.SelectedValue as Material);
                }
                else
                {
                    ModelLogic.Instance.CreateModel(txtName.Text,
                        user,
                        cbxFigure.SelectedValue as Figure,
                        cbxMaterial.SelectedValue as Material);
                }
                UserControl aModelList = new ModelList();
                Parent.Controls.Add(aModelList);
                Parent.Controls.Remove(this);


            }
            catch (Exception exception)
            {
                lblErrorMessage.Text = exception.Message;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserControl aModelList = new ModelList();
            Parent.Controls.Add(aModelList);
            Parent.Controls.Remove(this);
        }

        private void AddModel_Load(object sender, EventArgs e)
        {

            try
            {
                Client user = SessionLogic.Instance.GetActiveUser();
                cbxFigure.DataSource = FigureLogic.Instance.GetFiguresByClient(user);
                cbxFigure.DisplayMember = "Name";
                cbxFigure.ValueMember = null;
                cbxMaterial.DataSource = MaterialLogic.Instance.GetClientMaterials(user);
                cbxMaterial.DisplayMember = "Name";
                cbxFigure.ValueMember = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
