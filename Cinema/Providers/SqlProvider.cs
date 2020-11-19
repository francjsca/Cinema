using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public abstract class SqlProvider<T> : ISqlProvider<T> {

        protected readonly string connectionString;

        protected SqlProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract void Update(T obj);

        public abstract IEnumerable<T> GetAll();

        public abstract void Insert(T obj);     
    }
}
