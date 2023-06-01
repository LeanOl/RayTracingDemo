using Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            Client activeUser = Instance.InstanceSessionLogic.GetActiveUser();
            List<Model> models = Instance.InstanceModelLogic.GetClientModels(activeUser);
            foreach (var model in models)
            {
                ModelListElement newModel = new ModelListElement(model);
                flpModels.Controls.Add(newModel);
            }
        }
    }
}
