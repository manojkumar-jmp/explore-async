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
    /// <summary>
    /// Provides business logic operations related to products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        public ProductService()
        {
            _productRepository = new JsonProductRepository();
        }

        /// <summary>
        /// Retrieves all products, simulating a business logic processing delay.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> GetAllProducts()
        {
            SimulateBusinessLogicProcessingDelay();
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// Simulates a business logic processing delay.
        /// 5 second artificial delay in business logic processing.
        /// This will block the calling thread (including the UI if called directly from it), 
        /// which is typical for simulating synchronous business logic delays.
        /// </summary>
        private void SimulateBusinessLogicProcessingDelay()
        {
            System.Threading.Thread.Sleep(5000); // 5 second artificial delay in business logic processing.
        }
    }
}
