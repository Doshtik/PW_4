using System.Windows.Forms;
using Work_4.Models;

namespace Work_4
{
    public partial class FormEntry : Form
    {
        private Panel? _panel;
        private Panel _panelPartners;
        private int selectedIndex;

        public FormEntry(ref Panel panelPartners)
        {
            InitializeComponent();
            _panelPartners = panelPartners;
            //TODO: для create сделать доп поля и убирать видимость, если update
        }
        public FormEntry(ref Panel panelPartners, Panel panel)
        {
            InitializeComponent();
            _panelPartners = panelPartners;
            _panel = panel;

            //Здесь текстбоксы принимают значения полей с помощью метода GetValuesFromPanel()
            List<string> values = FormMain.GetValuesFromPanel(panel);
            using (Models.AppContext db = new Models.AppContext())
            {
                List<TypesOfPartner> partnerTypes = db.TypesOfPartners.Local.OrderBy(o => o.TypeOfPartner).ToList();
                TypeComboBox.DataSource = partnerTypes;
                TypeComboBox.DisplayMember = "TypeOfPartner";
                TypeComboBox.ValueMember = "Id";
                selectedIndex = Convert.ToInt32(values[0]);
                //TODO: Исправить
                //TypeComboBox.SelectedIndex = selectedIndex;
            }
            NameTextBox.Text = values[1];
            DirectorTextBox.Text = values[2];
            PhoneNumberTextBox.Text = values[3];
            RatingTextBox.Text = values[4];
        }

        private Partner GetPartner(int partnerId)
        {
            Partner partner = new Partner();
            partner.Id = partnerId;
            return new Partner();
        }

        /*
        * При нажатии кнопки Подтвердить делаем проверку на нул у _panel и 
        * если != то обновляем запись и панель в главной форме 
        * иначе создаем новую запись и с помощью InitPanels добавляем панель в главую форму 
        */
        private void BttnConfirm_Click(object sender, EventArgs e)
        {
            if (_panel != null)
            {
                Panel panel;
                // Здесь будет update записи с помощью _db
                using (Models.AppContext db = new Models.AppContext())
                {
                    string discount = _panel.Controls.Find("labelDiscount", true)[0].Text;
                    discount = discount.Substring(0, discount.Length-1);
                    panel = FormMain.InitPanel(_panelPartners, 1, db.TypesOfPartners.Where(x => x.Id == selectedIndex).Select(x => x.TypeOfPartner).FirstOrDefault(), NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), discount);
                    db.SaveChanges();
                }
                Point location = _panel.Location;
                panel.Location = location;
                _panelPartners.Controls.Remove(_panel);
                _panelPartners.Controls.Add(panel);
            }
            else
            {
                Panel panel;
                // Здесь будет create записи с помощью _db
                using (Models.AppContext db = new Models.AppContext())
                {
                    panel = FormMain.InitPanel(_panelPartners, 1, db.TypesOfPartners.Where(x => x.Id == selectedIndex).Select(x => x.TypeOfPartner).FirstOrDefault(), NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), "0");
                    db.SaveChanges();
                }
                _panelPartners.Controls.Add(panel);
            }
            this.Close();
        }

        private void TypeComboBox_TextChanged(object sender, EventArgs e)
        {
            selectedIndex = TypeComboBox.SelectedIndex;
        }
    }
}
