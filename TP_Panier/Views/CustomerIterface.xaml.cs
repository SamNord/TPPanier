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

namespace TP_Panier.Views
{
    /// <summary>
    /// Logique d'interaction pour CustomerIterface.xaml
    /// </summary>
    public partial class CustomerIterface : Window
    {
        public CustomerIterface()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchProductById(object sender, RoutedEventArgs e)
        {

        }

        private void AddToBasket(object sender, RoutedEventArgs e)
        {
            Basket b = new Basket { }
        }

        private void Order(object sender, RoutedEventArgs e)
        {

        }
    }
}
