using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace Work_4
{
    public class PartnerPanel : Panel
    {
        public bool IsSelected { get; set; } = false;
        private Panel _panelPartner;

        public PartnerPanel(int id, string typeAndName, string info, int discount)
        {
            _panelPartner = InitPanel(id, typeAndName, info, discount);

        }
        private Panel InitPanel(int id, string typeAndName, string info, int discount)
        {        
            Label labelDiscount = new Label();
            labelDiscount.AutoSize = true;
            labelDiscount.Dock = DockStyle.Right;
            labelDiscount.Font = new Font("Segoe UI", 14F);
            labelDiscount.Name = "labelDiscount";
            labelDiscount.Size = new Size(48, 25);
            labelDiscount.TabIndex = 1;
            labelDiscount.Text = $"{discount}%";
            
            Label labelTypeAndName = new Label();
            labelTypeAndName.AutoSize = true;
            labelTypeAndName.Dock = DockStyle.Top;
            labelTypeAndName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            labelTypeAndName.Name = "labelTypeAndName";
            labelTypeAndName.Size = new Size(286, 25);
            labelTypeAndName.TabIndex = 2;
            labelTypeAndName.Text = typeAndName;
            
            Label labelInfo = new Label();
            labelInfo.AutoSize = true;
            labelInfo.Dock = DockStyle.Left;
            labelInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(136, 63);
            labelInfo.TabIndex = 3;
            labelInfo.Text = info;

            Label labelId = new Label();
            labelId.Name = "labelId";
            labelId.Text = id.ToString();
            labelId.Visible = false;

            Panel panelPartner = new Panel();
            panelPartner.BackColor = Color.White;
            panelPartner.Cursor = Cursors.Hand;
            panelPartner.Dock = DockStyle.Top;
            panelPartner.Margin = new Padding(10);
            panelPartner.Name = "panelPartner";
            panelPartner.Padding = new Padding(15, 10, 15, 10);
            panelPartner.Size = new Size(780, 112);
            panelPartner.TabIndex = 0;
            panelPartner.Controls.Add(labelInfo);
            panelPartner.Controls.Add(labelTypeAndName);
            panelPartner.Controls.Add(labelDiscount);
            panelPartner.Controls.Add(labelId);
            panelPartner.Click += panelPartner_Click;

            return panelPartner;
        }

        private void panelPartner_Click(object sender, EventArgs e)
        {

        }
    }
}
