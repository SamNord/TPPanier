using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    public class AddProductView : ViewModelBase
    {
        private Product produit;
        private int numeroProduit;
        private string labelEdit;
        private decimal prixEdit;

        public AddProductView()
        {
            produit = new Product();
            ListProducts = Product.SeeProducts();
            RaisePropertyChanged("ListProducts");
        }

        public string Label { get => produit.Label; set => produit.Label = value; }
        public decimal Price { get => produit.Price; set => produit.Price = value; }
        public Product Produit { get => produit; set => produit = value; }

       
        public List<Product> ListProducts { get; set; }
        public int NumeroProduit { get => numeroProduit; set => numeroProduit = value; }
        public string LabelEdit { get => labelEdit; set => labelEdit = value; }
        public decimal PrixEdit { get => prixEdit; set => prixEdit = value; }
    }
}
