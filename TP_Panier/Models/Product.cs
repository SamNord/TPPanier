using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    public class Product
    {
        private int id;
        private string label;
        private decimal price;       
        public static SqlCommand command;
        public static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public decimal Price { get => price; set => price = value; }

        public Product() { }

        public bool Save()
        {           
            command = new SqlCommand("INSERT INTO produit (label, prix) OUTPUT INSERTED.ID Values (@label, @prix)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@label", Label));
            command.Parameters.Add(new SqlParameter("@prix", Price));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        //pour afficher les produits présents dans la table produit
        public static ObservableCollection<Product> GetAllProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            command = new SqlCommand("Select * FROM produit", Configuration.connection);
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32(0),
                    Label = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };
                products.Add(product);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }

        public static List<Product> SeeProducts()
        {
            List<Product> products = new List<Product>();
            command = new SqlCommand("Select * FROM produit", Configuration.connection);
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32(0),
                    Label = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };
                products.Add(product);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }

        public static Product SearchProduct(int idProduit)
        {
            Product product = null;
            command = new SqlCommand("SELECT label, prix FROM produit WHERE id= @idP", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idP", idProduit));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                product = new Product()
                {
                    Id =idProduit,
                    Label = reader.GetString(0),
                    Price = reader.GetDecimal(1),
                };
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return product;
        }

        public bool Update()
        {
            bool result = false;
            command = new SqlCommand("Update produit set label=@lab, prix=@prix WHERE id=@id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@lab", Label));
            command.Parameters.Add(new SqlParameter("@prix", Price));
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if(command.ExecuteNonQuery() >0)
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
            command = new SqlCommand("DELETE FROM Produit WHERE id = @id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if (command.ExecuteNonQuery() >0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        public override string ToString()
        {
            return $"Numéro : {Id}, Label : {Label}, Prix : {Price}";
        }




        //pour effacer les données de la table produit en réinitialisant l'incrémentation
        //on appelle cette méthode dans le code de la fenêtre AddProduct bouton rouge
        public static void ReinitialisationTableProduit()
        {
            command = new SqlCommand("TRUNCATE Table produit", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }
    }
}
