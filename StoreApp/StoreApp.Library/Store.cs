using System;
using System.Collections.Generic;
using System.Linq;
namespace StoreApp.Library
{
    public class Store
    {
        //location city
        private string City { get; }
        //location id
        private string StoreID { get; }
        public Dictionary<string, int> Inventory;

        //constructor

        private static int storeIdSeed = 1;

        public Store(string city)
        {
            this.StoreID = storeIdSeed.ToString();
            storeIdSeed++;
            this.City = city;
            Inventory = new Dictionary<string, int>();

        }

        //add inventory
        public void addInventory(string name, int quantity)
        {
            if (Inventory.ContainsKey(name))
            {
                Inventory[name] += quantity;
            }
            else
            {
                Inventory.Add(name, quantity);
            }

        }
        //remove inventory
        public void reduceInventory(string name, int quantity)
        {
            Inventory[name] -= quantity;
        }

        public void deleteItemsFromInventory(string name)
        {
            Inventory.Remove(name);
        }

        public string getInventory()
        {
            var inventory = new System.Text.StringBuilder();
            int index = 1;

            foreach (KeyValuePair<string, int> product in Inventory)
            {
                string value = $"{index}\t{product.Key}\t{product.Value}";
                inventory.AppendLine(value);
                index++;
            }
            
            return inventory.ToString();
        }

    }


}