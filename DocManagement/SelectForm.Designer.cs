namespace LucySNamespace.DocManagement
{
    partial class SelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// /*https://pasteboard.co/IJRvIhj.png*/
        private void InitializeComponent()
        {
            this.textGuid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ViewAllButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.dateBeforePicker = new System.Windows.Forms.DateTimePicker();
            this.ViewBeforeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textGuid
            // 
            this.textGuid.Location = new System.Drawing.Point(36, 46);
            this.textGuid.Name = "textGuid";
            this.textGuid.Size = new System.Drawing.Size(277, 20);
            this.textGuid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter GUID of the file you want to view:";
            // 
            // ViewButton
            // 
            this.ViewButton.Location = new System.Drawing.Point(333, 25);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(87, 60);
            this.ViewButton.TabIndex = 2;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 258);
            this.dataGridView1.TabIndex = 3;
            // 
            // ViewAllButton
            // 
            this.ViewAllButton.Location = new System.Drawing.Point(438, 25);
            this.ViewAllButton.Name = "ViewAllButton";
            this.ViewAllButton.Size = new System.Drawing.Size(87, 60);
            this.ViewAllButton.TabIndex = 4;
            this.ViewAllButton.Text = "View All";
            this.ViewAllButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(551, 418);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(63, 24);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Visible = false;
            // 
            // dateBeforePicker
            // 
            this.dateBeforePicker.Location = new System.Drawing.Point(36, 86);
            this.dateBeforePicker.Name = "dateBeforePicker";
            this.dateBeforePicker.Size = new System.Drawing.Size(277, 20);
            this.dateBeforePicker.TabIndex = 6;
            // 
            // ViewBeforeButton
            // 
            this.ViewBeforeButton.Location = new System.Drawing.Point(544, 26);
            this.ViewBeforeButton.Name = "ViewBeforeButton";
            this.ViewBeforeButton.Size = new System.Drawing.Size(79, 60);
            this.ViewBeforeButton.TabIndex = 7;
            this.ViewBeforeButton.Text = "View Before";
            this.ViewBeforeButton.UseVisualStyleBackColor = true;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.ViewBeforeButton);
            this.Controls.Add(this.dateBeforePicker);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ViewAllButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textGuid);
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textGuid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ViewAllButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.DateTimePicker dateBeforePicker;
        private System.Windows.Forms.Button ViewBeforeButton;
    }
}