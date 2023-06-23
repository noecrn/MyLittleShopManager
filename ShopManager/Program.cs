using System;
using ShopManager.Products;
using ShopManager.Products.Food;
using ShopManager.Products.Wine;

namespace ShopManager // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Seafood(15),
                new Moussaka(9),
                new Feta(12),
            };

            Shop shop = new Shop(1000, products);
        }
    }
}