using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Work_4.Models;

namespace Work_4
{
    public partial class FormMain : Form
    {
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
            SetupPanels();
        }

        public static Panel SetupPanel(in Panel panelPartners, int id, string type, string name, string director, string phoneNumber, short rating, string discount)
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
            partnerItem.TabIndex = 10;
            partnerItem.Location = new Point(10, 10 + _y);
            _y += _heigth;

            partnerItem.Controls.Add(labelInfo);
            partnerItem.Controls.Add(labelTypeAndName);
            partnerItem.Controls.Add(labelDiscount);
            partnerItem.Controls.Add(labelId);

            partnerItem.Click += ItemSelected_Click;

            return partnerItem;
        }

        private void SetupPanels()
        {
            using (Models.AppContext db = new Models.AppContext())
            {
                foreach (Partner partner in db.Partners.OrderByDescending(x => x.Id).ToList<Partner>())
                {
                    string typeOfPartner = db.TypesOfPartners
                        .Where(x => x.Id == partner.IdOfPartner)
                        .Select(x => x.TypeOfPartner)
                        .First();
                    string discount = "0";
                    int[] arrayAmountOfSold = db.FromProductsToPartners
                        .Where(x => x.IdOfPartner == partner.Id)
                        .Select(x => x.Amount)
                        .ToArray();
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

                    Panel panel = SetupPanel(
                        this.panelPartners,
                        partner.Id,
                        typeOfPartner,
                        partner.Name,
                        partner.FullnameOfDirector,
                        partner.PhoneNumber,
                        partner.Rating,
                        discount
                    );
                    panelPartners.Controls.Add(panel);
                }
            }
        }

        //Кнопки Create и Update вызывают одну форму, но в Update передается панель
        private void BttnCreate_Click(object sender, EventArgs e)
        {
            FormEntry entry = new FormEntry(ref panelPartners);
            entry.ShowDialog();

            //Обновляем список
            _y = 0;
            panelPartners.Controls.Clear();
            SetupPanels();
        }

        private void BttnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                //Перенос партнера с панели на объект
                Partner partner;
                using (Models.AppContext db = new Models.AppContext())
                {
                    int id = Int32.Parse(_selectedPanel.Controls.Find("labelId", true)[0].Text);
                    partner = db.Partners
                        .Where(x => x.Id == id)
                        .First();
                }

                //Убираем '%' от labelDiscount
                string discount = _selectedPanel.Controls.Find("labelDiscount", true)[0].Text;
                discount = discount.Substring(0, discount.Length - 1);

                FormEntry entry = new FormEntry(ref panelPartners, _selectedPanel, partner, discount);
                entry.ShowDialog();

                //Очищаем выбор
                _selectedPanel.BackColor = Color.White;
                _selectedPanel = null;

                //Обновляем список
                _y = 0;
                panelPartners.Controls.Clear();
                SetupPanels();
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
                //Удаляем запись в БД
                using (Models.AppContext db = new Models.AppContext())
                {
                    int id = Int32.Parse(_selectedPanel.Controls.Find("labelId", true)[0].Text);
                    Partner partner = db.Partners
                        .Where(x => x.Id == id)
                        .First();
                    db.Partners.Remove(partner);
                    db.SaveChanges();
                }

                //Обновляем список
                _y = 0;
                panelPartners.Controls.Clear();
                SetupPanels();
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

        private static void ItemSelected_Click(object sender, EventArgs e)
        {
            if (_selectedPanel != null)
            {
                _selectedPanel.BackColor = Color.White;
            }

            _selectedPanel = (Panel)sender;
            _selectedPanel.BackColor = SystemColors.ActiveCaption;
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
