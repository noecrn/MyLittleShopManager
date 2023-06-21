using System;
using ShopManager.Products.Food;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Seafood a = new Seafood(3);
            int b = 2;
            Seafood c = (Seafood)(a + b);           // c.Quantity == 5

            Moussaka a1 = new Moussaka(3);
            int b1 = 2;
            Moussaka c1 = a1 - b1 as Moussaka;          // c.Quantity == 1
        }
    }
}