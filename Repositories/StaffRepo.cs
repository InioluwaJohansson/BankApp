using System;
using System.Collections.Generic;
using BankApp.Enums;
using BankApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Repositories;
public class StaffRepo{
    private static int count = 1;
    public static Staff[] staffs = new Staff[50];
    private static int myIndex = 0;
    public StaffRepo(){
    var staff = new Staff(1, "Inioluwa", "Makinde", "inioluwa@gmail.com", 18,  Gender.Male, DateTime.Parse("2003-08-13"), "abk", "08134045263", "Oyo", "inioluwa10", "Inioluwa", Role.Manager);
    staffs[0] = staff;
    }
    public void AddNewStaff(string firstName, string lastName, string email, int age, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string stateOfOrigin, string password, string nextOfKin, Role role){
        int id = ++count;
        Staff staff = new Staff(count, firstName, lastName, email, age, gender, dateOfBirth, address, phoneNumber, stateOfOrigin, password, nextOfKin, role);
        staffs[myIndex] = staff;
        Console.WriteLine("New Staff has been added successfully...");
        myIndex++;
        count++;
    }
    public Staff Login(string email, string password){
        var staff = GetStaff(email);
        if (staff != null && staff.Password == password)
        {
            return staff;
        }
        return null;
    }
    private Staff GetStaff(string email){
        for (int i = 0; i < staffs.Length; i++)
        {
            if ((staffs[i] != null) && (staffs[i].Email == email))
            {
               return staffs[i]; 
            }
        }
        return null;
    }
    public Staff PrintStaff(){
        for (int i = 0; i < staffs.Length; i++)
        {
            if(staffs[i] != null){           
            Console.WriteLine($"{staffs[i].FirstName} | {staffs[i].LastName} | {staffs[i].Email} | {staffs[i].Age} | {staffs[i].Gender} | {staffs[i].DateOfBirth} | {staffs[i].Address} | {staffs[i].PhoneNumber}"); 
            }   
        }
        return null;
    }

}