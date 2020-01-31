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
    /// Logique d'interaction pour PanierView.xaml
    /// </summary>
    public partial class PanierView : Window
    {
        public PanierView()
        {
            InitializeComponent();
            DataContext = new PanierViewModel();
        }

        public PanierView(Customer custo) : this()
        {
            PanierViewModel panierWindow = DataContext as PanierViewModel;
            panierWindow.Customer = custo;
        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            PanierViewModel panierWindow = DataContext as PanierViewModel;
            panierWindow.Produit = Product.SearchProduct(panierWindow.Produit.Id);
            if (panierWindow.Produit == null)
            {
                MessageBox.Show("produit non  trouvé");
                panierWindow.Produit = new Product();
            }
        }

        private void AddInBasket(object sender, RoutedEventArgs e)
        {
            PanierViewModel panierWindow = DataContext as PanierViewModel;
            panierWindow.Produit = Product.SearchProduct(panierWindow.Produit.Id);
            panierWindow.ListProductPanier.Add(panierWindow.Produit);
            panierWindow.CalculTotal();
        }

        private void ValiderPanier(object sender, RoutedEventArgs e)
        {
            PanierViewModel panierWindow = DataContext as PanierViewModel;

            if (panierWindow.ValiderPanier())
            {
                MessageBox.Show("Total de la commande : " + panierWindow.Panier.Total + "€");
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
