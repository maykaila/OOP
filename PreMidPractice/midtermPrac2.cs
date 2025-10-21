using System;
using System.Collections.Generic;

// --- Your classes (Employee, FullTimeEmployee, Contractor) go here ---
// 📜 Requirements
// Abstraction & Inheritance (Base Class):
// Create an abstract base class named Employee.
// It must have a protected field: _employeeId (int).
// It must have a private field for the employee's salary: _salary (decimal).
// It must define a protected property for the employee's name: FullName (string).
// It must define an abstract method called CalculateMonthlyPay().
// It must have a constructor to initialize the ID and Full Name.
// Encapsulation (The Main Focus):
// Implement a public property named Salary (decimal) for the Employee class.
// The getter must simply return the private _salary field.
// The setter must include validation: it must ensure the value being set is greater than zero (0). If the value is not positive, it should set the salary to a default value of 1000.00 and print a warning message to the console.
// Inheritance & Polymorphism (Subclasses):
// Create a subclass named FullTimeEmployee that inherits from Employee.
// It must have a public property BonusPercentage (double).
// It must implement CalculateMonthlyPay() to return: (Salary / 12) + (Salary * BonusPercentage / 12).
// Create a subclass named Contractor that also inherits from Employee.
// It must have a public property HourlyRate (decimal).
// It must implement CalculateMonthlyPay() assuming a fixed 160 hours per month, returning: HourlyRate * 160.

abstract class Employee
{
    protected int _employeeId;
    private decimal _salary;
    protected string fullName;

    public abstract double CalculateMonthlyPay();

    public Employee(int _employeeId, double _salary, string fullName)
    {
        this._employeeId = _employeeId;
        this._salary = _salary;
        this.fullName = fullName;
    }

    public double Salary
    {
        get { return _salary; }
        set
        {
            if (value > 0)
            {
                _salary = value;
            }
            else
            {
                _salary = 1000.00;
                Console.WriteLine("Negative value.");
            }
        }
    }

    protected double EmployeeId => _employeeId;
    protected string FullName => fullName;
}

class FullTimeEmployee : Employee
{
    public double BonusPercentage;

    public FullTimeEmployee(int EmployeeId, double Salary, string FullName, double BonusPercentage) : base(EmployeeId, Salary, FullName)
    {
        this.BonusPercentage = BonusPercentage;
    }

    public override double CalculateMonthlyPay()
    {
        return (Salary / 12) + (Salary * BonusPercentage / 12);
    }
}

class Contractor : Employee
{
    public decimal HourlyRate;

    public Contractor(int EmployeeId, double Salary, string FullName, double HourlyRate) : base(EmployeeId, Salary, FullName)
    {
        this.HourlyRate = HourlyRate;
    }

    public override double CalculateMonthlyPay()
    {
        return HourlyRate * 160;
    }
}

public class Program
{
    public static void TestPayrollSystem()
    {
        Console.WriteLine("--- Creating Employees and Testing Setter ---");
        
        // 1. Test Valid Salary Assignment
        // Note: Using double for currency based on your class code
        FullTimeEmployee ftEmployee = new FullTimeEmployee(
            EmployeeId: 101, 
            Salary: 60000.00, // Initial salary
            FullName: "Alice Smith", 
            BonusPercentage: 0.10 // 10%
        );
        Console.WriteLine($"1. Alice Salary Set (Valid): {ftEmployee.Salary:N2}");

        // 2. Test Setter Validation (Set to invalid value)
        Console.Write("Attempting invalid salary set: ");
        ftEmployee.Salary = -5000.00; // This triggers your setter's 'else' block
        Console.WriteLine($"2. Alice Salary After Invalid Set: {ftEmployee.Salary:N2}");
        
        // 3. Test Contractor Creation
        Contractor contractor = new Contractor(
            EmployeeId: 202, 
            Salary: 0.00, // Salary is irrelevant for Contractor pay, but required by base constructor
            FullName: "Bob Johnson", 
            HourlyRate: 50.00
        );
        Console.WriteLine($"3. Bob Hourly Rate: {contractor.HourlyRate:N2}");

        // 4. Demonstrate Polymorphism and Calculation
        Console.WriteLine("\n--- Demonstrating Pay Calculation (Polymorphism) ---");
        List<Employee> payroll = new List<Employee> { ftEmployee, contractor };

        foreach (var emp in payroll)
        {
            // Calls the correct CalculateMonthlyPay() based on the object's true type
            Console.WriteLine($"{emp.FullName} (ID: {emp._employeeId}) Monthly Pay: {emp.CalculateMonthlyPay():N2}");
        }
    }

    public static void Main(string[] args)
    {
        TestPayrollSystem();
    }
}