using System;

namespace FoodOderingApp.Enums
{
    public class StaffRepo
    {
       private static int count = 2;
       public static Staff [] staffs = new Staff[50];
       private static int myIndex = 1;
       private TextWriter textWriter;
       public StaffRepo()
       {
           var staff = new Staff (1, "Zafrullah", "Idris","zaf@gmail.com","password","08012345678",Gender.Male,Role.Manager);
           staffs[0] = staff;
       }
       public void AddNewStaff(string fName, string lName, string email, string phone, string password,Gender gender,Role role)
       {
           
           Staff staff = new Staff(count,fName,lName,email,password,phone,gender,role);
           staffs[myIndex] = staff;
           TextWriter writer = new StreamWriter("Staff.txt",true);
           writer.WriteLine(staff.ToString());
           writer.Close();
           Console.WriteLine($"Staff successfully added and staff number is {staff.StaffNo}");
           count++;
           myIndex++;
       }
       public Staff Login(string email,string password)
       {
           var staff = GetStaff(email);
           if(staff != null && staff.Password == password)
           {
               return staff;
           }
           return null;
       }
       public Staff GetStaff(string email)
       {
           for (int i = 0; i < myIndex; i++)
           {
               if(staffs[i] != null && staffs[i].Email == email)
               {
                   return staffs[i];
               }
           }
           return null;
       }
    }
}