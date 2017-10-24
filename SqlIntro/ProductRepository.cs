using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"select Name, ProductId, ModifiedDate from product";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product
                    {
                        Name = dr["Name"].ToString(),
                        ListPrice = (int)dr["ProductId"],
                        ModifiedDate = (DateTime)dr["ModifiedDate"]
                    };
                }
            }
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM product WHERE ProductID = " + id;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update product set name = @name where productid = @id";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.Parameters.AddWithValue("@id", prod.ProductId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT into product (Name, ProductId, ModifiedDate) values (@Name, @ProductId, @ModifiedDate)";
                cmd.Parameters.AddWithValue("@Name", prod.Name);
                cmd.Parameters.AddWithValue("@ProductId", prod.ProductId);
                cmd.Parameters.AddWithValue("ModifiedDate", prod.ModifiedDate);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
