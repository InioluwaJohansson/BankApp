using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.Enums;
using BankApp.Models;
namespace BankApp.Menus;
public class MainMenu{  
    CustomerMenu customerMenu = new CustomerMenu();
    StaffMenu staffMenu = new StaffMenu();
    public void Menu(){
        bool exit = false;
        while (!exit)
        {
            PrintMenu();
            int op = int.Parse(Console.ReadLine());
            switch (op){
                case 1:
                    staffMenu.StaffsMenus();                    
                    break;
                case 2:
                    customerMenu.CustomMenu();
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    HookScreen();
                    break;
                }
            }
    }
    public void HookScreen(){
        Console.WriteLine($"Invalid input \n Enter any key to continue");
        Console.ReadKey();
    }
    private void PrintMenu(){
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("                 WELCOME TO THE BANK APP");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine("Enter 1 To Continue as a Staff");
        Console.WriteLine("Enter 2 To Continue as a Customer");
    }
}