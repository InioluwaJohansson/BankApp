using System;
using System.Collections.Generic;
using BankApp.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models;
public class Customer:Person{
    public AccountType AccountType {get; set;}
    public string AccountNumber {get; set;}
    public int BVN {get; set;}
    public int NIN {get; set;}
    public decimal Balance {get; set;}      
    public Customer(int id, string firstName, string lastName, string email, int age, AccountType accountType, string accountNumber, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, 
    string stateOfOrigin, int bVN, int nIN, string password, string nextOfKin):base(id, firstName, lastName, email, age, gender, dateOfBirth, address, phoneNumber, stateOfOrigin, password, nextOfKin){
        AccountType = accountType;
        AccountNumber = accountNumber;
        BVN = bVN;
        NIN = nIN;
        Balance = 0;
    }
        
}