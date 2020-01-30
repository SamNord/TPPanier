
using System;
using System.Collections.Generic;

using GalaSoft.MvvmLight;

using System.Collections.ObjectModel;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Panier.Models;

namespace TP_Panier.ViewModels
{


    public class MainViewModel : ViewModelBase
    {
        private Customer customer;
        private Product product;
        private Basket panier;
        private SqlCommand command;
        private ObservableCollection<Product> listProductPanier;
        private string identifiantAdmin;
        private string passAdmin;

        public MainViewModel()
        {
            customer = new Customer();
            panier = new Basket();
            product = new Product();
            ListProductPanier = new ObservableCollection<Product>();
        }

        public int IdCustomer { get => customer.Id; set => customer.Id = value; }
        public string FirstName { get => customer.Firstname; set => customer.Firstname = value; }
        public string LastName { get => customer.Lastname; set => customer.Lastname = value; }
        public string PhoneNumber { get => customer.PhoneNumber; set => customer.PhoneNumber = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public int IdProduct { get => product.Id; set => product.Id = value; }
        public string Label { get => product.Label; set => product.Label = value; }
        public decimal Price { get => product.Price; set => product.Price = value; }
        public Product Product { get => product; set => product = value; }

        public ObservableCollection<Product> ListProductPanier { get => listProductPanier; set { listProductPanier = value; RaisePropertyChanged(); } }

        public Basket Panier { get => panier; set { panier = value; RaisePropertyChanged(); } }
        public int IdPanier { get => panier.Id; set => panier.Id = value; }

        public decimal Total
        {
            get => panier.Total;
        }
        public string IdentifiantAdmin { get => identifiantAdmin; set { identifiantAdmin = value; RaisePropertyChanged(); } }
        public string PassAdmin { get => passAdmin; set { passAdmin = value; RaisePropertyChanged(); } }

        public void CalculTotal()
        {
            panier.Total = 0;
            foreach (Product p in ListProductPanier)
            {
                panier.Total += p.Price;
            }

            RaisePropertyChanged("Total");
        }

        public bool ValiderPanier()
        {
            bool res = false;
            Customer c = Customer.GetCustomerById(IdCustomer);
            panier = new Basket()
            {
                Id = IdPanier,
                CustomerId = c.Id,
                Total = Total
            };
            if (panier.Save2())
            {
                res = true;
                SaveInPanierProduit();
            }
            return res;
        }

        //public void DefineAccesAdmin(string identifiant, string pass)
        //{
        //    identifiant = IdentifiantAdmin;
        //    pass = PassAdmin;
        //    RaisePropertyChanged("IdentifiantAdmin");
        //    RaisePropertyChanged("PassAdmin");
        //}

        public void SaveInPanierProduit()
        {
            command = new SqlCommand("INSERT INTO PanierProduit (panier_id, produit_id) Values (@idPanier, @idProduit)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idPanier", IdPanier));
            command.Parameters.Add(new SqlParameter("@idProduit", IdProduct));
            Configuration.connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            Configuration.connection.Close();

        }

    }
}

