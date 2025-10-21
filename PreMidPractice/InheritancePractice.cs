using System;
class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, int year)
    {
        this.Brand = brand;
        this.Year = year;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Car: {Brand} {Year}");
    }
}

class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string brand, int year, int numberOfDoors):base(brand, year)
    {
        this.NumberOfDoors = numberOfDoors;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Motorcycle: {Brand} {Year}, Doors: {NumberOfDoors}");
    }
}

class Motorcycle : Vehicle
{
    public bool HasSideCar { get; set; }

    public Motorcycle(string brand, int year, bool hasSideCar):base( brand, year)
    {
        this.HasSideCar = hasSideCar;
    }

    public override void DisplayInfo()
    {
        string sheUsedGPT = HasSideCar ? "Yes" : "No";
        Console.WriteLine($"Car: {Brand} {Year}, Side Car: {sheUsedGPT}");
    }
}

// class Program
// {
//     static void Main()
//     {
//         Car car = new Car("Toyota", 2004, 4);
//         car.DisplayInfo();

//         Motorcycle bike = new Motorcycle("Harley", 2021, true);
//         bike.DisplayInfo();
//     }
// }