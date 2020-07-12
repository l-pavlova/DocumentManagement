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

        private void AddClick(object sender, EventArgs e)
        {

            var formPopup = new AddForm();
            formPopup.ShowDialog(this);
        }

        private void RemoveClick(object sender, EventArgs e)
        {
            var formPopup = new RemoveForm();
            formPopup.ShowDialog(this);
        }

        private void SelectButtonClick(object sender, EventArgs e)
        {
            var formPopup = new SelectForm();
            formPopup.ShowDialog(this);
        }
    }
}
