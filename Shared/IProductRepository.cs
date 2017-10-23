using System.Collections.Generic;

namespace SqlIntro
{
    public interface IProductRepository
    {
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        void DeleteProduct(int id);

        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        void UpdateProduct(Product prod);
    }
}