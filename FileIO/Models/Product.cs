using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    public class Product
    {
        static int _counter;
        int _id;
        double _salePrice;

        public int Id { get; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice {
            get => _salePrice;

            set
            {
                if (value > CostPrice)
                {
                    _salePrice = value;
                }
                else
                {
                    Console.WriteLine("Sale price cannot be less cost price!");
                }
            }
        }

        public Product()
        {
            Id = ++_counter;
        }
    }
}
