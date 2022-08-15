using System;

namespace FoodOderingApp.Enums
{
   public class Customer:Person
    {
         public decimal Wallet {get;set;}
         public string CustomerNo {get;set;}
         public string Address {get;set;}
        public Customer(int id, string fName,string lName, string email,string password,string phone,string adress,decimal wallet):base (id,fName,lName,email,password,phone)
       {
         
         Wallet = wallet;
         Address = adress;
         CustomerNo = $"CU{Guid.NewGuid().ToString().Replace("_", "").Substring(0,5).ToUpper()} ";;
       }
       public Customer()
       {
         
       }
        internal static Customer FormatLine(string line)
        {
            var props = line.Split('\t');
            return new Customer(int.Parse(props[0]), props[1], props[2],props[3],props[4],props[5],props[6],decimal.Parse(props[7]));
        }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Email}\t{Password}\t{PhoneNumber}\t{Address}\t{Wallet}\t{CustomerNo}";
        }
    }
}