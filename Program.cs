using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.Enums;
using BankApp.Models;
using BankApp.Menus;
namespace BankApp;
public class Program{
    static void Main(string[] args){
        MainMenu mainMenu = new MainMenu();
        mainMenu.Menu();
    }
}
