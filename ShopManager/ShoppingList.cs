using System;
using ShopManager.Products;

namespace ShopManager
{
    public class ShoppingItem
    {
        public readonly string Name;
        public readonly int Quantity;

        public ShoppingItem(string name, int quantity)
        {
            throw new NotImplementedException();
        }
    }
    public class ShoppingList
    {
        public float Budget { get; set; }
        public ShoppingItem[] Items { get; private set; }

        public ShoppingList(int budget)
        {
            throw new NotImplementedException();
        }

        public ShoppingList(int budget, ShoppingItem[] items)
        {
            throw new NotImplementedException();
        }


        public void AddItem(ShoppingItem item)
        {
            throw new NotImplementedException();
        }
    }
}