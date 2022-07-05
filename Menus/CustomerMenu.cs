using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.Enums;
using BankApp.Models;
namespace BankApp.Menus;
public class CustomerMenu{
    private static int count = 0;
    CustomerRepo customerRepo = new CustomerRepo();
    TransactionsRepo transactionsRepo = new TransactionsRepo();
    public void CustomMenu(){
        bool cont = false;
        while (!cont)
        {
            Console.WriteLine("Enter 1 To Login: ");
            Console.WriteLine("Enter 2 To Open An Account: ");
            Console.WriteLine("Enter 0 To Exit: ");
            {
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        LoginMenu();
                        break;
                    case 2:
                        RegistrationMenu();
                        break;
                    case 0:
                        cont = true;
                        break;
                    default:
                        HookScreen();
                        Console.ReadKey();
                        break;
                }
                    
            }
        }
    }
    public void TransactionsMenu(){
        Console.WriteLine("Enter 1 To Deposit: ");
        Console.WriteLine("Enter 2 To Withdraw: ");
        Console.WriteLine("Enter 3 To Transfer: ");
        Console.WriteLine("Enter 4 To Print Transactions: ");
        Console.WriteLine("Enter 5 For Self Service: ");
        Console.WriteLine("Enter 0 To Exit: ");
        bool cont = false;
        while (!cont)
        {
            int op = int.Parse(Console.ReadLine());
            switch (op){
                case 1:
                CreditMenu();
                break;
                case 2:
                DebitMenu();
                break;
                case 3:
                TransferMenu();
                break;
                case 4:
                transactionsRepo.TransactionList();
                TransactionsMenu();
                break;
                case 5:
                SelfService();
                break;
                case 0:
                cont = true;
                break;
                default:
                HookScreen();
                Console.ReadKey();
                break;        
            }
                    
        }
    }   
    public static string PassAcc;
    public static decimal PassBal;
    public static int PassAge;
    private void LoginMenu(){
        Console.WriteLine("Enter Account Number");
        string accountNumber = Console.ReadLine();
        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();
        var customer = customerRepo.Login(accountNumber, password);
        if (customer != null){
            PassAcc = $"{customer.AccountType}";
            PassBal = customer.Balance;
            PassAge = customer.Age;
            transactionsRepo.Hold(PassBal, PassAcc, PassAge);
            TransactionsMenu();           
        }else{
            Console.WriteLine($"Invalid Account Number or password \n Enter any key to continue");
            Console.ReadKey();
        }
    }
    private void CreditMenu(){
        Console.WriteLine("Enter Amount");
        decimal amount;
        while (decimal.TryParse(Console.ReadLine(), out amount) && amount  <= 0)
            {
                Console.WriteLine("Amount must be greater than #0");
            }
        Console.WriteLine("Enter Description");
        string description = Console.ReadLine();
        DateTime now = DateTime.Now;
        var date = now.Date;
        var id = count++;
        string type = "Credit";
        string transactionId = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(0,9).ToUpper()}";
        transactionsRepo.Credit(id, transactionId, date, type, amount, description);
        TransactionsMenu();
    }
    private void DebitMenu(){
        Console.WriteLine("Enter Amount");
        decimal amount;
        while (decimal.TryParse(Console.ReadLine(), out amount) && amount  <= 0)
            {
                Console.WriteLine("Amount must be greater than #0");
            }
        Console.WriteLine("Enter Description");
        string description = Console.ReadLine();
        DateTime now = DateTime.Now;
        var date = now.Date;
        var id = count++;
        string type = "Debit";
        string transactionId = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(0,9).ToUpper()}";
        transactionsRepo.Debit(id, transactionId, date, type, amount, description);
        TransactionsMenu();
    }
     private void TransferMenu(){
        Console.WriteLine("Enter Account Number");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Amount");
        decimal amount;
        while (decimal.TryParse(Console.ReadLine(), out amount) && amount  <= 0)
            {
                Console.WriteLine("Amount must be greater than #0");
            }
        Console.WriteLine("Enter description");
        string description = Console.ReadLine() + " " + accountNumber;
        DateTime now = DateTime.Now;
        var date = now.Date;
        var id = count++;
        string type = "Debit";
        string transactionId = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(0,9).ToUpper()}";
        transactionsRepo.Transfer(id, accountNumber, transactionId, date, type, amount, description);
        TransactionsMenu();
    }
    private void SelfService(){
        Console.WriteLine("Enter 1 To Lock Your Account: ");
        Console.WriteLine("Enter 0 To Exit: ");
        bool cont = false;
        while(!cont){
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                Console.WriteLine("Enter Account Number:");
                string accountNumber = Console.ReadLine();
                Console.WriteLine("Enter Your National Identification Number:");
                int nIN = int.Parse(Console.ReadLine());
                var customer = customerRepo.SelfService(nIN);
                if (customer != null){
                    Console.WriteLine("Enter New Password:");
                    string password = Console.ReadLine();
                    customer.Password = password;
                    Console.WriteLine("This Account has been locked successfully.");
                    CustomMenu();
                    cont = true;
                }else{
                    Console.WriteLine("Invalid Account Number or NIN");
                    cont = true;
                }              
                break;
                case 0:
                cont = true;
                break;
                default:
                HookScreen();
                break;
            }          
        }
    }
    private void RegistrationMenu(){
        Console.WriteLine("Enter Your First Name");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter Your Last Name");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter Your Email");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Your Age");
        int age = int.Parse(Console.ReadLine());
        int type;
        if(age < 18){
            Console.WriteLine("Select Account Type: 3 Student \t 4 SKS");
            int accountType;
            while (!int.TryParse(Console.ReadLine(), out accountType) && accountType > 5 || accountType < 2)
            {
                Console.WriteLine("Invalid Input Enter 3 or 4");
            }
            type = accountType;
        }else{
            Console.WriteLine("Select Account Type: 1 Current \t 2 Savings \t 3 Student \t 4 SKS");
            int accountType;
            while (!int.TryParse(Console.ReadLine(), out accountType) && accountType > 5 || accountType < 0)
            {
                Console.WriteLine("Invalid Input Enter 1, 2, 3 or 4");
            }
            type = accountType;
        }
        Random rd = new Random();
        string accountNumber = $"{rd.Next(10000000, 99999999)}";
        Console.WriteLine("Enter Your Gender: 1 Male \t2 Female \t3 Rather Not Say");
        int gender;
        while (!int.TryParse(Console.ReadLine(), out gender) && gender > 4 || gender < 0)
        {
            Console.WriteLine("Invalid Input Enter 1, 2 or 3");
        }        
        Console.WriteLine("Enter Your Date Of Birth in the order YYYY-MM-DD");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Your Home Address");
        string address = Console.ReadLine();
        Console.WriteLine("Enter Your Phone Number");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter Your State Of Origin");
        string stateOfOrigin = Console.ReadLine();
        Console.WriteLine("Enter Your Bank Verification Number");
        int bVN = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Your National Identification Number");
        int nIN = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();
        Console.WriteLine("Enter Your Next Of Kin");
        string nextOfKin = Console.ReadLine();                  
        customerRepo.RegisterAcc(firstName, lastName, email, age, (AccountType)type, accountNumber, (Gender)gender, dateOfBirth, address, phoneNumber, stateOfOrigin, bVN, nIN, password, nextOfKin);
        CustomMenu();
    }    
    public void HookScreen(){
        Console.WriteLine("Invalid Input. enter any key to write again: ");
        Console.ReadKey();
    }
}