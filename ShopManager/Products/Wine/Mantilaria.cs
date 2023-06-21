using System;

namespace ShopManager.Products.Wine
{
    public class Mantilaria : Wine
    {
        protected override float PriceFactor => (float)2.3;

        public Mantilaria(int age = 100, int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}