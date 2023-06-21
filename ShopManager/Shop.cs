using System;
using System.Linq;
using System.Security.Cryptography;
using ShopManager.Products;
using ShopManager.Products.Artwork;
using ShopManager.Products.Food;
using ShopManager.Products.Wine;

namespace ShopManager
{
    public class Shop
    {
        public float Balance { get; private set; }
        public Product[] Products { get; }

        public Shop(float balance, Product[] products)
        {
            Balance = balance;
            Products = products;
        }


        private void AddMoney(float money) => Balance += money;

        private void RemoveMoney(float money) => Balance -= money;

        public (string Name, int Quantity)[] GetStock()
        {
            (string Name, int Quantity)[] stock = { };
            for (int i = 0; i < Products.Length; i++)
            {
                var quantity = 1;
                var name = Products[i].Name;
                if (Products[i] is Stackable)
                {
                    quantity = (Products[i] as Stackable).Quantity;
                }

                if (Products[i] is Wine)
                {
                    name = $"{Products[i].Name} {(Products[0] as Wine).Age}yrs";
                    quantity = (Products[i] as Wine).Quantity;
                }
                stock.Append((name, quantity));
            }
            return stock;
        }

        public int FindProductByName(string name)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Buy(int index, int quantity)
        {
            
            throw new NotImplementedException();
        }
        
        public void Buy(string name, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Sell(int index, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Sell(string name, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ShowInfo(string name)
        {
            throw new NotImplementedException();
        }
        
        public float UseShoppingList(ShoppingList shoppingList)
        {
            throw new NotImplementedException();
        }
    }
}