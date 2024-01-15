using ProductApi.Models;
using System.Data.SqlClient;

namespace ProductApi.Service
{
    public class ProductService
    {

        public SqlConnection GetConnection()
        {
            string connectionString = "Server=tcp:sqlserver01001.database.windows.net,1433;Initial Catalog=sqldbapp0100;Persist Security Info=False;User ID=sqlusr;Password=PR1M4V3R42023..;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(connectionString);
        }


        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            string query = "SELECT ProductId, ProductName, Quantity FROM Products";
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                productList.Add(new Product()
                {
                    ProductId = reader.GetString(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                });
            }
            conn.Close();
            return productList;
        }

        public Product GetProduct(string productId)
        {
            Product product = new Product();
            string query = $"SELECT ProductId, ProductName, Quantity FROM Products WHERE ProductId = '{productId}'";
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                product = new Product()
                {
                    ProductId = reader.GetString(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                };
            }
            conn.Close();
            return product;
        }

    }
}
