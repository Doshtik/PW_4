using System.Windows.Forms;
using Work_4.Models;

namespace Work_4
{
    public partial class FormEntry : Form
    {
        private Partner? _partner;
        private Panel _panelPartners;
        private Panel? _selectedPanel;
        private int _selectedTypeIndex;
        private string _discount = "0";


        public FormEntry(ref Panel panelPartners)
        {
            InitializeComponent();
            InitTypes();
            _panelPartners = panelPartners;
        }
        public FormEntry(ref Panel panelPartners, Panel panel, Partner partner, string discount)
        {
            InitializeComponent();
            InitTypes();

            _partner = partner;
            _panelPartners = panelPartners;
            _selectedPanel = panel;
            _discount = discount;

            NameTextBox.Text = _partner.Name;
            LegalAdressTextBox.Text = _partner.LegalAdress;
            TINTextBox.Text = _partner.Tin;
            DirectorTextBox.Text = _partner.FullnameOfDirector;
            PhoneNumberTextBox.Text = _partner.PhoneNumber;
            EmailTextBox.Text = _partner.Email;
            RatingTextBox.Text = _partner.Rating.ToString();
        }

        private void InitTypes()
        {
            using (Models.AppContext db = new Models.AppContext())
            {
                List<TypesOfPartner> partnerTypes = db.TypesOfPartners.OrderBy(o => o.Id).ToList();
                TypeComboBox.DataSource = partnerTypes;
                TypeComboBox.DisplayMember = "TypeOfPartner";
                TypeComboBox.ValueMember = "Id";
            }
        }

        /*
        * При нажатии кнопки Подтвердить делаем проверку на нул у _panel и 
        * если != то обновляем запись и панель в главной форме 
        * иначе создаем новую запись и с помощью InitPanels добавляем панель в главую форму 
        */
        private void BttnConfirm_Click(object sender, EventArgs e)
        {
            if (_partner != null)
            {
                
                try
                {
                    Panel panel;
                    // Здесь будет update записи с помощью _db
                    using (Models.AppContext db = new Models.AppContext())
                    {
                        //Работа с типом партнера
                        string typePartner = db.TypesOfPartners.Where(x => x.Id == _selectedTypeIndex).Select(x => x.TypeOfPartner).First();

                        //Работа с БД
                        Partner partner = new Partner(_selectedTypeIndex, NameTextBox.Text, LegalAdressTextBox.Text, TINTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, EmailTextBox.Text, Int16.Parse(RatingTextBox.Text));
                        db.Partners.Add(partner);
                        db.SaveChanges();

                        //Переиницализация панели
                        panel = FormMain.InitPanel(_panelPartners, _partner.Id, typePartner, NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), _discount);
                    }
                    panel.Location = _selectedPanel.Location;

                    _panelPartners.Controls.Remove(_selectedPanel);
                    _panelPartners.Controls.Add(panel);
                }
                catch
                {
                    MessageBox.Show("Не удалось обновить запись");
                }
            }
            else
            {
                try
                {
                    Panel panel;
                    // Здесь будет create записи с помощью _db
                    using (Models.AppContext db = new Models.AppContext())
                    {
                        //Работа с БД
                        Partner partner = new Partner(_selectedTypeIndex, NameTextBox.Text, LegalAdressTextBox.Text, TINTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, EmailTextBox.Text ,Int16.Parse(RatingTextBox.Text));
                        db.Partners.Add(partner);
                        db.SaveChanges();

                        //Иницализация панели
                        panel = FormMain.InitPanel(_panelPartners, 1, db.TypesOfPartners.Where(x => x.Id == _selectedTypeIndex).Select(x => x.TypeOfPartner).FirstOrDefault(), NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), "0");
                    }
                    _panelPartners.Controls.Add(panel);
                }
                catch
                {
                    MessageBox.Show("Не удалось создать запись");
                }
            }
            this.Close();
        }

        private void TypeComboBox_TextChanged(object sender, EventArgs e)
        {
            _selectedTypeIndex = TypeComboBox.SelectedIndex+1; 
            //TypeComboBox начинает отсчёт от 0, а Id в БД начинаются с 1
            //(Вероятно, что если в БД порядок изменится, то всё сломается)
        }
    }
}
