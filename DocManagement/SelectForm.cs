using DocManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LucySNamespace.DocManagement
{
    public partial class SelectForm : Form
    {
        private ManagingDocsFacade fasade;
        public SelectForm()
        {
            InitializeComponent();
            this.fasade = new ManagingDocsFacade();
            this.ViewAllButton.Click += ViewAllButton_Click;
            this.dataGridView.CellFormatting += DataGridView1_CellFormatting;
            this.EditButton.Click += EditData;
            this.ViewBeforeButton.Click += ViewByDate;
        }

        private void ViewByDate(object sender, EventArgs e)
        {

            try
            {
                dataGridView.DataSource = fasade.ViewRecordsByDate(DatabaseTables.FileCabinet, dateBeforePicker.Value);
                EditButton.Visible = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show(FormValidationMessages.ViewFailed);
            }

        }

        private void EditData(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            if (dataGridView.SelectedRows.Count == 1)
            {
                var row = dataGridView.SelectedRows[0];
                string[] res = fasade.Populate(DatabaseTables.FileCabinet, Guid.Parse(row.Cells["DocGuid"].Value.ToString()));
                editForm.SetValues(res);
            }
            editForm.ShowDialog(this);
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime value = (DateTime)e.Value;
                switch (value.Kind)
                {
                    case DateTimeKind.Local:
                        break;
                    case DateTimeKind.Unspecified:
                        e.Value = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToLocalTime();
                        break;
                    case DateTimeKind.Utc:
                        e.Value = value.ToLocalTime();
                        break;
                }
            }
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {

            List<Document> docs = fasade.ViewAllRecords(DatabaseTables.FileCabinet).ToList();
            dataGridView.DataSource = docs;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Name == "Price")
                {
                    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                }
            }
            EditButton.Visible = true;
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = fasade.ViewRecordByGuid(DatabaseTables.FileCabinet, Guid.Parse(textGuid.Text));
                EditButton.Visible = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show(FormValidationMessages.ViewFailed);
            }

        }

    }
}
