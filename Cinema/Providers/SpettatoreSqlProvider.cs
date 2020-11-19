using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class SpettatoreSqlProvider : SqlProvider<Spettatore> {
        public SpettatoreSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Spettatore> GetAll()
        {
            List<Spettatore> spettatori = new List<Spettatore>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT  [Id] ,[Nome],[Cognome],[DataNascita]
                                        FROM [Cinema].[dbo].[Spettatore]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    spettatori.Add(new Spettatore(Convert.ToInt32(reader["Id"]), reader["Nome"].ToString(), reader["Cognome"].ToString(), (DateTime)reader["DataNascita"]));
                }
            }
            return spettatori;
        }

        public override void Insert(Spettatore spettatore)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Spettatore]([Nome],[Cognome],[DataNascita])
                                                VALUES( @Nome, @Cognome, @DataNascita)", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Nome", spettatore.Nome);
                cmd.Parameters.AddWithValue("@Name", spettatore.Cognome);
                cmd.Parameters.AddWithValue("@IdCard", spettatore.DataNascita);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Update(Spettatore spettatore)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Spettatore] SET Nome = @Nome, Cognome = @Cognome, DataNascita=@DataNascita
                                            WHERE Id = @Id", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", spettatore.Id);
                cmd.Parameters.AddWithValue("@Nome", spettatore.Nome);
                cmd.Parameters.AddWithValue("@Cognome", spettatore.Cognome);
                cmd.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
