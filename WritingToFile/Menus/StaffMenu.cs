using System;

namespace FoodOderingApp.Enums
{
   public class StaffMenu
    {
        public StaffRepo staffRepo = new StaffRepo();
        private OrderRepo orderRepo = new OrderRepo();
        FoodRepo foodRepo = new FoodRepo();
        public void StaffOptionMenu()
        {
            Console.WriteLine("1. To Log-in \n0 To Main Menu");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid input . Try again");
            }
            switch(option)
            {
                case 1:
                Login();
                break;
                case 0:
                MainMenu.WelcomePage();
                break;
                default:
                Console.WriteLine("Invalid input. Try again");
                StaffOptionMenu();
                break;
            }
        }
        public void Login()
        {
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            var staffObj = staffRepo.Login(email,password);
            if (staffObj != null && staffObj.Role == Enums.Role.Manager)
            {
                Console.WriteLine("Login Successfuly...");
                ManagerMenu();
            }
            else if (staffObj != null && staffObj.Role != Enums.Role.Manager)
            {
                 Console.WriteLine("Login Successfuly...");
                StaffMenuContinue();
            }
            else 
            {
                 Console.WriteLine("You have not being registered. Only Admin can regiter you\nEnter any key back to Main Menu");
                 Console.ReadKey();
                 MainMenu.WelcomePage();
            }

        }
         public void ManagerMenu()
       {
          Console.WriteLine("1. To Add new Staff\n2. To Add food\n3. To Update food\n0. To Main Menu");
          int option;
          while(!int.TryParse(Console.ReadLine(),out option))
          {
             Console.WriteLine("Invalid input Try again");
          }
          switch(option)
          {
              case 1:
              AddNewStaff();
              break;
              case 2:
              foodRepo.AddFood();
              break;
              case 3:
              foodRepo.UpdateFood();
              break;
              case 0:
              MainMenu.WelcomePage();
              break;
              default:
              ManagerMenu();
              return;
          }
       }
        public void AddNewStaff()
       {
         Console.WriteLine("Enter Staff First Name");
         string fName = Console.ReadLine();
         Console.WriteLine("Enter Staff Last Name");
         string lName = Console.ReadLine();
         Console.WriteLine("Enter Staff email");
         string email = Console.ReadLine();
         Console.WriteLine("Enter  Staff Gender. \n1 for Male. \n2 for Female.\n3 for others");
         int gender;
         while(!int.TryParse(Console.ReadLine(),out gender))
         {
            Console.WriteLine("Invalid input. Try again");
         }
           Console.WriteLine("Enter Staff phone number");
         string phone = Console.ReadLine();
         Console.WriteLine("Enter Staff password");
         string password = Console.ReadLine();
         Console.WriteLine("Enter staff Role. \n2 for cook. \n3 for cleaner.");
         Role role;
          while(!Role.TryParse(Console.ReadLine(),out role))
          {
               System.Console.WriteLine("Invalid input. Try again");
          }
           staffRepo.AddNewStaff(fName,lName,email,phone,password,(Gender)gender,role);
           Console.WriteLine("Staff Registered successfuly...");
            ManagerContinueMenu();
       }
       public void StaffMenuContinue()
       {
         Console.WriteLine("1. To Check available food\n0. To Main Menu");
           int option;
           while(!int.TryParse(Console.ReadLine(),out option))
           {
               Console.WriteLine("Invalid input. Try again");
           }
           switch(option)
           {
               case 1:
               foodRepo.PrintOnlyReadyFood();
               break;
               case 0:
               MainMenu.WelcomePage();
               break;
               default:
               StaffMenuContinue();
               break;
           }
       }
       public void ManagerContinueMenu()
       {
           Console.WriteLine("1. To continue as staff\n2. To Register another staff\n0. To Main Menu");
           int option;
           while(!int.TryParse(Console.ReadLine(),out option))
           {
               Console.WriteLine("Invalid input. Try again");
           }
           switch(option)
           {
               case 1:
               StaffMenuContinue();
               break;
               case 2:
               ManagerMenu();
               break;
               case 0:
               MainMenu.WelcomePage();
               break;
               default:
               ManagerContinueMenu();
               return;
           }
       }
    }
}