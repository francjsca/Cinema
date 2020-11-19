using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class GenereSqlProvider : SqlProvider<Genere> {
        public GenereSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Genere> GetAll()
        {
            List<Genere> generi = new List<Genere>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT Nome
                                    FROM [Cinema].[dbo].[Genere]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    generi.Add(new Genere(reader["Nome"].ToString()));
                }
            }
            return generi;
        }

        public override void Insert(Genere genere)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Genere]([Nome])
     VALUES(@Nome)", conn)) {
                conn.Open();
               
                cmd.Parameters.AddWithValue("@Nome", genere.Nome);
            }
        }

        public override void Update(Genere obj)
        {
            throw new NotImplementedException();
        }
    }
    }

