namespace garderob1
{
    partial class LostAndFoundForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewRequests = new DataGridView();
            btnAddRequest = new Button();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            btnChangeStatus = new Button();
            cmbStatus = new ComboBox();
            lblTitle = new Label();
            lblDescription = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            dataGridViewRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRequests.Location = new Point(12, 12);
            dataGridViewRequests.Name = "dataGridViewRequests";
            dataGridViewRequests.Size = new Size(760, 250);
            dataGridViewRequests.TabIndex = 0;
            // 
            // btnAddRequest
            // 
            btnAddRequest.Location = new Point(12, 368);
            btnAddRequest.Name = "btnAddRequest";
            btnAddRequest.Size = new Size(75, 23);
            btnAddRequest.TabIndex = 1;
            btnAddRequest.Text = "Добавить";
            btnAddRequest.UseVisualStyleBackColor = true;
            btnAddRequest.Click += btnAddRequest_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 300);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(118, 300);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(654, 23);
            txtDescription.TabIndex = 3;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(12, 368);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(75, 23);
            btnChangeStatus.TabIndex = 4;
            btnChangeStatus.Text = "Изменить";
            btnChangeStatus.UseVisualStyleBackColor = true;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Активный", "Завершен", "Отменен" });
            cmbStatus.Location = new Point(93, 368);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 284);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 15);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Заголовок";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(115, 284);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(62, 15);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Описание";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(93, 352);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(43, 15);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Статус";
            // 
            // LostAndFoundForm
            // 
            ClientSize = new Size(784, 431);
            Controls.Add(lblStatus);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(cmbStatus);
            Controls.Add(btnChangeStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(btnAddRequest);
            Controls.Add(dataGridViewRequests);
            Name = "LostAndFoundForm";
            Text = "Бюро находок";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
