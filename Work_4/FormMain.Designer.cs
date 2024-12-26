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
            panelMain = new Panel();
            panelPartner = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelMain.SuspendLayout();
            panelPartner.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelPartner);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(10);
            panelMain.Size = new Size(800, 450);
            panelMain.TabIndex = 0;
            // 
            // panelPartner
            // 
            panelPartner.BackColor = Color.White;
            panelPartner.Controls.Add(label3);
            panelPartner.Controls.Add(label2);
            panelPartner.Controls.Add(label1);
            panelPartner.Cursor = Cursors.Hand;
            panelPartner.Dock = DockStyle.Top;
            panelPartner.Location = new Point(10, 10);
            panelPartner.Name = "panelPartner";
            panelPartner.Padding = new Padding(15, 10, 15, 10);
            panelPartner.Size = new Size(780, 112);
            panelPartner.TabIndex = 0;
            panelPartner.Click += panelPartner_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(15, 35);
            label3.Name = "label3";
            label3.Size = new Size(136, 63);
            label3.TabIndex = 3;
            label3.Text = "Директор\r\n+7 000 111 22 33\r\nРейтинг: 10";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label2.Location = new Point(15, 10);
            label2.Name = "label2";
            label2.Size = new Size(286, 25);
            label2.TabIndex = 2;
            label2.Text = "Тип | Наименование компании";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(717, 10);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 1;
            label1.Text = "10%";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Name = "FormMain";
            ShowIcon = false;
            Text = "Список партнеров";
            panelMain.ResumeLayout(false);
            panelPartner.ResumeLayout(false);
            panelPartner.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelPartner;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}
