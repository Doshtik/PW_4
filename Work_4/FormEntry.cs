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
            SetupTypes();
            _panelPartners = panelPartners;
        }
        public FormEntry(ref Panel panelPartners, Panel selectedPanel, Partner partner, string discount)
        {
            InitializeComponent();

            _partner = partner;
            _panelPartners = panelPartners;
            _selectedPanel = selectedPanel;
            _discount = discount;

            SetupTypes();
            NameTextBox.Text = _partner.Name;
            LegalAdressTextBox.Text = _partner.LegalAdress;
            TINTextBox.Text = _partner.Tin;
            DirectorTextBox.Text = _partner.FullnameOfDirector;
            PhoneNumberTextBox.Text = _partner.PhoneNumber;
            EmailTextBox.Text = _partner.Email;
            RatingTextBox.Text = _partner.Rating.ToString();
        }

        private void SetupTypes()
        {
            using (Models.AppContext db = new Models.AppContext())
            {
                List<TypesOfPartner> partnerTypes = db.TypesOfPartners.OrderBy(o => o.Id).ToList();
                TypeComboBox.DataSource = partnerTypes;
                TypeComboBox.DisplayMember = "TypeOfPartner";
                TypeComboBox.ValueMember = "Id";
                if (_selectedPanel != null)
                {
                    string labelTypeAndName = _selectedPanel.Controls.Find("labelTypeAndName", true)[0].Text;
                    string typeName = labelTypeAndName.Split('|')[0];
                    int typeIndex = db.TypesOfPartners
                        .OrderBy(x => x.Id)
                        .Where(x => x.TypeOfPartner == typeName)
                        .Select(x => x.Id)
                        .First();
                    TypeComboBox.SelectedIndex = typeIndex-1;
                }
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
                        string typeOfPartner = db.TypesOfPartners
                            .Where(x => x.Id == _selectedTypeIndex)
                            .Select(x => x.TypeOfPartner)
                            .First();

                        //Работа с БД
                        Partner dbPartner = db.Partners.First(x => x.Id == _partner.Id);

                        dbPartner.IdOfPartner = _selectedTypeIndex;
                        dbPartner.Name = NameTextBox.Text;
                        dbPartner.LegalAdress = LegalAdressTextBox.Text;
                        dbPartner.Tin = TINTextBox.Text;
                        dbPartner.FullnameOfDirector = DirectorTextBox.Text;
                        dbPartner.PhoneNumber = PhoneNumberTextBox.Text;
                        dbPartner.Email = EmailTextBox.Text;
                        dbPartner.Rating = Int16.Parse(RatingTextBox.Text);
                        
                        db.SaveChanges();

                        //Переиницализация панели
                        panel = FormMain.SetupPanel(
                            _panelPartners, 
                            _partner.Id, 
                            typeOfPartner, 
                            NameTextBox.Text, 
                            DirectorTextBox.Text, 
                            PhoneNumberTextBox.Text, 
                            Int16.Parse(RatingTextBox.Text), 
                            _discount
                        );
                    }
                    panel.Location = _selectedPanel.Location;
                    _panelPartners.Controls.Add(panel);
                    _panelPartners.Controls.Remove(_selectedPanel);
                    
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
                        string typeOfPartner = db.TypesOfPartners
                            .Where(x => x.Id == _selectedTypeIndex)
                            .Select(x => x.TypeOfPartner)
                            .First();

                        //Работа с БД
                        Partner partner = new Partner();

                        partner.Id = db.Partners.OrderByDescending(x => x.Id).Select(x => x.Id).First()+1; //Очень противный костыль, но без него не работает
                        partner.IdOfPartner = _selectedTypeIndex;
                        partner.Name = NameTextBox.Text;
                        partner.LegalAdress = LegalAdressTextBox.Text;
                        partner.Tin = TINTextBox.Text;
                        partner.FullnameOfDirector = DirectorTextBox.Text;
                        partner.PhoneNumber = PhoneNumberTextBox.Text;
                        partner.Email = EmailTextBox.Text;
                        partner.Rating = Int16.Parse(RatingTextBox.Text);

                        db.Partners.Add(partner);
                        db.SaveChanges();

                        //Иницализация панели
                        int idOfPartner = db.Partners
                            .Where(x => x.Tin == partner.Tin)
                            .Select(x => x.Id)
                            .First();

                        panel = FormMain.SetupPanel(
                            _panelPartners, 
                            idOfPartner, 
                            typeOfPartner, 
                            NameTextBox.Text, 
                            DirectorTextBox.Text, 
                            PhoneNumberTextBox.Text, 
                            Int16.Parse(RatingTextBox.Text), 
                            "0"
                        );
                    }
                    _panelPartners.Controls.Add(panel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось создать запись:" +
                        $"\n{ex.Message}");
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
