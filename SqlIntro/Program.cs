using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=unsecuresqlpass;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name + " " +
                                  "Product ID: " + prod.ProductId + " " +
                                  "Modified Date: \"{0}\"\n", prod.ModifiedDate);
            }

            repo.DeleteProduct(10);
            Console.WriteLine("You've deleted product with Product ID: ");

            var productA = new Product
            {
                ProductId = 319,
                Name = "My brand new product"
            };

            repo.UpdateProduct(productA);

            var productB = new Product()
            {
                Name = "My new product",
                ProductId = 13,
                ModifiedDate = DateTime.UtcNow
            };

            repo.InsertProduct(productB);
            Console.WriteLine("Created new product with Name, Product ID, and Modified Date");

            Console.ReadLine();
        }

       
    }
}
