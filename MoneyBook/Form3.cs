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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            chart1.Titles.Add("지출 분석");
            int 지출액 = DataManager.Accounts.Select((x) => x.Expense).Sum();
            int 교통비 = DataManager.Accounts.Where((x) => x.Content.Equals("교통비")).Select((x) => x.Expense).Sum();
            int 통신비 = DataManager.Accounts.Where((x) => x.Content.Equals("통신비")).Select((x) => x.Expense).Sum();
            int 식비 = DataManager.Accounts.Where((x) => x.Content.Equals("식비")).Select((x) => x.Expense).Sum();
            int 쇼핑 = DataManager.Accounts.Where((x) => x.Content.Equals("쇼핑")).Select((x) => x.Expense).Sum();
            int 기타 = 지출액 - (교통비 + 통신비 + 식비 + 쇼핑);
            //chart1.Series["s1"].IsValueShownAsLabel = true;
            chart1.Series["s1"].Points.AddXY("교통비", 교통비);
            chart1.Series["s1"].Points.AddXY("통신비", 통신비);
            chart1.Series["s1"].Points.AddXY("식비", 식비);
            chart1.Series["s1"].Points.AddXY("쇼핑", 쇼핑);
            chart1.Series["s1"].Points.AddXY("기타", 기타);

            label7.Text = 교통비.ToString();
            label8.Text = 통신비.ToString();
            label9.Text = 식비.ToString();
            label10.Text = 쇼핑.ToString();
            label11.Text = 기타.ToString();
            label12.Text = 지출액.ToString();


        }
    }
}
