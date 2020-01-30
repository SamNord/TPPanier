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
    /// Logique d'interaction pour UpdateProductView.xaml
    /// </summary>
    public partial class UpdateProductView : Window
    {
        public UpdateProductView()
        {
            InitializeComponent();
            DataContext = new UpdateProductViewModel();
        }

        public UpdateProductView(Product p) : this()
        {
            UpdateProductViewModel u = DataContext as UpdateProductViewModel;
            u.ProductEdit = p;
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            UpdateProductViewModel u = DataContext as UpdateProductViewModel;
            if(u.Modifier())
            {
                MessageBox.Show("Produit modifié");
                AddProduct addWindow = new AddProduct();
                addWindow.Show();
            }
            else
            {
                MessageBox.Show("Y a une erreur qui traine quelque part.");

            }
        }
    }
}
