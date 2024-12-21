using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileIO
{
    public class ProductService
    {
        string path = "C:\\Users\\USER\\Desktop\\FileIO\\example.txt";
        public void Create(Product product)
        {
            List<Product> products = GetAll();
            bool idExists = products.Any(p => p.Id == product.Id);

            if (idExists)
            {
                Console.WriteLine("Product ID already exists.");
                return;
            }

            var productJson =JsonSerializer.Serialize(product);

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(productJson);
            }
        }

        public Product? GetById(int id)
        {
            List<Product> products = GetAll();
            var wantedProduct = products.Find(p=> p.Id == id);
            return wantedProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            if (File.Exists(path))
            {
                string[] contents = File.ReadAllLines(path);

                foreach (var item in contents)
                {
                    Product? product = JsonSerializer.Deserialize<Product>(item);
                    if (product != null && !products.Any(p => p.Id == product.Id))
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public void Delete(int id)
        {
            List<Product> products = GetAll();
            
            var productIndex = products.FindIndex(p => p.Id == id);

            if (productIndex != -1)
            {
                products.RemoveAt(productIndex);
                SaveAll(products);
            }
        }

        private void SaveAll(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var product in products)
                {
                    string productJson = JsonSerializer.Serialize(product);
                    writer.WriteLine(productJson);
                }
            }
        }
    }
}
