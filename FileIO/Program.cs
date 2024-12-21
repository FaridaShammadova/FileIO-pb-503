using System.Text.Json;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\USER\\Desktop\\FileIO\\";

            if (!File.Exists(path + "example.txt"))
            {
                using (File.Create(path + "example.txt"))
                {
                }
            }

            ProductService service = new ProductService();

            bool check = false;

            while (!check)
            {
                Console.WriteLine("1. All Products");
                Console.WriteLine("2. Get product");
                Console.WriteLine("3. Create product");
                Console.WriteLine("4. Delete product ");
                Console.WriteLine("0. Exit");

                int input= Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        List<Product> allProducts = service.GetAll();

                        foreach (var product1 in allProducts)
                        {
                            Console.WriteLine($"Id: {product1.Id} - Name: {product1.Name} - Cost price: {product1.CostPrice} - Sale price: {product1.SalePrice}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Product? wantedProduct = service.GetById(id);

                        if (wantedProduct != null)
                        {
                            Console.WriteLine($"Id: {wantedProduct.Id} - Name: {wantedProduct.Name} - Cost price: {wantedProduct.CostPrice} - Sale price: {wantedProduct.SalePrice}");
                        }
                        else
                        {
                            Console.WriteLine("No product found.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter new product name:");
                        string? name= Console.ReadLine();

                        Console.WriteLine("Enter new product cost price:");
                        double costPrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter new product sale price:");
                        double salePrice = Convert.ToDouble(Console.ReadLine());

                        Product product = new Product()
                        {
                            Name = name,
                            CostPrice = costPrice,
                            SalePrice = salePrice
                        };
                        if (salePrice > costPrice)
                        {
                            service.Create(product);
                            Console.WriteLine("New product added.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter id for delete product:");
                        int deletedId = Convert.ToInt32(Console.ReadLine());

                        service.Delete(deletedId);
                        Console.WriteLine("Product deleted.");
                        break;

                    case 0:
                        check = true;
                        Console.WriteLine("Process has ended.");
                        break;
                }
            }
        }
    }
}
