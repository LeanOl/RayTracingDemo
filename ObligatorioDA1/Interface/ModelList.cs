using Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic;

namespace Interface
{
    public partial class ModelList : UserControl
    {
        public ModelList()
        {
            InitializeComponent();
        }

        private void btnAddNewModel_Click(object sender, EventArgs e)
        {
            UserControl anAddModel = new AddModel();
            Parent.Controls.Add(anAddModel);
            Parent.Controls.Remove(this);
        }

        private void ModelList_Load(object sender, EventArgs e)
        {
            try
            {
                Client activeUser = SessionLogic.Instance.GetActiveUser();
                List<Model> models = ModelLogic.Instance.GetClientModels(activeUser);
                foreach (var model in models)
                {
                    ModelListElement newModel = new ModelListElement(model);
                    flpModels.Controls.Add(newModel);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }
    }
}
