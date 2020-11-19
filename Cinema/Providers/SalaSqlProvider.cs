using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class SalaSqlProvider : SqlProvider<Sala> {
        public SalaSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Sala> GetAll()
        {
            List<Sala> sale = new List<Sala>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT  [Id],[Capacita],[Nome]
                                    FROM [Cinema].[dbo].[Sala]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    sale.Add(new Sala(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["Capacita"]), Convert.ToInt32(reader["Nome"])));
                }
            }
            return sale;
        }

        public override void Insert(Sala sala)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Sala]([Capacita],[Nome])
     VALUES( @Capacita, @Nome)", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Capacita", sala.Capacita);
                cmd.Parameters.AddWithValue("@Nome", sala.Nome);
            }
        }

        public override void Update(Sala sala)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Sala] SET Capacita = @Capacita, Nome = @Nome
                                            WHERE Id = @Id", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", sala.Id);
                cmd.Parameters.AddWithValue("@Capacita", sala.Capacita);
                cmd.Parameters.AddWithValue("@Nome", sala.Nome);
                cmd.ExecuteNonQuery();
            }
        }
    }
    }

