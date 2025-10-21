// 📜 Requirements
// Abstraction & Inheritance (Base Class):
// Create an abstract base class named DigitalAsset.
// It must have private attributes: _title (string) and _file_size_mb (float).
// It must have a protected attribute: _creator (string).
// It must have a constructor to initialize these three attributes.
// It must define an abstract method called get_asset_details().
// It must define a concrete method called display_creator_info() that returns a string: "Creator: [Creator Name]".
// Inheritance & Encapsulation (Subclasses):
// Create a subclass named ImageAsset that inherits from DigitalAsset.
// It must have a public attribute: resolution (string, e.g., "1920x1080").
// It must implement the get_asset_details() method to return a string with the format: "Image | Title: [Title] | Size: [Size] MB | Resolution: [Resolution]".
// Create a subclass named VideoAsset that also inherits from DigitalAsset.
// It must have a public attribute: duration_seconds (integer).
// It must implement the get_asset_details() method to return a string with the format: "Video | Title: [Title] | Size: [Size] MB | Duration: [Duration] sec".
// Polymorphism (Testing Code):
// The provided test code (which you will use to verify your classes) will rely on the ability to call get_asset_details() on any object derived from DigitalAsset without knowing its specific type.
using System;
using System.Collections.Generic;

abstract class DigitalAsset
{
    private string _name;
    private double _file_size_mb;
    protected string _creator;

    public DigitalAsset(string _name, double _file_size_mb, string _creator)
    {
        this._name = _name;
        this._file_size_mb = _file_size_mb;
        this._creator = _creator;
    }

    public abstract string get_asset_details();

    public string display_creator_info()
    {
        return $"Creator: {_creator}";
    }

    protected string Title => _name;
    protected double Size => _file_size_mb;
}

class ImageAsset : DigitalAsset
{
    public string resolution;

    public ImageAsset(string Title, double Size, string Creator, string resolution) : base(Title, Size, Creator)
    {
        this.resolution = resolution;
    }

    public override string get_asset_details()
    {
        return $"Image | Title: {Title} | Size: {Size} MB | Resolution: {resolution}";
    }
}

class VideoAsset : DigitalAsset
{
    public int duration_seconds;

    public VideoAsset(string Title, double Size, string Creator, int duration_seconds) : base(Title, Size, Creator)
    {
        this.duration_seconds = duration_seconds;
    }

    public override string get_asset_details()
    {
        return $"Video | Title: {Title} | Size: {Size} MB | Resolution: {duration_seconds}";
    }
}

// public class Program
// {
//     // Test Code: DO NOT MODIFY THIS BLOCK
//     public static void TestAssetManagement()
//     {
//         // 1. Create instances of the concrete classes
//         Console.WriteLine("--- Creating Assets ---");

//         DigitalAsset image = null;
//         DigitalAsset video = null;

//         try
//         {
//             // Note: Casing in the constructor call should match your class definitions
//             image = new ImageAsset(
//                 Title: "Sunset Over Mountain",
//                 Size: 4.5,
//                 Creator: "Alice",
//                 resolution: "3840x2160"
//             );
//             Console.WriteLine("ImageAsset created successfully.");
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine($"Error creating ImageAsset: {e.Message}");
//             return;
//         }

//         try
//         {
//             video = new VideoAsset(
//                 Title: "Company Annual Report",
//                 Size: 875.2,
//                 Creator: "Bob",
//                 duration_seconds: 185
//             );
//             Console.WriteLine("VideoAsset created successfully.");
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine($"Error creating VideoAsset: {e.Message}");
//             return;
//         }

//         // 2. Demonstrate Polymorphism
//         Console.WriteLine("\n--- Demonstrating Polymorphism ---");
//         // Treating both the ImageAsset and VideoAsset as their base type (DigitalAsset)
//         List<DigitalAsset> assets = new List<DigitalAsset> { image, video };

//         foreach (var asset in assets)
//         {
//             // Calls the appropriate get_asset_details() for ImageAsset or VideoAsset at runtime
//             Console.WriteLine(asset.get_asset_details());
//         }

//         // 3. Demonstrate Abstraction & Encapsulation
//         Console.WriteLine("\n--- Demonstrating Encapsulation & Protected Access ---");
//         // Calling a concrete method from the abstract base class
//         Console.WriteLine(image.display_creator_info());
//         Console.WriteLine(video.display_creator_info());
        
//         // C# compiler enforces encapsulation.
//         // The following line would cause a COMPILE ERROR, correctly demonstrating private encapsulation:
//         // Console.WriteLine(image._name); 
//         Console.WriteLine("(Attempted access to private fields like _name was blocked by the C# compiler.)");
//     }

//     public static void Main(string[] args)
//     {
//         TestAssetManagement();
//     }
// }