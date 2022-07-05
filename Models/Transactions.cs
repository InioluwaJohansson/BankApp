using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Enums;
namespace BankApp.Models;
public class Transactions{
    public int Id {get; set;}
    public string TransactionId {get; set;}
    public DateTime Date {get; set;}
    public string Type {get; set;}
    public decimal Amount {get; set;}
    public decimal Balance {get; set;}
    public string Description {get; set;}
    public Transactions(int id, string transactionId, DateTime date, string type, decimal amount, string description)
    {
        Id = id;
        TransactionId = transactionId;
        Date = date;
        Type = type;
        Amount = amount;
        Balance = 0;
        Description = description;
    }

}