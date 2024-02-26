using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sifas_Amortisman
{
    public partial class ilkForm : Form
    {
        public ilkForm()
        {
            InitializeComponent();
        }

        public AnaForm anaFrm
        {
            get;
            set;
        }

        private void ilkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
