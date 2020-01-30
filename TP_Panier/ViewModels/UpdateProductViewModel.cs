using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{
    public class UpdateProductViewModel : ViewModelBase
    {
        private Product produit;

        public UpdateProductViewModel()
        {
            produit = new Product();
        }

        public int NumeroProduit { get => produit.Id; set => produit.Id = value; }
        public string LabelEdit { get => produit.Label; set => produit.Label = value; }
        public decimal PrixEdit { get => produit.Price; set => produit.Price = value; }
        public Product ProductEdit { get => produit; set => produit = value; }

        public bool Modifier()
        {
            bool result = false;
            if(ProductEdit.Update())
            {
                result = true;
                RaisePropertyChanged("LabelEdit");
                RaisePropertyChanged("PrixEdit");
                RaisePropertyChanged("ProductEdit");
            }
            return result;
        }
    }
}
