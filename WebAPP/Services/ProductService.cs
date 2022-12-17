using System.Data.SqlClient;
using WebAPP.Models;

namespace WebAPP.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetSqlConnection()
        {

            return new SqlConnection(_configuration.GetConnectionString("SqlConnectionString"));
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
                    ;
                }
            };

            return products;

        }

    }
}
