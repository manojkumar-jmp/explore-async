using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.Contracts;
using Demo.Data.Contracts.Models;
using Newtonsoft.Json;


namespace Demo.Data.Json
{
    public class JsonProductRepository : IProductRepository
    {
        private readonly string _productFilePath = "DataFiles/products.json";
        public List<Product> GetProducts()
        {
            if(!File.Exists(_productFilePath))
                return new List<Product>();
            
            var json = File.ReadAllText(_productFilePath);

            return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
            
        }

        public void AddProduct(Product product)
        {
            var products = GetProducts();
            if (product.Id <= 0)
                product.Id = products.Any() ? GetProducts().Max(p => p.Id) + 1 : 1;

            products.Add(product);
            SaveProducts(products); 

        }

        private void SaveProducts(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(_productFilePath, json);

        }
    }
}
