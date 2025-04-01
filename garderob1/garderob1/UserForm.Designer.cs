namespace garderob1
{
    partial class UserForm
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
            btnTakeTicket = new Button();
            btnReturnTicket = new Button();
            lblTicket = new Label();
            btnLostAndFound = new Button();
            SuspendLayout();
            // 
            // btnTakeTicket
            // 
            btnTakeTicket.Location = new Point(13, 12);
            btnTakeTicket.Margin = new Padding(4, 3, 4, 3);
            btnTakeTicket.Name = "btnTakeTicket";
            btnTakeTicket.Size = new Size(175, 46);
            btnTakeTicket.TabIndex = 0;
            btnTakeTicket.Text = "Получить номерок";
            btnTakeTicket.UseVisualStyleBackColor = true;
            btnTakeTicket.Click += btnTakeTicket_Click;
            // 
            // btnReturnTicket
            // 
            btnReturnTicket.Location = new Point(13, 12);
            btnReturnTicket.Margin = new Padding(4, 3, 4, 3);
            btnReturnTicket.Name = "btnReturnTicket";
            btnReturnTicket.Size = new Size(175, 46);
            btnReturnTicket.TabIndex = 1;
            btnReturnTicket.Text = "Вернуть номерок";
            btnReturnTicket.UseVisualStyleBackColor = true;
            btnReturnTicket.Click += btnReturnTicket_Click;
            // 
            // lblTicket
            // 
            lblTicket.AutoSize = true;
            lblTicket.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTicket.Location = new Point(13, 71);
            lblTicket.Margin = new Padding(4, 0, 4, 0);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(118, 20);
            lblTicket.TabIndex = 2;
            lblTicket.Text = "Ваш номерок: ";
            // 
            // btnLostAndFound
            // 
            btnLostAndFound.Location = new Point(13, 288);
            btnLostAndFound.Margin = new Padding(4, 3, 4, 3);
            btnLostAndFound.Name = "btnLostAndFound";
            btnLostAndFound.Size = new Size(175, 46);
            btnLostAndFound.TabIndex = 3;
            btnLostAndFound.Text = "Бюро находок";
            btnLostAndFound.UseVisualStyleBackColor = true;
            btnLostAndFound.Click += btnLostAndFound_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(212, 346);
            Controls.Add(btnLostAndFound);
            Controls.Add(lblTicket);
            Controls.Add(btnReturnTicket);
            Controls.Add(btnTakeTicket);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UserForm";
            Text = "Окно пользователя";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTakeTicket;
        private System.Windows.Forms.Button btnReturnTicket;
        private System.Windows.Forms.Label lblTicket;
        private Button btnLostAndFound;
    }
}