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

namespace TP_Panier.Views
{
    /// <summary>
    /// Logique d'interaction pour DeleteTableView.xaml
    /// </summary>
    public partial class DeleteTableView : Window
    {
        public static SqlCommand command;
        public DeleteTableView()
        {
            InitializeComponent();
        }

        private void DeleteCusto(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table client", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
            MessageBox.Show("supprimé");
        }

        private void DeleteProducts(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table produit", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
            MessageBox.Show("supprimé");
        }

        private void DeletePanier(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table panier", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
            MessageBox.Show("supprimé");
        }

        private void DeletePP(object sender, RoutedEventArgs e)
        {
            command = new SqlCommand("TRUNCATE Table PanierProduit", Configuration.connection);
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();
            MessageBox.Show("supprimé");
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
