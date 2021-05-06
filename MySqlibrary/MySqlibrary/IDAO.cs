using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlibrary
{
    public interface IDAO<T>
    {
        int insert(T M);
        int update(T M);
        int delete(T M);
        List<T> Select(T M);
    }
    
}
