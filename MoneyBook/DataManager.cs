using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoneyBook
{
    class DataManager
    {
        public static List<Account> Accounts = new List<Account>();

        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string accountsOutput = File.ReadAllText(@"./Accounts.xml");
                XElement accountsElement = XElement.Parse(accountsOutput);
                Accounts = (from item in accountsElement.Descendants("account")
                            select new Account()
                            {
                                //Date = DateTime.Parse(item.Element("date").Value),
                                Date =item.Element("date").Value,
                                Content = item.Element("content").Value,
                                Income = int.Parse(item.Element("income").Value),
                                Expense = int.Parse(item.Element("expense").Value),
                                Memo = item.Element("memo").Value
                            }).ToList<Account>();
                
            }
            catch (FileNotFoundException ex)
            {
                Save();
            }

        }

        public static void Save()
        {
            string accountsOutput = "";


            accountsOutput += "<accounts>\n";

            foreach (var item in Accounts)
            {
                accountsOutput += "<account>\n";
                accountsOutput += "   <date>" + item.Date + "</date>\n";
                accountsOutput += "   <content>" + item.Content + "</content>\n";
                accountsOutput += "   <income>" + item.Income + "</income>\n";
                accountsOutput += "   <expense>" + item.Expense + "</expense>\n";
                accountsOutput += "   <memo>" + item.Memo + "</memo>\n";
                accountsOutput += "</account>\n";

            }
            accountsOutput += "</accounts>";
            File.WriteAllText(@"./Accounts.xml", accountsOutput);
        }
    }
}
