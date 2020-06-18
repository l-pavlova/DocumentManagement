using DocManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LucySNamespace.DocManagement
{
    public partial class AddForm : Form
    {
        private const int START_INDEX = 9;
        private const int PATH_LENGTH = 10;
        private string filePath = string.Empty;
        ManagingDocsFacade fasade;
        FileInfo info;
        User user;
        Cabinet cabinet;
        public AddForm()
        {
            InitializeComponent();
            fasade = new ManagingDocsFacade();

            this.OkButton.Click += OkButton_Click;
            foreach (TextBox tb in this.Controls.OfType<TextBox>().Where(x => x.CausesValidation == true))
            {
                tb.Validating += TextBox_Validate;
            }
            this.user = FakeModelObjects.GetUser();
            this.cabinet = FakeModelObjects.GetCabinet(this.user);
}
        private void TextBox_Validate(object sender, EventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (currenttb.Text == "")
            {
                MessageBox.Show(string.Format("Empty field {0 }", currenttb.Name.Substring(3)));
                return;
            }
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Load Documents";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
                PathLabel.Text += filePath;
                info = new FileInfo(filePath);
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                filePath = PathLabel.Text.Substring(START_INDEX);
                info = new FileInfo(filePath);
                var g = Guid.NewGuid();
                Document d = new Document
                {
                    DocGuid = g,
                    StoreDate = DateTime.Now,
                    Size = info.Length,
                    Price = Double.Parse(PriceTextBox.Text.Trim()),
                    Contragent = ContragTextBox.Text.Trim(),
                    MailAddress = MailTextBox.Text.Trim(),
                    Description = DescriptionTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(),
                    DocumentDate = dateTimePicker1.Value.ToUniversalTime(),
                    FilePath = filePath,
                    UserId=user.Id,
                    Cabinet=cabinet.Id
                };
                var list = new List<Document>();
                list.Add(d);
                this.fasade.AddItems("FileCabinet", list);
                MessageBox.Show("Successfully added!");
                this.Close();
            }
        }
        private bool ValidateForm()
        {
            var textBoxes = Controls.Cast<Control>().OfType<TextBox>().OrderBy(control => control.TabIndex);

            foreach (var textBox in textBoxes)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (PathLabel.Text.Length <= PATH_LENGTH)
                    {
                        MessageBox.Show("Select file please");
                        return false;
                    }
                    return true;
                }
            }
            MessageBox.Show(string.Format("Fill at least one field please."));
            return false;
        }

    }
}
