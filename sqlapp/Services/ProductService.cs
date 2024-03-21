using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services
{

    // This service will interact with our Product data in the SQL database
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlConnection GetConnection()
        {

            return new SqlConnection(_configuration.GetConnectionString("database"));
        }
        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new List<Product>();
            // set up the tables if they don't exist
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot", "setup.sql");
            string _createTable = File.ReadAllText(path);


            string _statement = "SELECT ProductID,ProductName,Quantity from Products";

            SqlConnection _connection = GetConnection();

            _connection.Open();

            SqlCommand createTableCommand = new SqlCommand(_createTable, _connection);
            createTableCommand.ExecuteNonQuery();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;
        }

    }
}

