using System;
using System.Configuration;
using System.Linq;

namespace SqlIntroDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepositoryDb(connectionString);
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name + " " +
                                  "Product ID: " + prod.ProductId + " " +
                                  "Modified Date: \"{0}\"\n", prod.ModifiedDate);
            }

            repo.DeleteProduct(13);
            Console.WriteLine("You've deleted product with Product ID: ");

            var productA = new Product
            {
                ProductId = 15,
                Name = "My brand new product"
            };

            repo.UpdateProduct(productA);

            var productB = new Product()
            {
                Name = "My updated product",
                ProductId = 12,
                ModifiedDate = DateTime.UtcNow
            };

            repo.InsertProduct(productB);
            Console.WriteLine("Created new product with Name, Product ID, and Modified Date");

            Console.ReadLine();
        }

       
    }
}
