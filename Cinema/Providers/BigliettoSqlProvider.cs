using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Providers {
    public class BigliettoSqlProvider : SqlProvider<Biglietto> {
        public BigliettoSqlProvider(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<Biglietto> GetAll()
        {
            List<Biglietto> biglietti = new List<Biglietto>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT  [Id],[IdProiezione],[IdSpettatore],[Prezzo],[Fila],[NumeroPosto]
  FROM [Cinema].[dbo].[Biglietto]", conn)) {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    biglietti.Add(new Biglietto(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["IdProiezione"]), Convert.ToInt32(reader["IdSpettatore"]), Convert.ToInt32(reader["Fila"]), Convert.ToInt32(reader["NumeroPosto"]),Convert.ToDouble(reader["Prezzo"])));
                }
            }
            return biglietti;
        }

        public override void Insert(Biglietto biglietto)
        {

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO [dbo].[Biglietto]([IdProiezione]
           ,[IdSpettatore],[Prezzo],[Fila],[NumeroPosto])
              VALUES( @IdProiezione, @IdSpettatore, @Prezzo,@Fila,@NumeroPosto)", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@IdProiezione", biglietto.IdProiezione);
                cmd.Parameters.AddWithValue("@IdSpettatore", biglietto.IdSpettatore);
                cmd.Parameters.AddWithValue("@Prezzo", biglietto.Prezzo);
                cmd.Parameters.AddWithValue("@Fila", biglietto.Fila);
                cmd.Parameters.AddWithValue("@NumeroPosto", biglietto.NumeroPosto);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Update(Biglietto biglietto)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE [dbo].[Biglietto] SET IdProiezione = @IDProiezione, IdSpettatore = @IdSpettatore, Prezzo=@Prezzo, Fila=@Fila, NumeroPosto=@NumeroPosto
                                            WHERE Id = @Id", conn)) {
                conn.Open();
                cmd.Parameters.AddWithValue("@IdProiezione", biglietto.Id);
                cmd.Parameters.AddWithValue("@IdProiezione", biglietto.IdProiezione);
                cmd.Parameters.AddWithValue("@IdSpettatore", biglietto.IdSpettatore);
                cmd.Parameters.AddWithValue("@Prezzo", biglietto.Prezzo);
                cmd.Parameters.AddWithValue("@Fila", biglietto.Fila);
                cmd.Parameters.AddWithValue("@NumeroPosto", biglietto.NumeroPosto);
                cmd.ExecuteNonQuery();
            }
        }
    }
    
}
