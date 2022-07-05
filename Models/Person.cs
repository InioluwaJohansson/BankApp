using System;
using System.Collections.Generic;
using BankApp.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models;
public abstract class Person{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}  
    public Gender Gender {get; set;}
    public DateTime DateOfBirth {get; set;}
    public int Age {get; set;}
    public string Address {get; set;}
    public string PhoneNumber {get; set;}
    public string StateOfOrigin {get; set;}   
    public string Password {get; set;}
    public string NextOfKin {get; set;}
    protected Person(int id, string firstName, string lastName, string email,int age, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string stateOfOrigin, string password, string nextOfKin)
    { 
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;        
        Gender = gender;
        DateOfBirth = dateOfBirth;    
        Address = address;
        PhoneNumber = phoneNumber;
        StateOfOrigin = stateOfOrigin;
        Password = password;
        NextOfKin = nextOfKin;
    }
    // public string Fullname(){
    //     return $"{FirstName} {LastName}";
    // }
}