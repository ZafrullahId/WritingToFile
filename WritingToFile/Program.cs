using System;
using MySql.Data.MySqlClient;
namespace FoodOderingApp.Enums
{
    public class program
    {
         string connect = "server = localhost;user = root;database = ConsoleApp;port = 3306;password = zafuolobeyo1@";
       MySqlConnection connection;
        public  static void Main(string[] args)
        {
            // new program().CreatTable();
            MainMenu.WelcomePage();       
        }
         public void CreatTable()
        {
           MySqlConnection connection = null;
           try
           {
               connection = new MySqlConnection(connect);
               MySqlCommand command = new MySqlCommand("Create table Customer (Id int not null auto_increment primary key, FirstName varchar(100),LastName varchar(50), Email varchar(100), Passwords varchar(100),Phone varchar(50),Address varchar(200),Wallet varchar(50),CustomerNo varchar(50))",connection);
               connection.Open();
               command.ExecuteNonQuery();
               Console.WriteLine("Table created successfully");
           }
           catch (Exception e)
           {
                Console.WriteLine("OOps, Something went wrong");
           }
           finally
           {
               connection.Close();
           }
        }
    }
}
