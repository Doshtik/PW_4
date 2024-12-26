
using Microsoft.EntityFrameworkCore;

namespace Work_4
{
    public partial class FormMain : Form
    {
        private Models.AppContext _db;
        public FormMain()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _db = new Models.AppContext();
            _db.Partners.Load();
        }

        private void InitPanels(out List<Panel> panels)
        {
            panels = new List<Panel>();
        }

        private void panelPartner_Click(object sender, EventArgs e)
        {
            
        }
    }
}
