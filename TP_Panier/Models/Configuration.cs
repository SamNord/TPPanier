using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Panier.Models
{
    class Configuration
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\TP_Panier;Integrated Security=True");
    }
}
