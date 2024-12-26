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
            panelPartners = new Panel();
            SuspendLayout();
            // 
            // panelSettings
            // 
            panelSettings.BorderStyle = BorderStyle.FixedSingle;
            panelSettings.Dock = DockStyle.Top;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Margin = new Padding(5);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(1257, 73);
            panelSettings.TabIndex = 0;
            // 
            // panelPartners
            // 
            panelPartners.BorderStyle = BorderStyle.FixedSingle;
            panelPartners.Dock = DockStyle.Fill;
            panelPartners.Location = new Point(0, 73);
            panelPartners.Name = "panelPartners";
            panelPartners.Size = new Size(1257, 677);
            panelPartners.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 750);
            Controls.Add(panelPartners);
            Controls.Add(panelSettings);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "FormMain";
            ShowIcon = false;
            Text = "Список партнеров";
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelSettings;
        private Panel panelPartners;
    }
}
