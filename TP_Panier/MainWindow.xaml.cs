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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP_Panier.Models;
using TP_Panier.ViewModels;
using TP_Panier.Views;


namespace TP_Panier
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SqlCommand command;
        public static SqlDataReader reader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            MainViewModel main = DataContext as MainViewModel;

            if (main.Customer.Save())
            {
                MessageBox.Show("Client ajouté avec le numéro " + main.Customer.Id);
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
        }

        //private void AddClient(object sender, RoutedEventArgs e)
        //{
        //    MainViewModel main = DataContext as MainViewModel;
        //    if (main.Customer.Save())
        //    {
        //        MessageBox.Show("client ajouté avec le numéro " + main.Customer.Id);
        //    }
        //}

        private void SearchClient(object sender, RoutedEventArgs e)
        {

        }

        private void AddInBasket(object sender, RoutedEventArgs e)
        {
            MainViewModel main = DataContext as MainViewModel;
            main.Product = Product.SearchProduct(main.Product.Id);
            main.ListProductPanier.Add(main.Product);
            main.CalculTotal();

        }

        private void ValiderPanier(object sender, RoutedEventArgs e)
        {
            MainViewModel main = DataContext as MainViewModel;

            if (main.ValiderPanier())
            {
                MessageBox.Show("panier validé, le total est de "+ main.Panier.Total + "€");
            }

            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void ConnectingCusto(object sender, RoutedEventArgs e)
        {
            MainViewModel main = DataContext as MainViewModel;
            main.Customer = Customer.GetCustomerById(main.Customer.Id);
            PanierView panierWindow = new PanierView(main.Customer);
            panierWindow.Show();
        }

        private void AddProductInBDD(object sender, RoutedEventArgs e)
        {
            AddProduct addProductWindow = new AddProduct();
            addProductWindow.Show();
        }


        private void ConnectingAdmin(object sender, RoutedEventArgs e)
        {
            MainViewModel main = DataContext as MainViewModel;
            if(main.IdentifiantAdmin == "killerTeam" && main.PassAdmin == "admin")
            {

                AddProduct addProductWindow = new AddProduct();
                addProductWindow.Show();
            }

            else
            {
                MessageBox.Show("T'as pas le droit ! Pas bien !");
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


    }
}
