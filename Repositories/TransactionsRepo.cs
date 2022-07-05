using System;
using System.Collections.Generic;
using BankApp.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;
namespace BankApp.Repositories;
public class TransactionsRepo{
    private static int count = 1;
    public static int myIndex = 0;
    private readonly Transactions transaction;
    public static decimal holdBalance;
    public static string holdAcc;
    public static int holdAge;
    public Transactions[] transactiones = new Transactions[100];
    public void Hold(decimal PassBal, string PassAcc, int PassAge){        
        holdBalance = PassBal;
        holdAcc = PassAcc;
        holdAge = PassAge;
    }
    public void Credit(int id, string transactionsId, DateTime date, string type, decimal amount, string description){   
        Console.WriteLine($"You are about to credit your bank account with #{amount}. \n Enter 1 to proceed or 0 to cancel.");
        int option = int.Parse(Console.ReadLine());      
        if(option == 1){    
        count = id++; 
        var transaction = new Transactions(count, transactionsId, date, type, amount, description);
        holdBalance += amount;
        transactiones[myIndex] = transaction;       
        Console.WriteLine($"You have successfully credited your Bank Account with #{amount}.");
        Console.WriteLine($"Your Transaction was successful. Your account balance is now #{holdBalance}."); 
        Console.WriteLine($"Account Balance: #{holdBalance}");      
        count++;
        myIndex++;
        }
    }    
    public void Debit(int id, string transactionId, DateTime date, string type, decimal amount, string description){
        count = id++;
        int charges = 0;
        string cur = $"{AccountType.Current}";
        string sav = $"{AccountType.Savings}";    
        if (holdAcc == cur)
        {
            charges = 5;
        }
        else if (holdAcc == sav)
        {
            charges = 3;
        }else{
            charges = 0;
        }       
        Console.WriteLine($"You are about to make a deduct of #{amount} from your bank account. \n Enter 1 to proceed or 0 to cancel.");
        int option = int.Parse(Console.ReadLine());      
        if(option == 1){
            if (holdAge < 18 && amount >= 100000)
            {
                Console.WriteLine($"Sorry you can't perform this transaction as the amount you inputed is more than the maximum amount you can debit in a day. \n Enter 0 to cancel.");    
            }else{
               if(holdBalance >= amount){
                    var transaction = new Transactions(count, transactionId, date, type, amount, description);
                    holdBalance -= amount + charges;              
                    transactiones[myIndex] = transaction;
                    count++;
                    myIndex++;
                    Console.WriteLine($"Your Transaction was successful. Your account balance is now #{holdBalance}. \n Enter 1 to proceed or 0 to cancel.");
                    Console.WriteLine($"Account Balance: #{holdBalance}");  
                }
                else{
                    bool alarm = false;
                    while(holdBalance < amount){
                        Console.Write("You do not have enough funds to complete this transaction.\n Please enter 1 to Credit your.Balance or any other number to exit.");
                        if (int.Parse(Console.ReadLine()) == 1)
                        {
                            FundAccount(transaction);
                        }else{
                            alarm = true;
                        }
                        if(alarm){
                            break;
                        }
                    }
                    if(!alarm){
                        var transaction = new Transactions(count, transactionId, date, type, amount, description);
                        holdBalance -= amount + charges;               
                        transactiones[myIndex] = transaction;
                        count++;
                        myIndex++;
                        Console.WriteLine($"Your Transaction was successful.\n Enter 1 to proceed or 0 to cancel.");
                        Console.WriteLine($"Account Balance: #{holdBalance}");  
                    }
                } 
            }            
        }
     }
    public void Transfer(int id, int accountNumber, string transactionId, DateTime date, string type, decimal amount, string description){
        count = id + 1;
        int charges = 0;        
        string cur = $"{AccountType.Current}";
        string sav = $"{AccountType.Savings}";     
        if (holdAcc == cur)
        {
            charges = 5;
        }
        else if (holdAcc == sav)
        {
            charges = 3;
        }else{
            charges = 0;
        } 
        Console.WriteLine($"You are about to make a Transfer of #{amount} to {accountNumber} for {description}. \n Enter 1 to proceed or 0 to cancel.");
        int option = int.Parse(Console.ReadLine());   
        if(option == 1){
            if (holdAge < 18 && amount >= 100000)
            {
                Console.WriteLine($"Sorry you can't perform this transaction as the amount you inputed is more than the maximum amount you can debit in a day. \n Enter 0 to cancel.");    
            }else{
               if(holdBalance >= amount){
                    var transaction = new Transactions(count, transactionId, date, type, amount, description);
                    holdBalance -= amount + charges;              
                    transactiones[myIndex] = transaction;
                    count++;
                    myIndex++;
                    Console.WriteLine($"Your Transaction was successful.\n Enter 1 to proceed or 0 to cancel.");
                    Console.WriteLine($"Account Balance: #{holdBalance}");  
                }
                else{
                    bool alarm = false;
                    while(holdBalance < amount){
                        Console.Write("You do not have enough funds to complete this transaction.\n Please enter 1 to Credit your.Balance or any other number to exit.");
                        if (int.Parse(Console.ReadLine()) == 1)
                        {
                            FundAccount(transaction);
                        }else{
                            alarm = true;
                        }
                        if(alarm){
                            break;
                        }
                    }
                    if(!alarm){
                        var transaction = new Transactions(count, transactionId, date, type, amount, description);
                        holdBalance -= amount + charges;               
                        transactiones[myIndex] = transaction;
                        count++;
                        myIndex++;
                        Console.WriteLine($"Your Transaction was successful.\n Enter 1 to proceed or 0 to cancel.");
                        Console.WriteLine($"Account Balance: #{holdBalance}");  
                    }
                } 
            }            
        }
    }
    public void FundAccount(Transactions transactions){
        Console.Write("Enter Amount to credit your wallet: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        string description = "Fund Wallet";
        DateTime now = DateTime.Now;
        var date = now.Date;
        var id = count++;
        string type = "Credit";
        string transactionId = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(0,9).ToUpper()}";
        var transaction = new Transactions(count, transactionId, date, type, amount, description);
        holdBalance += amount;
    }
    public void TransactionList(){
        if (transactiones[0] != null)
        {
            Console.WriteLine("Transaction Id | Date | Amount | Description");
            for (int i = 0; i < transactiones.Length; i++)
            {
                if(transactiones[i] != null)
                {    
                    Console.WriteLine($"{transactiones[i].TransactionId} | {transactiones[i].Date} | {transactiones[i].Type} | {transactiones[i].Amount} | {transactiones[i].Description}");
                }
            }  
        }else{
            Console.WriteLine("No Transactions records.");
        }        
    }
}