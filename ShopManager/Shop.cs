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
            (string Name, int Quantity)[] stock = new (string Name, int Quantity)[Products.Length];

            for (int i = 0; i < Products.Length; i++)
            {
                var quantity = 1;
                var name = Products[i].Name;

                if (Products[i] is Stackable stackableProduct)
                {
                    quantity = stackableProduct.Quantity;
                }

                if (Products[i] is Wine wineProduct)
                {
                    name = $"{wineProduct.Name} {wineProduct.Age}yrs";
                    quantity = wineProduct.Quantity;
                }

                if (Products[i] is Artwork artworkProduct && !artworkProduct.InStock)
                {
                    quantity = 0;
                }

                stock[i] = (name, quantity);
            }

            return stock;
        }

        public int FindProductByName(string name)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i] is Stackable stackableProduct && stackableProduct.Name == name)
                {
                    return i;
                }

                if (Products[i] is Wine wineProduct && $"{wineProduct.Name} {wineProduct.Age}yrs" == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Buy(int index, int quantity)
        {
            var product = Products[index];
            if (index < 0 || index > Products.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (Balance < product.Price)
            {
                throw new NotEnoughMoneyException();
            }
            
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }

            if (product is Stackable)
            {
                if (quantity > (product as Stackable).Quantity)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price * quantity;
                // (product as Stackable).Quantity += quantity;
            }

            if (product is Artwork)
            {
                if (quantity > 1)
                {
                    throw new InvalidQuantityException();
                }

                if (FindProductByName(product.Name) != -1)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price;
                Products.Append(product);
            }

            if (product is Wine)
            {
                if (quantity > (product as Wine).Quantity)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price * quantity;
                // (product as Wine).Quantity += quantity;
            }
        }
        
        public void Buy(string name, int quantity)
        {
            var index = FindProductByName(name);
            var product = Products[index];
            if (index < 0 || index > Products.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (Balance < product.Price)
            {
                throw new NotEnoughMoneyException();
            }
            
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }

            if (product is Stackable)
            {
                if (quantity > (product as Stackable).Quantity)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price * quantity;
                // (product as Stackable).Quantity += quantity;
            }

            if (product is Artwork)
            {
                if (quantity > 1)
                {
                    throw new InvalidQuantityException();
                }

                if (FindProductByName(product.Name) != -1)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price;
                Products.Append(product);
            }

            if (product is Wine)
            {
                if (quantity > (product as Wine).Quantity)
                {
                    throw new NotEnoughItemsException();
                }

                Balance -= product.Price * quantity;
                // (product as Wine).Quantity += quantity;
            }
        }

        public void Sell(int index, int quantity)
        {
            var product = Products[index];
            if (index < 0 || index > Products.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (Balance < product.Price * product.SaleFactor * quantity)
            {
                throw new NotEnoughMoneyException();
            }
            
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }

            if (product is Stackable)
            {
                Balance += product.Price * product.SaleFactor * quantity;
                // (product as Stackable).Quantity -= quantity;
            }

            if (product is Artwork)
            {
                Balance += product.Price * product.SaleFactor;
                (product as Artwork).InStock = false;
            }

            if (product is Wine)
            {
                Balance += product.Price * product.SaleFactor * quantity;
                // (product as Wine).Quantity -= quantity;
            }
        }

        public void Sell(string name, int quantity)
        {
            var index = FindProductByName(name);
            var product = Products[index];
            if (index < 0 || index > Products.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (Balance < product.Price * product.SaleFactor * quantity)
            {
                throw new NotEnoughMoneyException();
            }
            
            if (quantity < 0)
            {
                throw new InvalidQuantityException();
            }

            if (product is Stackable)
            {
                Balance += product.Price * product.SaleFactor * quantity;
                // (product as Stackable).Quantity -= quantity;
            }

            if (product is Artwork)
            {
                Balance += product.Price * product.SaleFactor;
                (product as Artwork).InStock = false;
            }

            if (product is Wine)
            {
                Balance += product.Price * product.SaleFactor * quantity;
                // (product as Wine).Quantity -= quantity;
            }
        }

        public void ShowInfo(string name)
        {
            int place = FindProductByName(name);
            if (place == -1)
            {
                Console.WriteLine($"Product '{name}' not found");
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