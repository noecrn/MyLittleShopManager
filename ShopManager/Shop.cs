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

                if (Products[i] is Artwork && !(Products[i] as Artwork).InStock)
                {
                    quantity = 0;
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
            int place = FindProductByName(name);
            if (place == -1)
            {
                Console.WriteLine($"Product {name} not found");
            }
            else
            {
                var quantity = 1;
                if (Products[place] is Stackable)
                {
                    quantity = (Products[place] as Stackable).Quantity;
                }

                if (Products[place] is Wine)
                {
                    quantity = (Products[place] as Wine).Quantity;
                }

                if (Products[place] is Seafood)
                {
                    quantity = (Products[place] as Seafood).Quantity;
                }
                Console.WriteLine($"Name: {Products[place].Name}\nPrice: {Products[place].Price}\nQuantity: {quantity}\n");
            }
        }
        
        public float UseShoppingList(ShoppingList shoppingList)
        {
            throw new NotImplementedException();
        }
    }
}