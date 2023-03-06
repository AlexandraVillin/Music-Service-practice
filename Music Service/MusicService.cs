using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Service
{
    class MusicService
    {
        Dictionary<string, Account> accounts = new Dictionary<string, Account> { };

        public bool AddAccount(Account acc)
        {
            int b = 0;
            foreach (KeyValuePair<string, Account> x in accounts)
            {
                if (acc.username == x.Value.username)
                {
                    b++;
                }
            }
            if (b == 0)
            {
                accounts.Add(acc.username, acc);
                return true;
            }
            return false;
        }

        public bool RemoveAccount(string username)
        {
            int b = 0;
            foreach (KeyValuePair<string, Account> x in accounts)
            {
                if (username == x.Value.username)
                {
                    b++;
                }
            }
            if (b == 1)
            {
                accounts.Remove(username);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string str = "\n Accounts: ";
            foreach (KeyValuePair<string, Account> x in accounts)
            {
                str = str + "\n" + x.Value.ToString();
            }
            return str;
        }

        public void Export()
        {
            String csv = String.Join( Environment.NewLine, accounts.Select(d => $"{d.Key};{d.Value};"));
            System.IO.File.WriteAllText(@"C:\Users\acolj\Desktop\programs\Music Service\Accounts.csv", csv);
        }

    }
}
