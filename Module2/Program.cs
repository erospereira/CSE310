using System;

namespace EmployeeManagement
{
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
                                Details = new EmployeeDetails { Name = name, Age = age, Department = department },
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
                                Details = new EmployeeDetails { Name = name, Age = age, Department = department },
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
}
