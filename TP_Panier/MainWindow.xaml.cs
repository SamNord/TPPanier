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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP_Panier.Models;
using TP_Panier.ViewModels;

namespace TP_Panier
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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


    }
}
