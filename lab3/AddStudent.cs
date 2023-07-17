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
    public partial class AddStudent : Form
    {

        public string LastName;
        public string FirstName;
        public string MiddleName;
        public string CodeforcesNickname;


        public AddStudent()
        {
            InitializeComponent();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            string namesPatter = "^[А-ЯЁ][а-яё]+$";
            string codeforcesPattern = "^(?=.*[A-Za-z])[A-Za-z0-9_-]+$";
           
            LastName = textBoxLastName.Text.Trim();
            FirstName = textBoxFirstName.Text.Trim();
            MiddleName = textBoxMiddleName.Text.Trim();
            CodeforcesNickname = textBoxCodeforcesNickname.Text.Trim();

            if (LastName != "")
            LastName = LastName.Substring(0, 1).ToUpper() + LastName.Substring(1).ToLower();
            if (FirstName != "")
                FirstName = FirstName.Substring(0, 1).ToUpper() + FirstName.Substring(1).ToLower();
            if (MiddleName != "")
                MiddleName = MiddleName.Substring(0, 1).ToUpper() + MiddleName.Substring(1).ToLower();


            bool isMatchLastname = Regex.IsMatch(LastName, namesPatter);
            bool isMatchFirstName = Regex.IsMatch(FirstName, namesPatter);
            bool isMatchMiddleName = Regex.IsMatch(MiddleName, namesPatter);
            bool isMatchCOdeforcesNickname = Regex.IsMatch(CodeforcesNickname, codeforcesPattern);

            if (!isMatchCOdeforcesNickname)
            {
                MessageBox.Show($"Ник студента на Codeforces не может быть {CodeforcesNickname}! Ник обязан содержать хотя бы 1 латинскую буквы и, возможно, цирф, символы '_' и '-' ");
            }
            else if (!isMatchLastname)
            {
                MessageBox.Show("Фамилия студента может быть лишь из русских букв. Минимальная длина = 2!");
            }
            else if (!isMatchFirstName)
            {
                MessageBox.Show("Имя студента может быть лишь из русских букв. Минимальная длина = 2!");
            }
            else if (!isMatchMiddleName)
            {
                MessageBox.Show("Отчество студента может быть лишь из русских букв! Минимальная длина = 2!");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
