using System;

namespace ShopManager.Products
{
    public abstract class Stackable : Product
    {
        public int Quantity { get; protected set; }

        public static Stackable operator +(Stackable stack, int quantity)
        {
            var stackClone = stack.MemberwiseClone();
            stack.Quantity += quantity;
            return stack;
        }

        public static Stackable operator -(Stackable stack, int quantity)
        {
            var stackClone = stack.MemberwiseClone();
            stack.Quantity -= quantity;
            return stack;
        }
    }
}