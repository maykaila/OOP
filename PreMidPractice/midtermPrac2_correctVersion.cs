using System;
using System.Collections.Generic;

// ----------------------------------------------------------------------
// ABSTRACTION & INHERITANCE (Base Class)
// ----------------------------------------------------------------------
abstract class Employee
{
    // Protected field (accessible by derived classes)
    protected int _employeeId;
    
    // Private field for strong encapsulation (MUST be accessed via the Salary property)
    private decimal _salary; 

    // Protected field for name
    protected string _fullName; 

    // PUBLIC ACCESSOR PROPERTIES (Getters for outside access)
    public int EmployeeId => _employeeId; 
    public string FullName => _fullName; 

    // ABSTRACTION: Abstract method forces implementation in subclasses
    public abstract decimal CalculateMonthlyPay();

    // Constructor: Initializes the fields, using the Salary property setter for validation
    public Employee(int employeeId, decimal salary, string fullName)
    {
        this._employeeId = employeeId;
        this._fullName = fullName;
        
        // **CRITICAL FIX**: Use the public property setter to trigger validation
        this.Salary = salary; 
    }

    // ENCAPSULATION: Public property with custom getter and validated setter
    public decimal Salary
    {
        get { return _salary; }
        set
        {
            // Setter Validation Requirement
            if (value > 0)
            {
                _salary = value;
            }
            else
            {
                _salary = 1000.00M; // M suffix ensures this is a decimal literal
                Console.WriteLine($"[WARNING] Salary set for {FullName} was invalid. Setting to default of 1000.00.");
            }
        }
    }
}

// ----------------------------------------------------------------------
// INHERITANCE & POLYMORPHISM (Subclass 1)
// ----------------------------------------------------------------------
class FullTimeEmployee : Employee
{
    // Public property for bonus percentage (Note: double is fine for percentage)
    public double BonusPercentage { get; set; }

    public FullTimeEmployee(int employeeId, decimal salary, string fullName, double bonusPercentage) 
        : base(employeeId, salary, fullName)
    {
        this.BonusPercentage = bonusPercentage;
    }

    // POLYMORPHISM: Concrete implementation of abstract method
    public override decimal CalculateMonthlyPay()
    {
        // Must cast BonusPercentage to decimal for correct calculation
        decimal bonusFactor = (decimal)BonusPercentage;
        
        // Calculation: (Salary / 12) + (Salary * BonusPercentage / 12)
        return (Salary / 12M) + (Salary * bonusFactor / 12M);
    }
}

// ----------------------------------------------------------------------
// INHERITANCE & POLYMORPHISM (Subclass 2)
// ----------------------------------------------------------------------
class Contractor : Employee
{
    // Public property for HourlyRate (Changed from field to property for style)
    public decimal HourlyRate { get; set; } 

    public Contractor(int employeeId, decimal salary, string fullName, decimal hourlyRate) 
        : base(employeeId, salary, fullName) // Passes salary to base, which may trigger validation
    {
        this.HourlyRate = hourlyRate;
    }

    // POLYMORPHISM: Concrete implementation of abstract method
    public override decimal CalculateMonthlyPay()
    {
        // Calculation: HourlyRate * 160
        return HourlyRate * 160M;
    }
}

// ----------------------------------------------------------------------
// TEST CODE (Program Class)
// ----------------------------------------------------------------------
public class Program
{
    public static void TestPayrollSystem()
    {
        Console.WriteLine("--- Creating Employees and Testing Setter ---");
        
        // 1. Test Valid Salary Assignment
        FullTimeEmployee ftEmployee = new FullTimeEmployee(
            employeeId: 101, 
            salary: 60000.00M, // M suffix is crucial for decimal
            fullName: "Alice Smith", 
            bonusPercentage: 0.10
        );
        Console.WriteLine($"1. Alice Salary Set (Valid): {ftEmployee.Salary:C}");

        // 2. Test Setter Validation (Set to invalid value)
        Console.Write("Attempting invalid salary set: ");
        ftEmployee.Salary = -5000.00M; // Triggers setter validation/warning
        Console.WriteLine($"2. Alice Salary After Invalid Set: {ftEmployee.Salary:C}");
        
        // 3. Test Contractor Creation
        Contractor contractor = new Contractor(
            employeeId: 202, 
            salary: 1.00M, // Placeholder salary passed to base (could be any positive value)
            fullName: "Bob Johnson", 
            hourlyRate: 50.00M
        );
        Console.WriteLine($"3. Bob Hourly Rate: {contractor.HourlyRate:C}");

        // 4. Demonstrate Polymorphism and Calculation
        Console.WriteLine("\n--- Demonstrating Pay Calculation (Polymorphism) ---");
        List<Employee> payroll = new List<Employee> { ftEmployee, contractor };

        foreach (var emp in payroll)
        {
            // **FIXED ENCAPSULATION**: Uses public properties (FullName, EmployeeId)
            Console.WriteLine($"{emp.FullName} (ID: {emp.EmployeeId}) Monthly Pay: {emp.CalculateMonthlyPay():C}");
        }
    }

    public static void Main(string[] args)
    {
        TestPayrollSystem();
    }
}