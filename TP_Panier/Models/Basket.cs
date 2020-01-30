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
        private decimal total;
        private int customerId;
        private List<Product> products;
        public static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public List<Product> Products { get => products; set => products = value; }
        
        public int CustomerId { get => customerId; set => customerId = value; }

        public Basket()
        {
            Products = new List<Product>();
          
        }
        
        public void Save()
        {
            total = 0;
            Products.ForEach(product =>
            {
                total += product.Price;
            });
            command = new SqlCommand("INSERT INTO Panier (client_id, total) OUTPUT INSERTED.ID values(@client_id, @total)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@client_id", CustomerId));
            command.Parameters.Add(new SqlParameter("@total", Total));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            if (Id > 0)
            {
                command.Dispose();
                Products.ForEach(product =>
                {
                    command = new SqlCommand("INSERT INTO PanierProduit (produit_id, panier_id) values(@produitId, @panierId)", Configuration.connection);
                    command.Parameters.Add(new SqlParameter("@produitId", product.Id));
                    command.Parameters.Add(new SqlParameter("@panierId", Id));
                    command.ExecuteNonQuery();
                    command.Dispose();
                });
            }
            Configuration.connection.Close();
        }
        
        public static Basket GetBasketById(int id)
        {
            Basket basket = null;
            string request = "SELECT p.id as panier_id, p.client_id, p.total, pr.id as produit_id, pr.label, pr.prix " +
                           "FROM Panier as p " +
                           "left join PanierProduit as pp on p.id = pp.panier_id " +
                           "left join Produit as pr on pr.id = pp.produit_id " +
                           "where p.id = @id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            basket = new Basket();
            basket.Id = id;
            while (reader.Read())
            {
                basket.CustomerId = reader.GetInt32(1);             
                basket.total = reader.GetDecimal(2);
                basket.Products.Add(new Product { Id = reader.GetInt32(3), Label = reader.GetString(4), Price = reader.GetDecimal(5) });
            }
            command.Dispose();
            Configuration.connection.Close();
            return basket;
        }

        public override string ToString()
        {
            return $"Client : {CustomerId},  Total : {Total}";
        }
    }
}
