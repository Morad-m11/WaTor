using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaTor_2
{
    public partial class Startscreen : Form
    {
        public Startscreen()
        {
            InitializeComponent();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            Hide();
            Simulation sim = new Simulation();
            sim.ShowDialog();
            Close();
        }
    }
}
