using System;

namespace EmployeeManagement
{
    // Derived class for temporary employees
    public class TemporaryEmployee : Employee
    {
        public int HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Name: {Details.Name}");
            Console.WriteLine($"Age: {Details.Age}");
            Console.WriteLine($"Department: {Details.Department}");
            Console.WriteLine($"Hourly Rate: ${HourlyRate}");
            Console.WriteLine($"Hours Worked: {HoursWorked}");
            Console.WriteLine($"Total Payment: ${HourlyRate * HoursWorked}");
        }
    }
}
