using System;
using System.IO;

// Base class
public abstract class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }

    public abstract void DisplayDetails();
}

// Derived class
public class PermanentEmployee : Employee
{
    public double Salary { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: ${Salary}");
    }
}

// Derived class
public class TemporaryEmployee : Employee
{
    public int HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Hourly Rate: ${HourlyRate}");
        Console.WriteLine($"Hours Worked: {HoursWorked}");
    }
}

public class EmployeeManagementSystem
{
    private const string FilePath = "employees.txt";

    public void AddEmployee(Employee employee)
    {
        using (StreamWriter writer = new StreamWriter(FilePath, true))
        {
            writer.WriteLine($"{employee.GetType().Name},{employee.Name},{employee.Age},{employee.Department}");
        }
        Console.WriteLine("Employee added successfully.");
    }

    public void DisplayEmployees()
    {
        if (File.Exists(FilePath))
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string department = parts[3];

                    if (type == nameof(PermanentEmployee))
                    {
                        PermanentEmployee emp = new PermanentEmployee
                        {
                            Name = name,
                            Age = age,
                            Department = department
                        };
                        emp.DisplayDetails();
                    }
                    else if (type == nameof(TemporaryEmployee))
                    {
                        TemporaryEmployee emp = new TemporaryEmployee
                        {
                            Name = name,
                            Age = age,
                            Department = department
                        };
                        emp.DisplayDetails();
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagementSystem ems = new EmployeeManagementSystem();

        Console.WriteLine("Employee Management System");
        Console.WriteLine("==========================");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display Employees");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter employee type (P for permanent, T for temporary): ");
                    string type = Console.ReadLine().ToUpper();
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter department: ");
                    string department = Console.ReadLine();

                    if (type == "P")
                    {
                        Console.Write("Enter salary: $");
                        double salary = double.Parse(Console.ReadLine());
                        ems.AddEmployee(new PermanentEmployee
                        {
                            Name = name,
                            Age = age,
                            Department = department,
                            Salary = salary
                        });
                    }
                    else if (type == "T")
                    {
                        Console.Write("Enter hourly rate: $");
                        int hourlyRate = int.Parse(Console.ReadLine());
                        Console.Write("Enter hours worked: ");
                        int hoursWorked = int.Parse(Console.ReadLine());
                        ems.AddEmployee(new TemporaryEmployee
                        {
                            Name = name,
                            Age = age,
                            Department = department,
                            HourlyRate = hourlyRate,
                            HoursWorked = hoursWorked
                        });
                    }
                    else
                    {
                        Console.WriteLine("Invalid employee type.");
                    }
                    break;

                case "2":
                    ems.DisplayEmployees();
                    break;

                case "3":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
