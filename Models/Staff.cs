using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Enums;
namespace BankApp.Models;
public class Staff:Person{
    public string StaffNo {get; set;}
    public Role Role {get; set;}
    public Staff(int id, string firstName, string lastName, string email, int age,
    Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string stateOfOrigin, string password, 
    string nextOfKin, Role role):base(id, firstName, lastName, email, age, gender, dateOfBirth, address, phoneNumber, stateOfOrigin, password, nextOfKin){
        StaffNo = $"SN{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
        Role = role;
    }
}