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
    public partial class AddGroup : Form
    {

        public string newNameGroup;


        public AddGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupNamePattern = @"^(ПИ|РИС|БИ)-(19|20|21|22)-[1-4]$";
            textBox1.Text = textBox1.Text.Trim();

            bool isMatch = Regex.IsMatch(textBox1.Text, groupNamePattern);
            if (!isMatch)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Вы ничего не ввели!");
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Неверный ввод группы! Пример вверного ввода: ПИ-21-1! Доступные группы: ПИ,БИ,РИС; доступные года - 19,20,21,22; доступные подгруппы - 1,2,3,4!");
                }
            }
            else
            {
                newNameGroup = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
