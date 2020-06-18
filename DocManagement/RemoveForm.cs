using DocManagement;
using System;
using System.Windows.Forms;

namespace LucySNamespace.DocManagement
{
    public partial class RemoveForm : Form
    {
        ManagingDocsFacade fasade;
        public RemoveForm()
        {
            InitializeComponent();
            this.fasade = new ManagingDocsFacade();
            this.DeleteButton.Click += DeleteButton_Click;
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                fasade.Delete(DatabaseTables.FileCabinet, guidText.Text);
                MessageBox.Show(FormValidationMessages.Deleted);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(FormValidationMessages.DeleteError);
            }

            this.Close();
        }

    }
}
