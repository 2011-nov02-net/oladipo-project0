using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Library
{
    public class Store
    {
        //store name
        public string Name {get; set;}
       //list of locations
        private List<Location> Locations;


        public Store(string name){
              Name = name;
              Locations = new List<Location>();
        }

        public void addLocations(Location name){
            if ( Locations.Contains(name)){
                return;
            }
            else {
                Locations.Add(name);
            }
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