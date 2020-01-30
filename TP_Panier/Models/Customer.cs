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
        private int id;
        private string lastname;
        private string firstname;
        private string phone;
        public static SqlCommand command;
        public static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Phone { get => phone; set => phone = value; }

        public Customer()
        {
        }
        /*********************Ajout du client dans la BDD**************/
        public bool Save()
        {
            command = new SqlCommand("INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID Values (@lastname, @firstname, @tel)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@lastname", Lastname));
            command.Parameters.Add(new SqlParameter("@firstname", Firstname));
            command.Parameters.Add(new SqlParameter("@tel", Phone));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        /*******************Modification du client***************************/
        public bool Update()
        {
            bool result = false;
            command = new SqlCommand("Update client set nom=@n, prenom=@p, telephone=@tel WHERE id=@id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@n", Lastname));
            command.Parameters.Add(new SqlParameter("@p", Firstname));
            command.Parameters.Add(new SqlParameter("@tel", Phone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        /*******************Suppression du client***************************/
        public bool Delete()
        {
            bool result = false;
            command = new SqlCommand("DELETE FROM client WHERE id = @id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        /*********recherche le client par son id --> retourne le client*********/
        public static Customer SearchCustomer(int idClient)
        {
            Customer customer = null;
            command = new SqlCommand("SELECT nom, prenom, telephone FROM client WHERE id= @idC", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@idC", idClient));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                customer = new Customer()
                {
                    Id = idClient,
                    Lastname = reader.GetString(0),
                    Firstname = reader.GetString(1),
                    Phone = reader.GetString(2)
                };
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return customer;
        }

        /*affichage du client recherché par son id sous forme de liste
         * car on va utiliser une listView pour afficher le client qui n'accepte que la forme liste*/
        public static List<Customer> SeeProducts(int id)
        {
            List<Customer> customers = new List<Customer>();
            command = new SqlCommand("Select nom, prenom, telephone FROM client WHERE id=@id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Customer custo = new Customer()
                {
                    Id = id,
                    Lastname = reader.GetString(0),
                    Firstname = reader.GetString(1),
                    Phone = reader.GetString(2),
                };
                customers.Add(custo);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return customers;
        }

        public override string ToString()
        {
            return $"Nom : {Lastname}, Prénom : {Firstname}, Téléphone : {Phone}";
        }
    }
}
