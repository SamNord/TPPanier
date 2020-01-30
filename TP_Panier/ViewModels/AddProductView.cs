using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    public class AddProductView : ViewModelBase
    {
        private Product produit;


        public AddProductView()
        {
            produit = new Product();
            ListProducts = Product.GetAllProducts();
            RaisePropertyChanged("ListProducts");
        }
        public int Id { get => produit.Id; set => produit.Id = value; }
        public string Label { get => produit.Label; set => produit.Label = value; }
        public decimal Price { get => produit.Price; set => produit.Price = value; }
        public Product Produit { get => produit; set => produit = value; }

        public Product ProductSelected { get => produit; set => produit = value; }
        public ObservableCollection<Product> ListProducts { get; set; }


        public void SeeAllProduct()
        {
            ListProducts = Product.GetAllProducts();
            RaisePropertyChanged("ListProducts");
        }

        public bool DeleteProduct()
        {
            bool res = false;
            if(ProductSelected.Delete())
            {
                res = true;
                RaisePropertyChanged("ProductSelected");
                RaisePropertyChanged("ListProducts");
            }
            return res;
        }
    }
}
