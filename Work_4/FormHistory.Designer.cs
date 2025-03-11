namespace Work_4
{
    partial class FormHistory
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
            panelHistory = new Panel();
            DGVHistory = new DataGridView();
            panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVHistory).BeginInit();
            SuspendLayout();
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(DGVHistory);
            panelHistory.Dock = DockStyle.Fill;
            panelHistory.Location = new Point(0, 0);
            panelHistory.Name = "panelHistory";
            panelHistory.Padding = new Padding(10);
            panelHistory.Size = new Size(800, 450);
            panelHistory.TabIndex = 0;
            // 
            // DGVHistory
            // 
            DGVHistory.BackgroundColor = Color.White;
            DGVHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVHistory.Dock = DockStyle.Fill;
            DGVHistory.Location = new Point(10, 10);
            DGVHistory.Name = "DGVHistory";
            DGVHistory.Size = new Size(780, 430);
            DGVHistory.TabIndex = 0;
            // 
            // FormHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHistory);
            Name = "FormHistory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormHistory";
            panelHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHistory;
        private DataGridView DGVHistory;
    }
}