using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Work_4.Models;

namespace Work_4
{
    public partial class FormMain : Form
    {
        private Models.AppContext _db;
        private static int _y = 0;
        private static int _heigth = 130;
        private static Panel? _selectedPanel;


        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _db = new Models.AppContext();

            //Подключаем необходимые таблицы
            _db.TypesOfPartners.Load();
            _db.Partners.Load();
            _db.FromProductsToPartners.Load();

            foreach (Partner partner in _db.Partners.ToList<Partner>())
            {
                string typeOfPartner = _db.TypesOfPartners.Where(x => x.Id == partner.IdOfPartner).Select(x => x.TypeOfPartner).FirstOrDefault();
                string discount = "0";
                int[] arrayAmountOfSold = _db.FromProductsToPartners.Where(x => x.IdOfPartner == partner.Id).Select(x => x.Amount).ToArray();
                int amountOfSold = 0;

                for (int i = 0; i < arrayAmountOfSold.Length; i++)
                {
                    amountOfSold += arrayAmountOfSold[i];
                }

                if (amountOfSold < 10000)
                    discount = "0";
                else if (amountOfSold >= 10000 && amountOfSold < 50000)
                    discount = "5";
                else if (amountOfSold >= 50000 && amountOfSold < 300000)
                    discount = "10";
                else
                    discount = "15";

                Panel panel = InitPanel(this.panelPartners, partner.Id, typeOfPartner, partner.Name, partner.FullnameOfDirector, partner.PhoneNumber, partner.Rating, discount);
                panelPartners.Controls.Add(panel);
            }
        }

        public static Panel InitPanel(in Panel panelPartners, int id, string type, string name, string director, string phoneNumber, short rating, string discount)
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
            labelId.Visible = false;
            labelId.Name = "labelId";
            labelId.TabIndex = 4;
            labelId.Text = id.ToString();

            Panel partnerItem = new Panel();
            partnerItem.BackColor = Color.White;
            partnerItem.Cursor = Cursors.Hand;
            partnerItem.Margin = new Padding(10);
            partnerItem.Name = "partnerItem";
            partnerItem.Padding = new Padding(15);
            partnerItem.Size = new Size(panelPartners.Width - 40, 120);
            partnerItem.TabIndex = 0;
            partnerItem.Left = 10;
            partnerItem.Top = 10 + _y;
            _y += _heigth;

            partnerItem.Controls.Add(labelInfo);
            partnerItem.Controls.Add(labelTypeAndName);
            partnerItem.Controls.Add(labelDiscount);
            partnerItem.Controls.Add(labelId);

            partnerItem.Click += ItemSelected_Click;

            return partnerItem;
        }

        public static List<string> GetValuesFromPanel(Panel panel)
        {
            List<string> values = new List<string>();

            string[] value = panel.Controls.Find("labelTypeAndName", true)[0].Text.Trim().Split('|');
            using (Models.AppContext db = new Models.AppContext())
            {
                string index = db.TypesOfPartners.Where(x => x.TypeOfPartner == value[0]).Select(x => x.Id).FirstOrDefault().ToString();
                values.Add(index);
            }
            values.Add(value[1]);

            value = panel.Controls.Find("labelInfo", true)[0].Text.Trim().Split('\n');
            value[2] = value[2].Substring(9);
            values.AddRange(value);

            values.Add(panel.Controls.Find("labelDiscount", true)[0].Text.Substring(0, 1));
            values.Add(panel.Controls.Find("labelId", true)[0].Text);
            return values;
        }

        private static void ItemSelected_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                _selectedPanel.BackColor = Color.White;
            }

            _selectedPanel = (Panel)sender;
            _selectedPanel.BackColor = SystemColors.ActiveCaption;
        }

        //Кнопки Create и Update вызывают одну форму, но в Update передается панель
        private void BttnCreate_Click(object sender, EventArgs e)
        {
            FormEntry entry = new FormEntry(ref panelPartners);
            entry.ShowDialog();
        }

        private void BttnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                FormEntry entry = new FormEntry(ref panelPartners, _selectedPanel);
                entry.ShowDialog();

                _selectedPanel.BackColor = Color.White;
                _selectedPanel = null;
            }
            else
            {
                MessageBox.Show("Партнер не выбран");
            }
        }

        private void BttnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                foreach (Panel panel in panelPartners.Controls.Find("partnerItem", true))
                {
                    /*MessageBox.Show($"Y = {panel.Location.Y}\n" +
                                    $"panel.{panel.Location.Y} > _selectedPanel.{_selectedPanel.Location.Y}");*/
                    if (panel.Location.Y > _selectedPanel.Location.Y)
                    {
                        Point location = panel.Location;
                        location.Y -= _heigth;
                        panel.Location = location;
                    }
                }
                panelPartners.Controls.Remove(_selectedPanel);
            }
            else
            {
                MessageBox.Show("Партнер не выбран");
            }
        }

        private void BttnHistory_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                FormHistory entry = new FormHistory(Int32.Parse(_selectedPanel.Controls.Find("labelId", true)[0].Text));
                entry.ShowDialog();
            }
            else
            {
                MessageBox.Show("Партнер не выбран");
            }
        }

        //Должен подгонять длину панелек под длину 
        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            foreach (Panel panel in panelPartners.Controls.Find("partnerItem", true))
            {
                panel.Width = panelPartners.Width - 40;
            }
        }
    }
}
