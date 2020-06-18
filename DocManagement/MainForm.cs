using System;
using System.Windows.Forms;
namespace LucySNamespace.DocManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
           
            var formPopup = new AddForm();
            formPopup.ShowDialog(this);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            var formPopup = new RemoveForm();
            formPopup.ShowDialog(this);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            var formPopup = new SelectForm();
            formPopup.ShowDialog(this);
        }
    }
}
