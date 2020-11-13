using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{
   
    public class Store
    {
       private string _name;
        private List<Location> Locations;

       public string Name {
           get => _name;
           set { 
           
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message: "invalid FIrstname", paramName: nameof(value));
                }
                _name = value;
            }
       }
       
        public Store()
        {
             
              Locations = new List<Location>();
        }

        public void addLocations(string city)
        {

                Location location = new Location(city);
                Locations.Add(location);
        }
        
       public List<string> getLocations( )
       {
         var locations = new List<string>();
    
           foreach (Location location in Locations)
            {
                locations.Add(location.City);
            }
            return locations;
       }

    }
}