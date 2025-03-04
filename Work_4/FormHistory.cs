using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Work_4.Models;

namespace Work_4
{
    public partial class FormHistory : Form
    {
        private int _y = 0;
        private int _idOfPartner;

        public FormHistory(int id)
        {
            InitializeComponent();
            _idOfPartner = id;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            using (Models.AppContext db = new Models.AppContext())
            {
                foreach (FromProductsToPartner entry in db.FromProductsToPartners.Where(x => x.Id == _idOfPartner).ToList())
                {
                    panelHistory.Controls.Add(InitHistoryPanel(entry));
                }
            }
        }

        private Panel InitHistoryPanel(FromProductsToPartner entry)
        {
            return new Panel();
        }
    }
}
