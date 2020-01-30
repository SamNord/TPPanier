using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    class CustomerInterfaceModel
    {
        private Product product;
        private Customer customer;
        private Basket basket;
        private ObservableCollection<Product> productsList;

        public int ProductId { get => Product.Id; set => Product.Id = value; }
        public string Label { get => Product.Label; set => Product.Label = value; }
        public decimal Price { get => Product.Price; set => Product.Price = value; }
        public Product Product { get => product; set => product = value; }

        public int CustomerId { get => Customer.Id; set => Customer.Id = value; }
        public string FirstName { get => Customer.FirstName; set => Customer.FirstName = value; }
        public string LastName { get => Customer.LastName; set => Customer.LastName = value; }
        public string PhoneNumber { get => Customer.PhoneNumber; set => Customer.PhoneNumber = value; }
        public Customer Customer { get => customer; set => customer = value; }


        public int BasketId { get => Basket.Id; set => Basket.Id = value; }
        public decimal Total { get => Basket.Total; set => Basket.Total = value; }
        public Basket Basket { get => basket; set => basket = value; }
        public ObservableCollection<Product> ProductsList { get => productsList; set => productsList = value; }

        public CustomerInterfaceModel()
        {
            Customer = new Customer();
            Product = new Product();
            Basket = new Basket();
            ProductsList = new ObservableCollection<Product>();
        }


    }
}
