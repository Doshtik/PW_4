namespace Work_4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelSettings = new Panel();
            bttnHistory = new Button();
            bttnDelete = new Button();
            bttnUpdate = new Button();
            bttnCreate = new Button();
            panelPartners = new Panel();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // panelSettings
            // 
            panelSettings.BorderStyle = BorderStyle.FixedSingle;
            panelSettings.Controls.Add(bttnHistory);
            panelSettings.Controls.Add(bttnDelete);
            panelSettings.Controls.Add(bttnUpdate);
            panelSettings.Controls.Add(bttnCreate);
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Margin = new Padding(5);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(984, 73);
            panelSettings.TabIndex = 0;
            // 
            // bttnHistory
            // 
            bttnHistory.Location = new Point(514, 11);
            bttnHistory.Margin = new Padding(10);
            bttnHistory.Name = "bttnHistory";
            bttnHistory.Size = new Size(203, 48);
            bttnHistory.TabIndex = 3;
            bttnHistory.Text = "История реализации";
            bttnHistory.UseVisualStyleBackColor = true;
            bttnHistory.Click += BttnHistory_Click;
            // 
            // bttnDelete
            // 
            bttnDelete.Location = new Point(346, 11);
            bttnDelete.Margin = new Padding(10);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(148, 48);
            bttnDelete.TabIndex = 2;
            bttnDelete.Text = "Удалить";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += BttnDelete_Click;
            // 
            // bttnUpdate
            // 
            bttnUpdate.Location = new Point(178, 11);
            bttnUpdate.Margin = new Padding(10);
            bttnUpdate.Name = "bttnUpdate";
            bttnUpdate.Size = new Size(148, 48);
            bttnUpdate.TabIndex = 1;
            bttnUpdate.Text = "Редктировать";
            bttnUpdate.UseVisualStyleBackColor = true;
            bttnUpdate.Click += BttnUpdate_Click;
            // 
            // bttnCreate
            // 
            bttnCreate.Location = new Point(10, 11);
            bttnCreate.Margin = new Padding(10);
            bttnCreate.Name = "bttnCreate";
            bttnCreate.Size = new Size(148, 48);
            bttnCreate.TabIndex = 0;
            bttnCreate.Text = "Создать";
            bttnCreate.UseVisualStyleBackColor = true;
            bttnCreate.Click += BttnCreate_Click;
            // 
            // panelPartners
            // 
            panelPartners.AutoScroll = true;
            panelPartners.BorderStyle = BorderStyle.FixedSingle;
            panelPartners.Dock = DockStyle.Fill;
            panelPartners.Location = new Point(0, 73);
            panelPartners.Name = "panelPartners";
            panelPartners.Padding = new Padding(10);
            panelPartners.Size = new Size(984, 588);
            panelPartners.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(panelPartners);
            Controls.Add(panelSettings);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            MinimumSize = new Size(750, 255);
            Name = "FormMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список партнеров";
            SizeChanged += FormMain_SizeChanged;
            panelSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelSettings;
        private Panel panelPartners;
        private Button bttnCreate;
        private Button bttnUpdate;
        private Button bttnDelete;
        private Button bttnHistory;
    }
}
