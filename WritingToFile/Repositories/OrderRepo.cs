using System;

namespace FoodOderingApp.Enums
{
     public class OrderRepo
    {
         FoodRepo foodRepo = new FoodRepo();
        private readonly Customer customer = new Customer();
        private static int myIndex = 1;
        public List<Food> carts = new List<Food>();
        decimal TotalAmount = 0.00m;
        //  decimal amount = 0.00m;
        public  void OrderFood(Customer customer1)
        {
            foodRepo.PrintAllReadyFood();
            Console.WriteLine("Please choose your food choice by their corresponding numbers");
            int choosedId;
            while (!int.TryParse(Console.ReadLine(), out choosedId))
            {
                Console.WriteLine("Enter a valid option");
            }
            var food = foodRepo.GetFoodType(choosedId);
            if (food == null)
            {
                Console.WriteLine("Food not Available");
                OrderFood(customer1);
            }
             Console.WriteLine("How many plates would you like to order");
            int numberOfSpoon;
            while (!int.TryParse(Console.ReadLine(), out numberOfSpoon))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            if (numberOfSpoon > 7)
            {
                Console.WriteLine("The maximum number of plates is 7. Please Try again");
                OrderFood(customer1);
            }
            
            Console.WriteLine("Do you like to Add to cart. \nEnter 1 for yes and 2 for no");
            
             TotalAmount += food.Price * numberOfSpoon;
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Try again");
            }
            switch (choice)
            {
                case 1:
                OrderFood(customer1);
                break;
                case 2:
                Console.WriteLine("Total amount is " + "#" + TotalAmount);

                if (customer1.Wallet < TotalAmount)
                {
                    Console.WriteLine("Insuficient funds. Enter 1 to fund wallet. 0 to Cancel order");
                    int option;
                    while(!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid input. Try again");
                    }
                    switch(option)
                    {
                        case 1:
                        FundWallet(customer1);
                        customer1.Wallet = customer1.Wallet - TotalAmount;
                        Console.WriteLine("Thank you for your patronage. Your wallet balance is " +"#" + customer1.Wallet);
                        // CustmerRepo.RefreshFile();
                        TotalAmount = 0;
                        Console.WriteLine("Enter any key to log-out");
                        Console.ReadKey();
                        MainMenu.WelcomePage();
                        break;
                        case 0:
                        TotalAmount = 0;
                        MainMenu.WelcomePage();
                        break;
                    }
                }
                else
                {
                     customer1.Wallet = customer1.Wallet - TotalAmount;
                     TotalAmount = 0;
                     Console.WriteLine("Thank you for your patronage. Your wallet balance is " +"#" + customer1.Wallet);
                    //   CustmerRepo.RefreshFile();
                      Console.WriteLine("Enter any key to log out");
                      Console.ReadKey();
                      MainMenu.WelcomePage();
                }
                 break;
            }
        }
        public void FundWallet(Customer customer1)
       {
           Console.WriteLine("Enter amount to credit your wallet");
           decimal amount = decimal.Parse(Console.ReadLine());
           customer1.Wallet += amount;
           Console.WriteLine($"Wallet successfully funded. Your total Wallet amount is #{customer1.Wallet}.");
        //    CustmerRepo.RefreshFile();
        
       }
        public void FundWalletWithoutOrder(Customer customer1)
       {
           Console.WriteLine("Enter amount to credit your wallet");
           decimal amount = decimal.Parse(Console.ReadLine());
           customer1.Wallet += amount;
          Console.WriteLine($"Wallet successfully funded. Your total Wallet amount is #{customer1.Wallet}.");
           AfterFundWallet(customer1); 
            // CustmerRepo.RefreshFile();
       }

        public void AfterFundWallet(Customer customer1)
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
               OrderFood(customer1);
               break;
               case 0:
               MainMenu.WelcomePage();
               break;
               default:
               AfterFundWallet(customer1);
               return;
           }
        }
    }
}