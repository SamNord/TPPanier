using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour AccueilView.xaml
    /// </summary>
    public partial class AccueilView : Window
    {
        public static SqlCommand command;
        public static SqlDataReader reader;

        public AccueilView()
        {
            InitializeComponent();
            DataContext = new AccueilViewModel();
        }



        private void AddClient(object sender, RoutedEventArgs e)
        {
            AccueilViewModel main = DataContext as AccueilViewModel;
            if (main.Customer.Save())
            {
                MessageBox.Show("client ajouté avec le numéro " + main.Customer.Id);
            }
        }

        private void SearchClient(object sender, RoutedEventArgs e)
        {

        }

        private void AddInBasket(object sender, RoutedEventArgs e)
        {
            AccueilViewModel main = DataContext as AccueilViewModel;
            main.Produit = Product.SearchProduct(main.Produit.Id);
            main.ListProductPanier.Add(main.Produit);
            main.CalculTotal();

        }

        private void ValiderPanier(object sender, RoutedEventArgs e)
        {
            AccueilViewModel main = DataContext as AccueilViewModel;

            if (main.ValiderPanier())
            {
                MessageBox.Show("panier validé, le total est de " + main.Panier.Total + "€");
            }

            else
            {
                MessageBox.Show("erreur");
            }


        }

        private void AddProductInBDD(object sender, RoutedEventArgs e)
        {
            AddProduct addProductWindow = new AddProduct();
            addProductWindow.Show();
        }

        private void SearchProduct(object sender, RoutedEventArgs e)
        {
            AccueilViewModel main = DataContext as AccueilViewModel;
            main.Produit = Product.SearchProduct(main.Produit.Id);
            if (main.Produit != null)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("produit non  trouvé");

            }
        }


        /***********************Réinitialisation des tables*************
         ***************************************************************/

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table client", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }

        private void DeleteProduit(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table produit", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }

        private void DeletePanier(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table panier", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }

        private void DeleteProduitPanier(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table panierproduit", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
        }

        private void SearchOneClient(object sender, RoutedEventArgs e)
        {

        }
    }
}
