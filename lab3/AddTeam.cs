using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class AddTeam : Form
    {
        public string teamName;
        public AddTeam()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            teamName = textBox1.Text.Trim();

            if (teamName == "")
            {
                MessageBox.Show("Название команды не может быть пустым!");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
