using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    public class MainViewModel
    {
        private Customer customer;
        private Product product;

        public MainViewModel()
        {
            customer = new Customer();
            product = new Product();
        }

        public int IdCustomer { get => customer.Id; set => customer.Id = value; }
        public string FirstName { get => customer.FirstName; set => customer.FirstName = value; }
        public string LastName { get => customer.LastName; set => customer.LastName = value; }
        public string PhoneNumber { get => customer.PhoneNumber; set => customer.PhoneNumber = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public int IdProduct { get => product.Id; set => product.Id = value; }
        public string Label { get => product.Label; set => product.Label = value; }
        public decimal Price { get => product.Price; set => product.Price = value; }
        public Product Product { get => product; set => product = value; }

    }
}
