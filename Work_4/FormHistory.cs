using Microsoft.EntityFrameworkCore;
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
                DGVHistory.DataSource = db.FromProductsToPartners
                    .Include(i => i.Product)
                    .Select(i=> new { i.Product.Name, i.Amount, i.DateOfSelling, i.IdOfPartner })
                    .Where(x => x.IdOfPartner == _idOfPartner)                    
                    .ToList();
            }
            DGVHistory.Columns["IdOfPartner"].Visible = false;
        }
    }
}
