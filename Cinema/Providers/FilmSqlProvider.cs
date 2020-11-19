using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class FilmSqlProvider : SqlProvider<Film> {
        public FilmSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Film> GetAll()
        {
            List<Film> film = new List<Film>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT  [Id],[Titolo],[Regista],[Produttore],[MinutiDurata],[Genere]
                                     FROM [Cinema].[dbo].[Film]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    film.Add(new Film(Convert.ToInt32(reader["Id"]),reader["Titolo"].ToString(),reader["Regista"].ToString(), reader["Produttore"].ToString(),Convert.ToInt32(reader["MinutiDurata"]),reader["Genere"].ToString()));
                }
            }
            return film;
        }

        public override void Insert(Film film)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Film]([Titolo],[Regista] ,[Produttore],[MinutiDurata],[Genere])
     VALUES( @Titolo, @Regista, @Produttore,@MinutiDurata,@Genere)", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Titolo", film.Titolo);
                cmd.Parameters.AddWithValue("@Regista", film.Regista);
                cmd.Parameters.AddWithValue("@Produttore", film.Produttore);
                cmd.Parameters.AddWithValue("@MinutiDurata", film.MinutiDurata);
                cmd.Parameters.AddWithValue("@Genere", film.Genere);

            }
        }

        public override void Update(Film film)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Film] SET Titolo = @Titolo, Regista = @Regista, Produttore=@Produttore, MinutiDurata=@MinutiDurata, Genere=@Genere
                                            WHERE Id = @Id", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id",film.Id );
                cmd.Parameters.AddWithValue("@Titolo", film.Titolo);
                cmd.Parameters.AddWithValue("@Regista", film.Regista);
                cmd.Parameters.AddWithValue("@Produttore", film.Produttore);
                cmd.Parameters.AddWithValue("@MinutiDurata", film.MinutiDurata);
                cmd.Parameters.AddWithValue("@Genere", film.Genere);
                cmd.ExecuteNonQuery();
            }
        }
    
    }
}
