using System;
using System.Collections.Generic;
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
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\TP_Panier;Integrated Security=True");
        public static SqlCommand command;
        public static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public decimal Price { get => price; set => price = value; }

        public Product() { }

     
        
    }
}
