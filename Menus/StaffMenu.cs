using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.Enums;
using BankApp.Models;
namespace BankApp.Menus;
public class StaffMenu{
    StaffRepo staffRepo = new StaffRepo();
    CustomerRepo customerRepo = new CustomerRepo();
    
    public void StaffsMenus(){
        bool exit = false;
        while(!exit){
            PrintMenu();
            int op = int.Parse(Console.ReadLine());
            switch (op){
                case 1:
                StaffLogin();
                break;
                case 0:
                exit = true;
                break;
                default:
                HookScreen();
                Console.ReadKey();
                break;
            }
        }
    }
    private void PrintMenu(){
        Console.WriteLine("Enter 1 To Login");
        Console.WriteLine("Enter 0 To Exit");
    }
    public void ManagerMenu(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Enter 1 To Add New Staff");
            Console.WriteLine("Enter 2 Check Staff List");
            Console.WriteLine("Enter 3 Check Customer List");
            Console.WriteLine("Enter 4 Lock Customer's Account");
            Console.WriteLine("Enter 0 To Exit");
            int op = int.Parse(Console.ReadLine());
            switch (op){
                case 1:
                AddStaff();
                break;
                case 2:
                staffRepo.PrintStaff();
                break;
                case 3:
                customerRepo.PrintCustomer();
                break;
                case 4:
                Console.WriteLine("Enter Customer Account Number:");
                string accountNumber = Console.ReadLine();
                Console.WriteLine("Enter Customer National Identification Number:");
                int nIN = int.Parse(Console.ReadLine());
                if ((accountNumber != null) && (nIN != null))
                {
                    customerRepo.SelfService(nIN);
                }
                break;
                case 0:
                exit = true;                        
                break;
                default:
                HookScreen();
                Console.ReadKey();
                break;
            }
        }
    }
    public void StaffsMenu(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Enter 1 Check Customers List");
            Console.WriteLine("Enter 2 Lock Customer's Account");
            Console.WriteLine("Enter 0 To Exit");
            int op = int.Parse(Console.ReadLine());
            switch (op){
                case 1:
                customerRepo.PrintCustomer();
                break;
                case 2:
                Console.WriteLine("Enter Customer Account Number:");
                string accountNumber = Console.ReadLine();
                Console.WriteLine("Enter Customer National Identification Number:");
                int nIN = int.Parse(Console.ReadLine());
                var customer = customerRepo.StaffSelfService(nIN);
                if (customer != null){
                    Console.WriteLine("This Account has been locked successfully.");
                    exit = true;
                }else{
                    Console.WriteLine("Invalid Account Number or NIN");
                    exit = true;
                } 
                break;
                case 0:
                exit = true;
                break;
                default:
                HookScreen();
                Console.ReadKey();
                break;
            }
        }
    }
    public void StaffLogin(){
        Console.WriteLine("Enter Your Email");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine();
        var staff = staffRepo.Login(email, password);
        if (staff != null && staff.Role == Role.Manager){
            ManagerMenu();
        }
        else if (staff != null && staff.Role == Role.Accountant){
            StaffsMenu();
        }
        else{
            Console.WriteLine($"Invalid Email or password \n Enter any key to continue");
            Console.ReadKey();
        }
    }
    public void AddStaff(){
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender: 1 Male \t2 Female \t3 Rather Not Say");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender) && gender > 3 || gender < 1)
            {
                Console.WriteLine("Invalid Input Enter 1, 2 or 3");
            }
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Date Of Birth in the order YYYY-MM-DD");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Home Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter State Of Origin");
            string stateOfOrigin = Console.ReadLine();
            Console.WriteLine("Enter Next Of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Role: 1 Manager \t2 Accountant");
            int role;
            while (!int.TryParse(Console.ReadLine(), out role) && role > 3 || role < 1)
            {
                Console.WriteLine("Invalid Input Enter 1 or 2");
            }
            staffRepo.AddNewStaff(firstName, lastName, email, age, (Gender)gender, dateOfBirth, address, phoneNumber, stateOfOrigin, password, nextOfKin, (Role)role);
            ManagerMenu();
        }
    public void HookScreen(){
        Console.WriteLine("Invalid Input. enter any key to write again: ");
        Console.ReadKey();
    }   
}