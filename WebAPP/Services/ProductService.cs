using System.Data.SqlClient;
using WebAPP.Models;

namespace WebAPP.Services
{
    public class ProductService
    {
        private static string db_Source = "azureappsdb2022.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_Password = "Azure@123";
        private static string db_database = "APP_DB";

        private SqlConnection GetSqlConnection()
        { 
          var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_Source;
            _builder.UserID = db_user;
            _builder.Password = db_Password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Products> GetProducts()
        { 
         
            var conn = GetSqlConnection(); 
            List<Products> products = new List<Products>();
            string cmdStmt = "Select ProductID,ProductName,Quantity from Products";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = cmdStmt;
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products p = new Products()
                    {
                        ProductID = reader.GetInt32(0),

                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(p);
;               }
            };

            return products;

        }

    }
}
