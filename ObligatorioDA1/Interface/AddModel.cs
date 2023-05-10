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
    public partial class AddModel : UserControl
    {
        public AddModel()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Client user = Instance.InstanceSessionLogic.GetActiveUser();
            try
            {
                if (chkPreview.Checked)
                {
                    Instance.InstanceModelLogic.CreateModelWithPreview(txtName.Text,
                        user,
                        cbxFigure.SelectedValue as Figure,
                        cbxMaterial.SelectedValue as Material);
                }
                else
                {
                    Instance.InstanceModelLogic.CreateModel(txtName.Text,
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
            Client user = Instance.InstanceSessionLogic.GetActiveUser();
            cbxFigure.DataSource = Instance.InstanceFigureLogic.GetFiguresByClient(user);
            cbxFigure.DisplayMember = "Name";
            cbxFigure.ValueMember = null;
            cbxMaterial.DataSource = Instance.InstanceMaterialLogic.GetClientMaterials(user);
            cbxMaterial.DisplayMember = "Name";
            cbxFigure.ValueMember = null;
        }
    }
}
