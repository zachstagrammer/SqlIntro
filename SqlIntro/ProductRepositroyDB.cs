using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntroDapper
{
    public class ProductRepositoryDb
    {
        private readonly string _connectionString;

        public ProductRepositoryDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT * from product");
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM product WHERE ProductID = @id", new { id = productId });
            }
            
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE Product Set Name = @Name Where ProductId = @id", new {id = prod.ProductId, name = prod.Name});
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT Product (Name) values (@Name)", new { id = prod.ProductId, name = prod.Name });
            }
        }
    }
}
