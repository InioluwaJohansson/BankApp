using System;
using System.Collections.Generic;
using BankApp.Enums;
using BankApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Repositories;
public class CustomerRepo{
    private static int count = 1;
    public static int myIndex = 0;
    public static Customer[] customers = new Customer[100];
    public CustomerRepo(){
        var customer = new Customer(1, "Inioluwa", "Makinde", "inioluwa@gmail.com", 18, AccountType.Savings, "12345678", Gender.RatherNotSay, DateTime.Parse("2003-08-13"), "abk", "08134045263", "Oyo", 1234567890, 1234567890, "inioluwa", "Inioluwa");
        customers[0] = customer;
    }
    public void RegisterAcc(string firstName, string lastName, string email, int age, AccountType accountType, string accountNumber, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string stateOfOrigin, int bVN, int nIN, string password, string nextOfKin){     
        var customee = new Customer(count, firstName, lastName, email, age, accountType, accountNumber, gender, dateOfBirth, address, phoneNumber, stateOfOrigin, bVN, nIN, password, nextOfKin);
        customers[myIndex] = customee;
        Console.WriteLine($"You have successfully created an account. Your Account Number is {customee.AccountNumber}");
        count++;
        myIndex++;            
    }
    public Customer Login(string accountNumber, string password){
        var customer = GetCustomer(accountNumber);
        if (customer != null && customer.Password == password)
        {
            return customer;
        }
        return null;
    }
    private Customer GetCustomer(string accountNumber){
        for (int i = 0; i < customers.Length; i++)
        {
            if ((customers[i] != null) && (customers[i].AccountNumber == accountNumber))
            {
                return customers[i]; 
            }
        }
        return null;
    }
    public Customer PrintCustomer(){
        for (int i = 0; i < customers.Length; i++)
        {
            if(customers[i] != null){    
                Console.WriteLine($"{customers[i].FirstName} | {customers[i].LastName} | {customers[i].Email} | {customers[i].Age} | {customers[i].Gender} | {customers[i].AccountType} | {customers[i].AccountNumber} | {customers[i].DateOfBirth} | {customers[i].Address} | {customers[i].PhoneNumber}"); 
            }
        }
        return null;
    }   
    public Customer SelfService(int nIN){
        var customer = GetAccount(nIN);
        if (customer != null)
        {
            return customer;            
        }
        return null;
    }
    public Customer StaffSelfService(int nIN){
        var customer = GetAccount(nIN);
        if (customer != null)
        {
            return customer;            
        }
        return null;
    }
    private Customer GetAccount(int nIN){
        for (int i = 0; i < customers.Length; i++)
        {
            if ((customers[i] != null) && (customers[i].NIN == nIN))
            {
                return customers[i]; 
            }
        }            
        return null;
    }
}