using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Customer customer;
        private Product produit;

        public MainViewModel()
        {
            customer = new Customer();
            produit = new Product();
        }

        public int IdClient { get => customer.Id; set => customer.Id = value; }
        public string Lastname { get => customer.Lastname; set => customer.Lastname = value; }
        public string Firstname { get => customer.Firstname; set => customer.Firstname = value; }
        public string Phone { get => customer.Phone; set => customer.Phone = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public int IdProduit { get => produit.Id; set => produit.Id = value; }
        public string Label { get => produit.Label; set => produit.Label = value; }
        public decimal Price { get => produit.Price; set => produit.Price = value; }
        public Product Produit { get => produit; set => produit = value; }

    }
}
