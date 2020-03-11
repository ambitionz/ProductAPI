using ApiProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProduct.Controllers
{
    public class ProductsController : ApiController
    {
        private Product[] products; // From model class 

        // Constructor
        public ProductsController()
        {
            products = new Product[]
            {
                new Product{Id=1, Name="Tomato", Category="Food", Price=1.5M},
                new Product{Id=2, Name="Yoyo", Category="Toy", Price=4.0M},
                new Product{Id=3, Name="Hammer", Category="Hardware", Price=12.5M}
            };
        }

        // /api/products/
        public IEnumerable<Product> GetAllProducts() // also List is possible
        {
            return products;
        }
        // /api/products/3
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(hrm);
            }
            return product;
        }

        // /api/products?cateogry=food
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(p => String.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
