﻿namespace Work_4
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
            SuspendLayout();
            // 
            // panelHistory
            // 
            panelHistory.Dock = DockStyle.Fill;
            panelHistory.Location = new Point(0, 0);
            panelHistory.Name = "panelHistory";
            panelHistory.Padding = new Padding(10);
            panelHistory.Size = new Size(800, 450);
            panelHistory.TabIndex = 0;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHistory;
    }
}