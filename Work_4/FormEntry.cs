using System.Windows.Forms;

namespace Work_4
{
    public partial class FormEntry : Form
    {
        private Panel? _panel;
        private Panel _panelPartners;

        public FormEntry(ref Panel panelPartners, Models.AppContext db)
        {
            InitializeComponent();
            _panelPartners = panelPartners;
        }
        public FormEntry(ref Panel panelPartners, Models.AppContext db, Panel panel)
        {
            InitializeComponent();
            _panelPartners = panelPartners;
            _panel = panel;
            //Здесь текстбоксы принимают значения полей с помощью метода GetValuesFromPanel()
        }

        private void BttnConfirm_Click(object sender, EventArgs e)
        {
            if (_panel != null)
            {
                Panel panel = FormMain.InitPanel(_panelPartners, TypeTextBox.Text, NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), DiscountTextBox.Text);
                // Здесь будет update записи с помощью _db
                _panelPartners.Controls.Remove(_panel);
                _panelPartners.Controls.Add(panel);
            }
            else
            {
                Panel panel = FormMain.InitPanel(_panelPartners, TypeTextBox.Text, NameTextBox.Text, DirectorTextBox.Text, PhoneNumberTextBox.Text, Int16.Parse(RatingTextBox.Text), DiscountTextBox.Text);
                // Здесь будет create записи с помощью _db
                _panelPartners.Controls.Add(panel);
            }
            
            /*
             * При нажатии кнопки Подтвердить делаем проверку на нул у _panel и 
             * если != то обновляем запись и панель в главной форме 
             * иначе создаем новую запись и с помощью InitPanels добавляем панель в главую форму 
             */
        }
    }
}
