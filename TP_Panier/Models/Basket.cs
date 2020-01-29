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
        private List<Product> products;
        public static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public List<Product> Products { get => products; set => products = value; }

        public Basket()
        {
            Products = new List<Product>();
        }
        public void save()
        {

        }
        


    }
}
