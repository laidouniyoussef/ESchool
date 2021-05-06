using System;
using System.Collections.Generic;
using System.Linq;
using MySqlibrary;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant
{
    class EleveDAO : DAO, IDAO<Eleve>
    {

        static string[] Data = {"gestionnotes", "localhost", "", "", "root" }; 

        public EleveDAO() : base("Eleve", MySqlibrary.DAO.param_co = Data)
        {

        }

        public int insert(Eleve E)
        {
            return Update("insert", E.ConvertObjettoDictionary(), null);
        }
        
        public List<Eleve> Select(Eleve E = null)
        {
            return Select(null);
        }
        
        public int update(Eleve E)
        {
            return Update("update", E.ConvertObjettoDictionary(), null);
        }
        public int delete(Eleve E)
        {
            return  Update("delete", E.ConvertObjettoDictionary(), null);
        }
    }
}
