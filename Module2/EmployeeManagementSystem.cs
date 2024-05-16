using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagement
{
    // Employee management system class
    public class EmployeeManagementSystem
    {
        private const string FilePath = "employees.txt";
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                if (employee is PermanentEmployee permanentEmployee)
                {
                    writer.WriteLine($"{employee.GetType().Name},{employee.Details.Name},{employee.Details.Age},{employee.Details.Department},{permanentEmployee.Salary}");
                }
                else if (employee is TemporaryEmployee temporaryEmployee)
                {
                    writer.WriteLine($"{employee.GetType().Name},{employee.Details.Name},{employee.Details.Age},{employee.Details.Department},{temporaryEmployee.HourlyRate},{temporaryEmployee.HoursWorked}");
                }
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
                            double salary = double.Parse(parts[4]);
                            PermanentEmployee emp = new PermanentEmployee
                            {
                                Details = new EmployeeDetails { Name = name, Age = age, Department = department },
                                Salary = salary
                            };
                            emp.DisplayDetails();
                        }
                        else if (type == nameof(TemporaryEmployee))
                        {
                            int hourlyRate = int.Parse(parts[4]);
                            int hoursWorked = int.Parse(parts[5]);
                            TemporaryEmployee emp = new TemporaryEmployee
                            {
                                Details = new EmployeeDetails { Name = name, Age = age, Department = department },
                                HourlyRate = hourlyRate,
                                HoursWorked = hoursWorked
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
}
