using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    public class Panier
    {
        private int id;
        private int clientId;
        private decimal total;
        private List<Product> products;
        public static SqlCommand command;
        public static SqlDataReader reader;

        public Panier()
        {
            Products = new List<Product>();
         
        }

        public int Id { get => id; set => id = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public decimal Total { get => total; set => total = value; }
        public List<Product> Products { get => products; set => products = value; }

        public bool Save()
        {
            command = new SqlCommand("INSERT INTO panier (client_id, total) OUTPUT INSERTED.ID Values (@idC, @tot)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idC", ClientId));
            command.Parameters.Add(new SqlParameter("@tot", Total));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        public bool Update()
        {
            bool result = false;
            command = new SqlCommand("Update panier set total=@tot WHERE id=@id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@tot", Total));
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            command = new SqlCommand("DELETE FROM panier WHERE id = @id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        public static Panier SearchPanierByIdClient(int idClient)
        {
            Panier panier = null;
            command = new SqlCommand("SELECT id, total FROM panier WHERE id= @idC", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idC", idClient));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                panier = new Panier()
                {
                    Id = reader.GetInt32(0),
                    ClientId = idClient,
                    Total = reader.GetDecimal(1)                   
                };
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return panier;
        }
    }
}
