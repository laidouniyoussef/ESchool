using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant
{
    class Eleve
    {
        int codeElev, code_Fil;
        string nom, prenom, niveau;

        public Eleve(int codeElev, int code_Fil, string nom = null, string prenom = null, string niveau = null)
        {
            this.codeElev = codeElev;
            this.nom = nom;
            this.prenom = prenom;
            this.code_Fil = code_Fil;
            this.niveau = niveau;
        }

        public Dictionary<string, object> ConvertObjettoDictionary() 
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            
            Dic.Add("codeElev", codeElev);
            Dic.Add("code_Fil", code_Fil);
            Dic.Add("nom", nom);
            Dic.Add("pronom", prenom);
            Dic.Add("niveau", niveau);
            return Dic;

        }

    }
}