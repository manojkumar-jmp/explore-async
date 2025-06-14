using Demo.Data.Contracts;
using Demo.Data.Contracts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Data.Json
{
    /// <summary>
    /// Provides methods to interact with product data stored in a JSON file.
    /// </summary>
    public class JsonProductRepository : IProductRepository
    {
        private readonly string _productFilePath = "DataFiles/products.json";


        /// <summary>
        /// Retrieves all products from the JSON data file, simulating a data access delay.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> GetProducts()
        {
            SimulateDataProcessingDelay();
            if (!File.Exists(_productFilePath))
                return new List<Product>();
            
            var json = File.ReadAllText(_productFilePath);

            return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
            
        }

        /// <summary>
        /// Simulates a delay to represent data processing time.
        /// </summary>
        private void SimulateDataProcessingDelay()
        {
            System.Threading.Thread.Sleep(5000); // 5 second artificial delay in business logic processing.
        }

        /// <summary>
        /// Adds a new product to the JSON data file.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to add.</param>
        public void AddProduct(Product product)
        {
            var products = GetProducts();
            if (product.Id <= 0)
                product.Id = products.Any() ? GetProducts().Max(p => p.Id) + 1 : 1;

            products.Add(product);
            SaveProducts(products); 

        }

        /// <summary>
        /// Saves the list of products to the JSON data file.
        /// </summary>
        /// <param name="products">The list of <see cref="Product"/> objects to save.
        private void SaveProducts(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(_productFilePath, json);

        }
    }
}
