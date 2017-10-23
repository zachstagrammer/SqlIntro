using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlIntro;

namespace Dapper
{
    public class ProductRepository: IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product prod)
        {
            throw new NotImplementedException();
        }
    }
}
