using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.Contracts.Models;

namespace Demo.Data.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
    }
}
