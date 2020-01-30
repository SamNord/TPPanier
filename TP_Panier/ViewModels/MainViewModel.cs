﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
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
        private Product produit;
        private Panier panier;
        private SqlCommand command;
        private SqlDataReader reader;

        public MainViewModel()
        {
            customer = new Customer();
            produit = new Product();
            panier = new Panier();
            ListProductPanier = new ObservableCollection<Product>();
        }

        public int IdClient { get => customer.Id; set => customer.Id = value; }
        public string Lastname { get => customer.Lastname; set => customer.Lastname = value; }
        public string Firstname { get => customer.Firstname; set => customer.Firstname = value; }
        public string Phone { get => customer.Phone; set => customer.Phone = value; }
        public Customer Customer { get => customer; set => customer = value; }

        public int IdProduit { get => produit.Id; set => produit.Id = value; }
        public string Label { get => produit.Label; set => produit.Label = value; }
        public decimal Price { get => produit.Price; set => produit.Price = value; }
        public Product Produit { get => produit; set { produit = value; RaisePropertyChanged(); } }

        public Panier Panier { get => panier; set { panier = value; RaisePropertyChanged(); } }
        public int IdPanier { get => panier.Id; set => panier.Id = value; }

        public decimal Total
        {
            get => panier.Total;
        }

        public ObservableCollection<Product> ListProductPanier { get => listProductPanier; set { listProductPanier = value; RaisePropertyChanged(); } }

        private ObservableCollection<Product> listProductPanier;

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
            Customer c = Customer.SearchCustomer(IdClient);
            panier = new Panier()
            {
                Id = IdPanier,
                //ClientId = IdClient,
                ClientId = c.Id,
                Total = Total
            };
            if(panier.Save())
            {
                res = true;
                SaveInPanierProduit();
            }
            
            return res;
        }

        public void SaveInPanierProduit()
        {
            command = new SqlCommand("INSERT INTO PanierProduit (panier_id, produit_id) Values (@idPanier, @idProduit)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idPanier", IdPanier));
            command.Parameters.Add(new SqlParameter("@idProduit", IdProduit));
            Configuration.connection.Open();
            command.ExecuteNonQuery();      
            command.Dispose();
            Configuration.connection.Close();
         
        }
    }
}
