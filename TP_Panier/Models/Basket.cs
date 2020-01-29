using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    class Basket
    {
        private int id;
        private Customer customer;
        private decimal total;
        private int customerId;
        private List<Product> products;
        public static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public List<Product> Products { get => products; set => products = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public int CustomerId { get => customerId; set => customerId = value; }

        public Basket()
        {
            Products = new List<Product>();
            Customer = new Customer();
        }

        public void Save()
        {
            total = 0;
            Products.ForEach(product =>
            {
                total += product.Price;
            });
            command = new SqlCommand("INSERT INTO Panier (client_id, total) OUTPUT INSERTED.ID values(@client_id, @total)", Configuration.Connection);
            command.Parameters.Add(new SqlParameter("@name", CustomerId));
            command.Parameters.Add(new SqlParameter("@total", Total));
            Configuration.Connection.Open();
            Id = (int)command.ExecuteScalar();
            if (Id > 0)
            {
                command.Dispose();
                Products.ForEach(product =>
                {
                    command = new SqlCommand("INSERT INTO PanierProduit (produit_id, panier_id) values(@produitId, @panierId)", Configuration.Connection);
                    command.Parameters.Add(new SqlParameter("@produitId", product.Id));
                    command.Parameters.Add(new SqlParameter("@panierId", Id));
                    command.ExecuteNonQuery();
                    command.Dispose();
                });
            }
            Configuration.Connection.Close();
        }

    }
}
