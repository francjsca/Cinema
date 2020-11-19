using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public interface ISqlProvider<T> {
        void Insert(T Ttype);
        void Update(T Ttype);
        IEnumerable<T> GetAll();      
    }
}
