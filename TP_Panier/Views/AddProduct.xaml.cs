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
                v.SeeAllProduct();
            }

        }

        private void DeleteProductSelected(object sender, RoutedEventArgs e)
        {
            AddProductView v = DataContext as AddProductView;
            if (v.DeleteProduct())
            {
                MessageBox.Show("Produit supprimé");
                v.SeeAllProduct();
            }
            else
            {
                MessageBox.Show("Erreur inconnue");

            }
        }

        private void UpdateProductSelected(object sender, RoutedEventArgs e)
        {
            AddProductView v = DataContext as AddProductView;
            v.ProductSelected = v.Produit;
            UpdateProductView produitUpdate = new UpdateProductView(v.ProductSelected);
            produitUpdate.Show();
            //MessageBox.Show($"Label : {v.ProductSelected.Label}, Prix : {v.ProductSelected.Price}€");
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        //renvoit une nouvelle fenêtre qui sert à réinitialiser la BDD
        private void DeleteBDD(object sender, RoutedEventArgs e)
        {
            DeleteTableView deleteWindow = new DeleteTableView();
            deleteWindow.Show();
            this.Close();
        }
    }
}
