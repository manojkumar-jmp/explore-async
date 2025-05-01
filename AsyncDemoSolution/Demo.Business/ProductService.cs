using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Business.Contracts;
using Demo.Data.Contracts;
using Demo.Data.Contracts.Models;
using Demo.Data.Json;

namespace Demo.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService( )
        {
            _productRepository = new JsonProductRepository();
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
