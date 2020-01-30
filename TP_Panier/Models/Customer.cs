using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    public class Customer
    {
        int id;
        string firstName;
        string lastName;
        string phoneNumber;
        public static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Customer()
        {

        }

        public Customer(string firstName,string lastName,string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }


        public bool Save()
        {
            bool result = false;
            string request = "INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID" +
                " values (@firstname, @lastname, @phonenumber)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@lastname", LastName));
            command.Parameters.Add(new SqlParameter("@firstname", FirstName));
            command.Parameters.Add(new SqlParameter("@phonenumber", PhoneNumber));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            if (Id > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        public static Customer GetCustomerById(int id)
        {
            Customer customer = null;
            string request = "SELECT TOP 1 id, prenom, nom, telephone FROM client where id = @id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                customer = new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                };
            }
            reader.Dispose();
            command.Dispose();
            Configuration.connection.Close();
            return customer;
        }
    }
}
