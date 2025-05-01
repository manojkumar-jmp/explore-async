using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.Contracts.Models;

namespace Demo.Business.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }
}
