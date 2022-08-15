using System;
using MySql.Data.MySqlClient;
namespace FoodOderingApp.Enums
{
    public class CustmerRepo
    {
         public OrderRepo orderRepo = new OrderRepo();
          private TextWriter textWriter;
          private static int count = 1;
        static List<Customer> customers = new List<Customer>();
        public CustmerRepo()
        {
            customers = new List<Customer>();
            string path = "Customer.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines("Customer.txt");
                foreach (var line in lines)
                {
                    var customer = Customer.FormatLine(line);
                    customers.Add(customer);
                }
            } 
        } 
         public void Register(string fName, string lName, string email,string password, string phone,string address)
         {
            decimal wallet = 0.00m;
           var customer = new Customer(count,fName,lName,email,password,phone,address,wallet);
           customers.Add(customer);
           TextWriter writer = new StreamWriter("Customer.txt",true);
           writer.WriteLine(customer.ToString());
           writer.Close();    
             Console.WriteLine($"You have successfully created an account and your customer number is {customer.CustomerNo}");
           System.Console.WriteLine($"We have given you a bonus of {customer.Wallet}.");
           count++;
           RefreshFile();
         }
         
         public Customer Login(string email, string password)
        {
           var  customer = GetCustomer(email);
           if (customer != null && customer.Password == password)
           {
               return customer;
           }
           return null;
        }
         private Customer GetCustomer(string email)
       {
           for (int i = 0; i < customers.Count; i++)
           {
               if (customers[i] != null && customers [i].Email == email)
               {
                   return customers[i];
               } 
           }
           return null;
        }
        public void CheckWallet(Customer customer)
        {
           
            Console.WriteLine("Your wallet balance is " + "#" + customer.Wallet + ".00");
            CWallet:
            Console.WriteLine("Would you like to fund your wallet\n1. To fund wallet  2. To order food  0. To Main Main");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid option. Try again");
            }
            switch(option)
            {
                case 1:
                orderRepo.FundWalletWithoutOrder(customer);
                break;
                case 2:
                orderRepo.OrderFood(customer);
                break;
                case 0:
                MainMenu.WelcomePage();
                break;
                default:
                goto CWallet;
                
            }
        }
         public void AfterFundWallet(Customer customer)
        {
           Console.WriteLine("1. To Order food\n0. To Main Menu");
           int option;
           while(!int.TryParse(Console.ReadLine(),out option))
           {
               Console.WriteLine("Invalid Input. Try again");
           }
           switch(option)
           {
               case 1:
               orderRepo.OrderFood(customer);
               break;
               case 0:
               MainMenu.WelcomePage();
               break;
               default:
               AfterFundWallet(customer);
               return;
           }
          
        }
         public  static void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Customer.txt");
            foreach (Customer customer in customers)
            {
                writer.WriteLine(customer);
            }
            writer.Flush();
            writer.Close();
        }
        //  public void InsertStudent(Customer customer)
        // {           
        //    try
        //    {
        //        connection = new MySqlConnection(connect);
        //        MySqlCommand command = new MySqlCommand($"Insert into Customer (FirstName,LastName,Email,Passwords,Phone,Address,Wallet,CustomerNo) values ('{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.Password}','{customer.PhoneNumber}','{customer.Address}',{customer.Wallet},'{CustomerNo}')",connection);
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        Console.WriteLine("Table Inserted successfully");
        //    }
        //    catch (Exception e)
        //    {
        //         Console.WriteLine("OOps, Not Inserted");
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    } 
        // }
         
    }
    
}