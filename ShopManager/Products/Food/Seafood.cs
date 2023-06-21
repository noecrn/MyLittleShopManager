using System;

namespace ShopManager.Products.Food
{
    public class Seafood : Food
    {
        public override float Price => 10;

        public Seafood(int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}