using System;

namespace ShopManager.Products.Wine
{
    public abstract class Wine : Stackable
    {
        public override float SaleFactor => (float)4.5;
        protected abstract float PriceFactor { get; }
        public int Age { get; protected set; }
        public override float Price => (int)(SaleFactor * Age);

        public override string GetInfo()
        {
            return $"Name: {Name}\nPrice: {Price}\nAge: {Age} years\nQuantity: {Quantity}\n";
        }

        public override string ToString() => $"{Name} {Age}yrs";
    }
}