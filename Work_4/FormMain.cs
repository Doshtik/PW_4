
using Microsoft.EntityFrameworkCore;

namespace Work_4
{
    public partial class FormMain : Form
    {
        private Models.AppContext _db;
        private List<PartnerPanel> _partnerPanels;

        public FormMain()
        {
            InitializeComponent();
            _partnerPanels = InitPanels();
            int i = 0;
            while (true)
            {
                try
                {
                    panelPartners.Controls.Add(_partnerPanels[i++]);
                }
                catch
                {
                    break;
                }
            }
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _db = new Models.AppContext();
            _db.Partners.Load();
            _db.FromProductsToPartners.Load();
        }

        private List<PartnerPanel> InitPanels()
        {
            List<PartnerPanel> panels = new List<PartnerPanel>();

            for (int i = 0; i < 5; i++)
            {
                panels.Add(new PartnerPanel(1, "qwe", "qwe", 12));
            }
            return panels;
        }
    }
}
