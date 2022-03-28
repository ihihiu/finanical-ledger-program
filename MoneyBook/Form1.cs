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
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            var acc = from accounts in DataManager.Accounts
                      orderby accounts.Date
                      select accounts;
            dataGridView1.DataSource = acc.ToList();
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            label7.Text = DataManager.Accounts.Select((x) => x.Income).Sum().ToString();
            label9.Text = DataManager.Accounts.Select((x) => x.Expense).Sum().ToString();
            label11.Text = (int.Parse(label7.Text) - int.Parse(label9.Text)).ToString();

          


        }

    private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Account account = dataGridView1.CurrentRow.DataBoundItem as Account;

                dateTimePicker1.Text = account.Date;
                textBox1.Text = account.Content;
                textBox2.Text = account.Income.ToString();
                textBox3.Text = account.Expense.ToString();
                textBox4.Text = account.Memo;


            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                if (dateTimePicker1.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("내용을 입력해주세요.");
                }
                else
                {
                    Account account = new Account()
                    {
                        Date = dateTimePicker1.Text,
                        Content = textBox1.Text,
                        Income = int.Parse(textBox2.Text),
                        Expense = int.Parse(textBox3.Text),
                        Memo = textBox4.Text
                    };

                    DataManager.Accounts.Add(account);
                    dataGridView1.DataSource = null;
                    var acc = from accounts in DataManager.Accounts
                                                orderby accounts.Date
                                                select accounts;
                    dataGridView1.DataSource = acc.ToList();

                    label7.Text = (account.Income + int.Parse(label7.Text)).ToString();
                    label9.Text = (account.Expense + int.Parse(label9.Text)).ToString();
                    label11.Text = (int.Parse(label11.Text) + account.Income - account.Expense).ToString();
                    DataManager.Save();

                }

            }
            catch (Exception ex)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Account account = dataGridView1.CurrentRow.DataBoundItem as Account;
                DataManager.Accounts.Remove(account);
                dataGridView1.DataSource = null;
                var acc = from accounts in DataManager.Accounts
                          orderby accounts.Date
                          select accounts;
                dataGridView1.DataSource = acc.ToList();
                
                label7.Text = (int.Parse(label7.Text) - account.Income).ToString();
                label9.Text = (int.Parse(label9.Text) - account.Expense).ToString();
                label11.Text = (int.Parse(label11.Text) - account.Income + account.Expense).ToString();
                DataManager.Save();

            }
            catch (Exception ex)
            {

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();

        }
    }
}
