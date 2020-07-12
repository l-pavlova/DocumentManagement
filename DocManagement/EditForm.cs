using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DocManagement
{
    public partial class EditForm : Form
    {
        private ManagingDocsFacade fasade;
        public EditForm()
        {
            InitializeComponent();
            this.fasade = new ManagingDocsFacade();
            this.OkButton.Click += OkButtonClick;
            this.PreviewButton.Click += PreviewButtonClick;
        }
        private void PreviewButtonClick(object sender, EventArgs e)
        {
            string filepath = PathLabel.Text;
            filepath = filepath.Replace("Filepath:", "");
            Process.Start(filepath);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            string filepath = PathLabel.Text.Substring(9);
            FileInfo info = new FileInfo(filepath);
            Document document = new Document
            {
                DocGuid = Guid.Parse(GuidBox.Text.Trim()),
                StoreDate = DateTime.Now.ToUniversalTime(),
                Size = info.Length,
                Price = Double.Parse(PriceTextBox.Text.Trim()),
                Contragent = ContragentTextBox.Text.Trim(),
                MailAddress = MailTextBox.Text.Trim(),
                Description = DescriptionTextBox.Text.Trim(),
                Phone = PhoneTextBox.Text.Trim(),
                DocumentDate = dateTimePicker1.Value.ToUniversalTime(),
                FilePath = filepath
            };

            fasade.Update(DatabaseTables.FileCabinet, document);
            MessageBox.Show(FormValidationMessages.Editted);
            this.Close();
        }

        public void SetValues(params string[] parameters)
        {
            this.GuidBox.Text = parameters[0];
            this.PriceTextBox.Text = parameters[1];
            this.ContragentTextBox.Text = parameters[2];
            this.MailTextBox.Text = parameters[3];
            this.PhoneTextBox.Text = parameters[4];
            this.DescriptionTextBox.Text = parameters[5];
            PathLabel.Text += parameters[6];
        }
    }
}
