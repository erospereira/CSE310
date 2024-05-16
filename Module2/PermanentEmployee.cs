using System;

namespace EmployeeManagement
{
    // Derived class for permanent employees
    public class PermanentEmployee : Employee
    {
        public double Salary { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Name: {Details.Name}");
            Console.WriteLine($"Age: {Details.Age}");
            Console.WriteLine($"Department: {Details.Department}");
            Console.WriteLine($"Salary: ${Salary}");
        }
    }
}
