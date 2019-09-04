using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class Menu : Form
    {
        JeuZoo form1 = new JeuZoo();
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCommencer_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }
    }
}
