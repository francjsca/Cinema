using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class ProiezioneSqlProvider : SqlProvider<Proiezione> {
        public ProiezioneSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Proiezione> GetAll()
        {
            List<Proiezione> filmProiezione = new List<Proiezione>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT [Id],[IdFilm] ,[IdSala] ,[Data]
                                    FROM [Cinema].[dbo].[Proiezione]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    filmProiezione.Add(new Proiezione(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["IdSala"]), Convert.ToInt32(reader["IdFilm"]), (DateTime)reader["Data"]));
                }
            }
            return filmProiezione;
        }

        public override void Insert(Proiezione proiezione)
        {

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Proiezione]([IdFilm] ,[IdSala],[Data])
                         VALUES( @IdFilm, @IdSala, @Data)", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@IdFilm", proiezione.IdFilm);
                cmd.Parameters.AddWithValue("@IdSala", proiezione.IdSala);
                cmd.Parameters.AddWithValue("@IdSala", proiezione.Data);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Update(Proiezione proiezione)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Proiezione] SET IdFilm = @IdFilm, IdSala = @IdSala, Data=@Data
                                            WHERE Id = @Id", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", proiezione.Id);
                cmd.Parameters.AddWithValue("@IdSala", proiezione.IdSala);
                cmd.Parameters.AddWithValue("@IdFilm", proiezione.IdFilm);
                cmd.Parameters.AddWithValue("@Data", proiezione.Data);
                cmd.ExecuteNonQuery();
            }
        }

        public  IEnumerable<Proiezione> FilmOggi()
        {
            List<Proiezione> filmProiezione = new List<Proiezione>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT [Id],[IdFilm] ,[IdSala] ,[Data]
                                    FROM [Cinema].[dbo].[Proiezione]
                                    WHERE Data =cast(GETDATE() as date)", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    filmProiezione.Add(new Proiezione(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["IdSala"]), Convert.ToInt32(reader["IdFilm"]), (DateTime)reader["Data"]));
                }
            }
            return filmProiezione;
        }
    }
    
}
