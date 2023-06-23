using System;

namespace ShopManager.Products
{
    public abstract class Stackable : Product
    {
        public int Quantity { get; protected set; }

        public static Stackable operator +(Stackable stack, int quantity)
        {
            Stackable newStack = (Stackable)stack.MemberwiseClone();
            newStack.Quantity += quantity;
            return newStack;
        }

        public static Stackable operator -(Stackable stack, int quantity)
        {
            Stackable newStack = (Stackable)stack.MemberwiseClone();
            newStack.Quantity -= quantity;
            return newStack;
        }
    }
}