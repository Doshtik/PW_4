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
            LegalAdressLabel = new Label();
            LegalAdressTextBox = new TextBox();
            EmailLabel = new Label();
            EmailTextBox = new TextBox();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(172, 51);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(226, 23);
            NameTextBox.TabIndex = 1;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(22, 25);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(101, 15);
            TypeLabel.TabIndex = 4;
            TypeLabel.Text = "Тип организации";
            // 
            // PartnerNameLabel
            // 
            PartnerNameLabel.AutoSize = true;
            PartnerNameLabel.Location = new Point(22, 54);
            PartnerNameLabel.Name = "PartnerNameLabel";
            PartnerNameLabel.Size = new Size(144, 15);
            PartnerNameLabel.TabIndex = 5;
            PartnerNameLabel.Text = "Наименование партнера";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(22, 170);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(101, 15);
            PhoneNumberLabel.TabIndex = 9;
            PhoneNumberLabel.Text = "Номер телефона";
            // 
            // DirectorLabel
            // 
            DirectorLabel.AutoSize = true;
            DirectorLabel.Location = new Point(22, 141);
            DirectorLabel.Name = "DirectorLabel";
            DirectorLabel.Size = new Size(91, 15);
            DirectorLabel.TabIndex = 8;
            DirectorLabel.Text = "Имя директора";
            // 
            // DirectorTextBox
            // 
            DirectorTextBox.Location = new Point(172, 138);
            DirectorTextBox.Name = "DirectorTextBox";
            DirectorTextBox.Size = new Size(226, 23);
            DirectorTextBox.TabIndex = 7;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(172, 167);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.PlaceholderText = "0000000000";
            PhoneNumberTextBox.Size = new Size(226, 23);
            PhoneNumberTextBox.TabIndex = 6;
            // 
            // RatingLabel
            // 
            RatingLabel.AutoSize = true;
            RatingLabel.Location = new Point(22, 228);
            RatingLabel.Name = "RatingLabel";
            RatingLabel.Size = new Size(51, 15);
            RatingLabel.TabIndex = 12;
            RatingLabel.Text = "Рейтинг";
            // 
            // RatingTextBox
            // 
            RatingTextBox.Location = new Point(172, 225);
            RatingTextBox.Name = "RatingTextBox";
            RatingTextBox.Size = new Size(56, 23);
            RatingTextBox.TabIndex = 11;
            // 
            // TINLabel
            // 
            TINLabel.AutoSize = true;
            TINLabel.Location = new Point(22, 112);
            TINLabel.Name = "TINLabel";
            TINLabel.Size = new Size(34, 15);
            TINLabel.TabIndex = 15;
            TINLabel.Text = "ИНН";
            // 
            // TINTextBox
            // 
            TINTextBox.Location = new Point(172, 109);
            TINTextBox.Name = "TINTextBox";
            TINTextBox.Size = new Size(226, 23);
            TINTextBox.TabIndex = 14;
            // 
            // bttnConfirm
            // 
            bttnConfirm.Dock = DockStyle.Bottom;
            bttnConfirm.Location = new Point(10, 261);
            bttnConfirm.Margin = new Padding(0);
            bttnConfirm.Name = "bttnConfirm";
            bttnConfirm.Size = new Size(479, 32);
            bttnConfirm.TabIndex = 16;
            bttnConfirm.Text = "Подтвердить";
            bttnConfirm.UseVisualStyleBackColor = true;
            bttnConfirm.Click += BttnConfirm_Click;
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Location = new Point(172, 22);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(121, 23);
            TypeComboBox.TabIndex = 17;
            TypeComboBox.TextChanged += TypeComboBox_TextChanged;
            // 
            // LegalAdressLabel
            // 
            LegalAdressLabel.AutoSize = true;
            LegalAdressLabel.Location = new Point(22, 83);
            LegalAdressLabel.Name = "LegalAdressLabel";
            LegalAdressLabel.Size = new Size(119, 15);
            LegalAdressLabel.TabIndex = 19;
            LegalAdressLabel.Text = "Юридический адрес";
            // 
            // LegalAdressTextBox
            // 
            LegalAdressTextBox.Location = new Point(172, 80);
            LegalAdressTextBox.Name = "LegalAdressTextBox";
            LegalAdressTextBox.Size = new Size(226, 23);
            LegalAdressTextBox.TabIndex = 18;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(22, 199);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 22;
            EmailLabel.Text = "Email";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(172, 196);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(226, 23);
            EmailTextBox.TabIndex = 21;
            // 
            // FormEntry
            // 
            AcceptButton = bttnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 303);
            Controls.Add(EmailLabel);
            Controls.Add(EmailTextBox);
            Controls.Add(LegalAdressLabel);
            Controls.Add(LegalAdressTextBox);
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
            Padding = new Padding(10);
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
        private Label LegalAdressLabel;
        private TextBox LegalAdressTextBox;
        private Label EmailLabel;
        private TextBox EmailTextBox;
    }
}