using System;

namespace ShopManager.Products.Food
{
    public class Feta : Food
    {
        public override float Price => 15;

        public Feta(int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}