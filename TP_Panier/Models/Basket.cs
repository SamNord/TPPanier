using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{

    public class Basket

    {
        private int id;
        private decimal total;
        private int customerId;
        private ObservableCollection<Product> products;
        public static SqlCommand command;
        public static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public ObservableCollection<Product> Products { get => products; set => products = value; }

        public int CustomerId { get => customerId; set => customerId = value; }

        public Basket()
        {
            Products = new ObservableCollection<Product>();
        }

        public bool Save()
        {
            bool res = false;
            total = 0;
            //Products.ForEach(product =>
            //{
            //    total += product.Price;
            //});
            foreach(Product p in Products )
            {
                total += p.Price;
            }
            command = new SqlCommand("INSERT INTO Panier (client_id, total) OUTPUT INSERTED.ID values(@client_id, @total)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@client_id", CustomerId));
            command.Parameters.Add(new SqlParameter("@total", Total));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            if (Id > 0)
            {
                command.Dispose();
           
                foreach(Product prod in Products)
                {
                    command = new SqlCommand("INSERT INTO PanierProduit (produit_id, panier_id) values(@produitId, @panierId)", Configuration.connection);
                    command.Parameters.Add(new SqlParameter("@produitId", prod.Id));
                    command.Parameters.Add(new SqlParameter("@panierId", Id));
                    if (command.ExecuteNonQuery() > 0)
                    {
                        res = true;
                    }
                    command.Dispose();

                }
            }
            Configuration.connection.Close();
            return res;
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

        public bool Save2()
        {
            command = new SqlCommand("INSERT INTO panier (client_id, total) OUTPUT INSERTED.ID Values (@idC, @tot)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idC", CustomerId));
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

        public override string ToString()
        {
            return $"Client : {CustomerId},  Total : {Total}";
        }
    }
}

