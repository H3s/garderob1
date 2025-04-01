namespace garderob1
{
    partial class AdminForm
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
        private void InitializeComponent()
        {
            txtTicketCount = new TextBox();
            btnSetupTickets = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnRefresh = new Button();
            lblStats = new Label();
            btnLostAndFound = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTicketCount
            // 
            txtTicketCount.Location = new Point(35, 52);
            txtTicketCount.Margin = new Padding(4, 3, 4, 3);
            txtTicketCount.Name = "txtTicketCount";
            txtTicketCount.Size = new Size(130, 23);
            txtTicketCount.TabIndex = 0;
            // 
            // btnSetupTickets
            // 
            btnSetupTickets.Location = new Point(184, 48);
            btnSetupTickets.Margin = new Padding(4, 3, 4, 3);
            btnSetupTickets.Name = "btnSetupTickets";
            btnSetupTickets.Size = new Size(175, 27);
            btnSetupTickets.TabIndex = 1;
            btnSetupTickets.Text = "Установить количество";
            btnSetupTickets.UseVisualStyleBackColor = true;
            btnSetupTickets.Click += btnSetupTickets_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 92);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(462, 261);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 3;
            label1.Text = "Количество номерков";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(380, 48);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(117, 27);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Обновить таблицу";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Location = new Point(184, 23);
            lblStats.Margin = new Padding(4, 0, 4, 0);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(25, 15);
            lblStats.TabIndex = 5;
            lblStats.Text = "123";
            // 
            // btnLostAndFound
            // 
            btnLostAndFound.Location = new Point(203, 359);
            btnLostAndFound.Margin = new Padding(4, 3, 4, 3);
            btnLostAndFound.Name = "btnLostAndFound";
            btnLostAndFound.Size = new Size(117, 27);
            btnLostAndFound.TabIndex = 6;
            btnLostAndFound.Text = "Бюро находок";
            btnLostAndFound.UseVisualStyleBackColor = true;
            btnLostAndFound.Click += btnLostAndFound_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 399);
            Controls.Add(btnLostAndFound);
            Controls.Add(lblStats);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnSetupTickets);
            Controls.Add(txtTicketCount);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AdminForm";
            Text = "Панель администратора";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTicketCount;
        private System.Windows.Forms.Button btnSetupTickets;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private Label lblStats;
        private Button btnLostAndFound;
    }
}