using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DataAccessLayer.config
{
    public class Connection
    {
        public static SqlConnection cnn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Friends;Integrated Security=True");
        
    }
}
