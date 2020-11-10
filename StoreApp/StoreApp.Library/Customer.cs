using System;

namespace StoreApp.Library
{

    public class Customer
    {

        //name
        private string _firstName;
        private string _lastName;

        //default store id


       // set names to not allow empty string
        public string FirstName {
          get => _firstName; 
          set {
              if ( value.Length == 0){
                   throw new ArgumentException("Name field must not be empty.");
              }
              _firstName = value;
          }
        }

        public string LastName {
            get => _lastName;
            set {
                if ( value.Length == 0){
                   throw new ArgumentException("Name field must not be empty.");
              }
              _lastName = value;
            }
        }


    public Customer ( string firstName, string lastName){
        FirstName = firstName;
        LastName = lastName;
    }

    }
}