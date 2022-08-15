using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FoodOderingApp.Enums
{
    class FoodRepo
    {
        private static int count = 1;
        private TextWriter textWriter;

        public static List<Food> foods;
          public  FoodRepo()
        {
            foods = new List<Food>();
            string path = "Food.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines("Food.txt");
                foreach (var line in lines)
                {
                    var food = Food.LineFomart(line);
                    foods.Add(food);
                }
            } 
        } 
        public void PrintAllReadyFood()
        {
            foreach (var food in foods)
            {
                    if (foods[0] != null)
                {
                     Console.Write(food.FoodId + "." + " ");
                     Console.Write("Food Name: " + food.FoodTypeName + " ");
                     Console.Write("Price: " + food.Price + " per plate");
                     Console.WriteLine();
                    
                }
                 else if(foods[0] == null)
                {
                    Console.WriteLine("No food available.Enter any key back to Main Menu");
                    Console.ReadKey();
                    MainMenu.WelcomePage();
                }
            }
        }
         public void AddFood()
        {
             START:
            Console.WriteLine("Enter food name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter food price per plate");
            decimal price;
            while(!decimal.TryParse(Console.ReadLine(),out price))
            {
                Console.WriteLine("invalid price input. Try again.");
            }
            var food = new Food(count,name, price);
            foods.Add(food);
            TextWriter writer = new StreamWriter("Food.txt",true);
            writer.WriteLine(food.ToString());
            writer.Close();
            Console.WriteLine("Food type successfuly addad to list...");
            count++;
            Console.WriteLine("Would you like to add another food.\n1. yes\n2. no\n0. To Main Menu");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Try again");
            }
            switch(option)
            {
                case 1:
                goto START;
                case 2:
                AfterPrintAllReadyFood();
                break;
                case 0:
                MainMenu.WelcomePage();
                break;
                default:
                AfterPrintAllReadyFood();
                return;
            }
        }
        public void AfterPrintAllReadyFood()
        {
             Console.WriteLine("This are the foods added");
           foreach (var food in foods)
            {
                    Console.Write(food.FoodId + "." + " ");
                     Console.Write("Food Name: " + food.FoodTypeName + " ");
                     Console.Write("Price: " + food.Price + " per plate");
                     Console.WriteLine();
            }
            Pfood:
            Console.WriteLine("Enter 0 To log out");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            switch(option)
            {
                case 0:
                MainMenu.WelcomePage();
                break;
                default:
               goto Pfood;
            }
        }
         public void PrintOnlyReadyFood()
         {
            foreach(var food in foods)
            {
                if (foods[0] != null)
                {
                     Console.Write(food.FoodId + "." + " ");
                     Console.Write("Food Name: " + food.FoodTypeName + " ");
                     Console.Write("Food Name: " + food.Price + " per plate");
                     Console.WriteLine();
                    
                }
                 else if(foods[0] == null)
                {
                    Console.WriteLine("No food available.Enter any key back to Main Menu");
                    Console.ReadKey();
                    MainMenu.WelcomePage();
                }
            }
             PFood:
            Console.WriteLine("Enter 0 to main menu");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid input");
            }    
            switch(option)
            {
                case 0:
                MainMenu.WelcomePage();
                break;
                default:
                goto PFood;
            }
         }
         public void UpdateFood()
         {
             PrintAllReadyFood();
             Console.WriteLine("Enter food id to be updated");
             int id = int.Parse(Console.ReadLine());
             Console.WriteLine("1. To change food\n2. To Remove food from list");
             int opt;
             while(!int.TryParse(Console.ReadLine(),out opt))
             {
                 Console.WriteLine("Invalid Input. Try agin");
             }
             switch(opt)
             {
                 case 1:
                 break;
                 case 2:
                 foods.Remove(foods[id-1]);
                 RefreshFile();
                 Update:
                  Console.WriteLine("Would you like to update another food.\n1. yes\n2. no");
                 int op;
             while(!int.TryParse(Console.ReadLine(),out op))
             {
                 Console.WriteLine("Invalid Input. Try agin");
             }
             switch(op)
             {
                 case 1:
                 UpdateFood();
                 break;
                 case 2:
                 AfterPrintAllReadyFood();
                 break;
                 default:
                 goto Update;
             }  
                 break;
             }
             var food = foods.Find(x => x.FoodId == id);
             if(food == null)
             {
                 Console.WriteLine("Food not available\nEnter any key back to main menu");
                Console.ReadKey();
             }
             Console.WriteLine("Enter Name");
             food.FoodTypeName = Console.ReadLine();
             Console.WriteLine("Enter Price");
             food.Price = decimal.Parse(Console.ReadLine());
             RefreshFile();
             Console.WriteLine("Food successfuly updated");
             UpdateFood:
             Console.WriteLine("Would you like to update another food.\n1. yes\n2. no");
             int option;
             while(!int.TryParse(Console.ReadLine(),out option))
             {
                 Console.WriteLine("Invalid Input. Try agin");
             }
             switch(option)
             {
                 case 1:
                 UpdateFood();
                 break;
                 case 2:
                 AfterPrintAllReadyFood();
                 break;
                 default:
                 goto UpdateFood;
             }
         }
          private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Food.txt");
            foreach (Food food in foods)
            {
                writer.WriteLine(food);
            }
            writer.Flush();
            writer.Close();
        }
        public Food GetFoodType(int id)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                if(foods[i] != null && foods[i].FoodId == id)
                return foods[i];
            }
            return null;
        }
        
    }
}