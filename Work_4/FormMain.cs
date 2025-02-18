
using Microsoft.EntityFrameworkCore;

namespace Work_4
{
    public partial class FormMain : Form
    {
        private Models.AppContext _db;
        int _y = 0;


        public FormMain()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _db = new Models.AppContext();
            _db.Partners.Load();
            _db.FromProductsToPartners.Load();
        }

        private void BttnCreate_Click(object sender, EventArgs e)
        {
            Panel panel = InitPanel(_y, "ООО|Тмыв Денег", "Директор\n88005553535\nРейтиг:10", 1);
            panelPartners.Controls.Add(panel);
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

            Panel partnerItem = new Panel();
            partnerItem.BackColor = Color.White;
            partnerItem.Cursor = Cursors.Hand;
            partnerItem.Margin = new Padding(10);
            partnerItem.Name = "partnerItem" + id;
            partnerItem.Padding = new Padding(15, 10, 15, 10);
            partnerItem.Size = new Size(panelPartners.Width-30, 120);
            partnerItem.TabIndex = 0;
            partnerItem.Left = 10;
            partnerItem.Top = 10 + _y;
            _y += partnerItem.Height + 10;
            partnerItem.Controls.Add(labelInfo);
            partnerItem.Controls.Add(labelTypeAndName);
            partnerItem.Controls.Add(labelDiscount);
            partnerItem.Controls.Add(labelId);
            partnerItem.Click += ItemSelected_Click; 

            return partnerItem;
        }

        private void ItemSelected_Click(object sender, EventArgs e)
        { 

        }
    }
}
