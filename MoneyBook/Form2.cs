using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyBook
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = DataManager.Accounts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("날짜를 다시 입력해주세요.");
            }
            else
            {
                var account = from accounts in DataManager.Accounts
                              where accounts.Content == textBox1.Text && DateTime.Parse(accounts.Date) >= dateTimePicker1.Value && DateTime.Parse(accounts.Date) <= dateTimePicker2.Value
                              orderby accounts.Date
                              select accounts;

                dataGridView1.DataSource = account.ToList();
            }
        }
    }
}
