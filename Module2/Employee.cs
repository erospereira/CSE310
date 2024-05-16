namespace EmployeeManagement
{
    // Base class
    public abstract class Employee
    {
        public EmployeeDetails Details { get; set; }

        public abstract void DisplayDetails();
    }
}
