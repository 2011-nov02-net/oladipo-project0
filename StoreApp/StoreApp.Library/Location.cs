using System;
using System.Collections.Generic;
using System.Linq;
namespace StoreApp.Library
{
    public class Location
    {
        //location city
        public string City { get; }
        //location id
        private string LocationId { get; }
        public Dictionary<string, int> Inventory;

        //constructor

        private static int LocationIdSeed = 1;
        
        public Location (){
            this.LocationId = LocationIdSeed.ToString();
            LocationIdSeed++;
        }
        public Location(string city)
        {
            this.LocationId = LocationIdSeed.ToString();
            LocationIdSeed++;
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

        public List<string> getInventory()
        {
            var inventory = new List<string>();
            int index = 1;

            foreach (KeyValuePair<string, int> product in Inventory)
            {
                string value = $"{index.ToString()}\t{product.Key}\t{product.Value.ToString()}";
                inventory.Add(value);
                index++;
            }
            
            return inventory;
        }

    }


}