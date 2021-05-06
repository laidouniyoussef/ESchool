using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlibrary
{
    public class MySQL
    {
        private string BD;
        static private MySqlConnection con = null;
        private string host;
        private int port;
        private string Pass;
        private MySqlDataReader dr;
        static private MySqlCommand cmd = null;
        private string User;

        protected MySQL(string bD, string host, int port, string pass, string user)
        {
            if (con == null)
            {
                BD = bD;
                this.host = host;
                this.port = port;
                Pass = pass;
                User = user;
                con = new MySqlConnection(@"server = " + host + "; user id = " + user + "; database = " + BD);
                con.Open();
                cmd = new MySqlCommand();
            }
        }

        public List<Dictionary<string, string>> Get(string sql)
        {
            List<Dictionary<string, string>> List;
            List = new List<Dictionary<string, string>>();
            cmd = new MySqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            Dictionary<string, string> Diction;
            while (dr.Read())
            {
                Diction = new Dictionary<string, string>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Diction.Add(dr.GetName(i), dr.GetValue(i).ToString());
                }
                List.Add(Diction);
                Diction = null;
            }
            return List;
        }

        public int Up(string sql)
        {
            cmd = new MySqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }


    }


}
