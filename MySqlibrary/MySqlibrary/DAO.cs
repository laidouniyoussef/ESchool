using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlibrary
{
    public class DAO : MySQL
    {
        public static string[] param_co;
            //= { "localhost", "", "gestionnotes", "root", "" };
        private string Table;
        public DAO(string table, string[] param_co) : base(param_co[0], param_co[1], Convert.ToInt32(param_co[2]), param_co[3], param_co[4])
        {
            Table = table;
        }
        public List<Dictionary<string, string>> Select(Dictionary<string, object> Criteres)
        {
            string  sql = "SELECT * FROM " + Table;

            if (Criteres!=null)
            {
                sql += " WHERE ";
            }
            int a = 0;
            foreach (KeyValuePair<string, object> C in Criteres)
            {
                if (a == 0)
                    sql += C.Key + " = " + C.Value;
                sql += "AND " + C.Key+ " = " + C.Value;
                a++;
            }
            return this.Get(sql);
        }
        public int Update(string action, Dictionary<string, object> Data, Dictionary<string, object> Criteres)
        {
            if ((action.ToLower()).Equals("insert"))
            {
                string sql = "INSERT INTO " + Table + " (";
                int check = 0;
                foreach (KeyValuePair<string, object> D in Data)
                {
                    if (check == 0)
                        sql += D.Key;
                    sql += " ," + D.Key;
                    check++;
                }
                sql += " VALUES(";
                int a = 0;
                foreach (KeyValuePair<string, object> D in Data)
                {
                    if (a == 0)
                        sql += D.Value;
                    sql += ", " + D.Value;
                }
                sql += ")";
                return this.Up(sql);
            }
           else if ((action.ToLower()).Equals("update"))
            {
                string sql = "UPDATE" + Table + " SET ";
                int empty = 0;
                foreach (KeyValuePair<string, object> D in Data)
                {
                    if (empty == 0)
                        sql += D.Key + " = " + D.Value;
                    sql += ", " + D.Key + " = " + D.Value;
                    empty++;
                }
                if (Criteres!=null)
                {
                    sql += " WHERE ";
                }
                int a = 0;
                foreach (KeyValuePair<string, object> C in Criteres)
                {
                    if (a == 0)
                        sql += C.Key + " = " + C.Value;
                    sql += "AND " + C.Key + " = " + C.Value;
                    a++;
                }
                return this.Up(sql);
            }


            else
            {
                string sql = "DELETE FROM " + Table;
                if (Criteres!=null)
                {
                    sql += " WHERE ";
                }
                int a = 0;
                foreach (KeyValuePair<string, object> C in Criteres)
                {
                    if (a == 0)
                        sql += C.Key + " = " + C.Value;
                    sql += "AND " + C.Key + " = " + C.Value;
                    a++;
                }
                return this.Up(sql);
            }
        }
    }
}
