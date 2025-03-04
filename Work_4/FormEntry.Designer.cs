namespace Work_4
{
    partial class FormEntry
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
            NameTextBox = new TextBox();
            TypeLabel = new Label();
            PartnerNameLabel = new Label();
            PhoneNumberLabel = new Label();
            DirectorLabel = new Label();
            DirectorTextBox = new TextBox();
            PhoneNumberTextBox = new TextBox();
            RatingLabel = new Label();
            RatingTextBox = new TextBox();
            TINLabel = new Label();
            TINTextBox = new TextBox();
            bttnConfirm = new Button();
            TypeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(172, 45);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(226, 23);
            NameTextBox.TabIndex = 1;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(12, 15);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(101, 15);
            TypeLabel.TabIndex = 4;
            TypeLabel.Text = "Тип организации";
            // 
            // PartnerNameLabel
            // 
            PartnerNameLabel.AutoSize = true;
            PartnerNameLabel.Location = new Point(12, 48);
            PartnerNameLabel.Name = "PartnerNameLabel";
            PartnerNameLabel.Size = new Size(144, 15);
            PartnerNameLabel.TabIndex = 5;
            PartnerNameLabel.Text = "Наименование партнера";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(12, 113);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(101, 15);
            PhoneNumberLabel.TabIndex = 9;
            PhoneNumberLabel.Text = "Номер телефона";
            // 
            // DirectorLabel
            // 
            DirectorLabel.AutoSize = true;
            DirectorLabel.Location = new Point(12, 81);
            DirectorLabel.Name = "DirectorLabel";
            DirectorLabel.Size = new Size(60, 15);
            DirectorLabel.TabIndex = 8;
            DirectorLabel.Text = "Директор";
            // 
            // DirectorTextBox
            // 
            DirectorTextBox.Location = new Point(172, 78);
            DirectorTextBox.Name = "DirectorTextBox";
            DirectorTextBox.Size = new Size(226, 23);
            DirectorTextBox.TabIndex = 7;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(172, 110);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.PlaceholderText = "+7(000)000 00 00";
            PhoneNumberTextBox.Size = new Size(226, 23);
            PhoneNumberTextBox.TabIndex = 6;
            // 
            // RatingLabel
            // 
            RatingLabel.AutoSize = true;
            RatingLabel.Location = new Point(12, 145);
            RatingLabel.Name = "RatingLabel";
            RatingLabel.Size = new Size(51, 15);
            RatingLabel.TabIndex = 12;
            RatingLabel.Text = "Рейтинг";
            // 
            // RatingTextBox
            // 
            RatingTextBox.Location = new Point(172, 142);
            RatingTextBox.Name = "RatingTextBox";
            RatingTextBox.Size = new Size(56, 23);
            RatingTextBox.TabIndex = 11;
            // 
            // TINLabel
            // 
            TINLabel.AutoSize = true;
            TINLabel.Enabled = false;
            TINLabel.Location = new Point(12, 179);
            TINLabel.Name = "TINLabel";
            TINLabel.Size = new Size(34, 15);
            TINLabel.TabIndex = 15;
            TINLabel.Text = "ИНН";
            TINLabel.Visible = false;
            // 
            // TINTextBox
            // 
            TINTextBox.Enabled = false;
            TINTextBox.Location = new Point(172, 176);
            TINTextBox.Name = "TINTextBox";
            TINTextBox.Size = new Size(56, 23);
            TINTextBox.TabIndex = 14;
            TINTextBox.Visible = false;
            // 
            // bttnConfirm
            // 
            bttnConfirm.Location = new Point(12, 261);
            bttnConfirm.Name = "bttnConfirm";
            bttnConfirm.Size = new Size(473, 32);
            bttnConfirm.TabIndex = 16;
            bttnConfirm.Text = "Подтвердить";
            bttnConfirm.UseVisualStyleBackColor = true;
            bttnConfirm.Click += BttnConfirm_Click;
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Location = new Point(172, 12);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(121, 23);
            TypeComboBox.TabIndex = 17;
            TypeComboBox.TextChanged += TypeComboBox_TextChanged;
            // 
            // FormEntry
            // 
            AcceptButton = bttnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 305);
            Controls.Add(TypeComboBox);
            Controls.Add(bttnConfirm);
            Controls.Add(TINLabel);
            Controls.Add(TINTextBox);
            Controls.Add(RatingLabel);
            Controls.Add(RatingTextBox);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(DirectorLabel);
            Controls.Add(DirectorTextBox);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(PartnerNameLabel);
            Controls.Add(TypeLabel);
            Controls.Add(NameTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormEntry";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEntry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NameTextBox;
        private Label TypeLabel;
        private Label PartnerNameLabel;
        private Label PhoneNumberLabel;
        private Label DirectorLabel;
        private TextBox DirectorTextBox;
        private TextBox PhoneNumberTextBox;
        private Label RatingLabel;
        private TextBox RatingTextBox;
        private Label TINLabel;
        private TextBox TINTextBox;
        private Button bttnConfirm;
        private ComboBox TypeComboBox;
    }
}