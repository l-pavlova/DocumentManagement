using DocManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            this.EditButton.Click += EditData;
            this.ViewBeforeButton.Click += ViewByDate;
        }

        private void ViewByDate(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.DataSource = fasade.ViewRecordsByDate("FileCabinet", dateBeforePicker.Value);
                EditButton.Visible = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Trying to view without selecting date!");
            }

        }

        private void EditData(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var row = dataGridView1.SelectedRows[0];
                string[] res = fasade.Populate("FileCabinet", Guid.Parse(row.Cells["DocGuid"].Value.ToString()));
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

            List<Document> docs = fasade.ViewAllRecords("FileCabinet").ToList();
            dataGridView1.DataSource = docs;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name == "Price")
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                }
            }
            EditButton.Visible = true;
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = fasade.ViewRecordByGuid("FileCabinet", Guid.Parse(textGuid.Text));
                EditButton.Visible = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Trying to view without selection guid!");
            }

        }

    }
}
