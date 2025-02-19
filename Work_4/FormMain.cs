using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Work_4
{
    public partial class FormMain : Form
    {
        private Models.AppContext _db;
        private static int _y = 0;
        private static Panel? _selectedPanel;


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

        public static Panel InitPanel(in Panel panelPartners, int id, string type, string name, string director, string phoneNumber, string rating, string discount) //, string tin
        {
            string typeAndName = String.Concat(type, "|", name);
            string info = String.Concat(director, "\n", phoneNumber, "\nРейтинг: ", rating);

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
            partnerItem.Padding = new Padding(15);
            partnerItem.Size = new Size(panelPartners.Width - 30, 120);
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

        public static List<string> GetValuesFromPanel()
        {
            return new List<string>(); //Затычка
        }

        private static void ItemSelected_Click(object sender, EventArgs e)
        {
            //Int32.Parse(((sender as Panel).Controls.Find("labelId", true)[0] as Label).Text);
            _selectedPanel = (Panel)sender;
        }

        /*Кнопки Create и Update вызывают одну форму, но в Update передается панель*/
        private void BttnCreate_Click(object sender, EventArgs e)
        {
            FormEntry entry = new FormEntry(ref panelPartners, _db);
            entry.ShowDialog();
        }

        private void BttnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                FormEntry entry = new FormEntry(ref panelPartners, _db, _selectedPanel);
                entry.ShowDialog();
            }
        }
    }
}
