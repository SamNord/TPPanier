﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    public class Product
    {
        private int id;
        private string label;
        private decimal price;       
        public static SqlCommand command;
        public static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public decimal Price { get => price; set => price = value; }

        public Product() { }

        public bool Save()
        {           
            command = new SqlCommand("INSERT INTO produit (label, prix) OUTPUT INSERTED.ID Values(@label, @prix)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@label", Label));
            command.Parameters.Add(new SqlParameter("@prix", Price));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id >0;
        }

        public static List<Product> SeeProducts()
        {
            List<Product> products = new List<Product>();
            command = new SqlCommand("Select * FROM produit", Configuration.connection);
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32(0),
                    Label = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };
                products.Add(product);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }

    }
}