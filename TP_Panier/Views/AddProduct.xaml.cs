using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP_Panier.Models;
using TP_Panier.ViewModels;

namespace TP_Panier.Views
{
    /// <summary>
    /// Logique d'interaction pour AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private Product product;
        public AddProduct()
        {
            InitializeComponent();
            DataContext = new AddProductView();
        }

        private void AjouterProduct(object sender, RoutedEventArgs e)
        {
            AddProductView v = DataContext as AddProductView;
            if (v.Produit.Save())
            {
                MessageBox.Show("produit ajouté avec numéro " + v.Produit.Id);
            }

        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            /*ici en commentaire --> echec donc j'ai du utilisé les noms des textBox ->voir fenetre AddProduct*/
            //AddProductView v = DataContext as AddProductView;
            //v.Produit = Product.SearchProduct(v.NumeroProduit);
            //v.LabelEdit = v.Produit.Label;
            //v.PrixEdit = v.Produit.Price;
            int id = Int32.Parse(numero.Text);
            product = Product.SearchProduct(id);
            if (product != null)
            {
                label.Text = product.Label;
                prix.Text = product.Price.ToString();
            }

        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            product = new Product()
            {
                Id = Int32.Parse(numero.Text),
                Label = label.Text,
                Price = Decimal.Parse(prix.Text)
            };
            if (product.Update())
            {
                MessageBox.Show("Produit modifié");
            }
        }


        //bouton de réinitialisation de la table produit
        private void DeleteTableProduit(object sender, RoutedEventArgs e)
        {
            Product.ReinitialisationTableProduit();
            MessageBox.Show("table produit réinitialisée");
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            product = new Product()
            {
                Id = Int32.Parse(numero.Text),
                Label = label.Text,
                Price = Decimal.Parse(prix.Text)
            };
            if (product.Delete())
            {
                MessageBox.Show("Produit supprimé");
            }
        }
    }
}
