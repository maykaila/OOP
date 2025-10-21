using System;

class Animal {
    public virtual void Speak()=>Console.WriteLine("This animal makes a sound.");
}

class Dog : Animal {
    public override void Speak()=>Console.WriteLine("The Dog Barks.");
}

class Cat : Animal {
    public override void Speak()=>Console.WriteLine("The Cat Meows.");
}

// class Program {
    
//     static void Main() {
//         Animal a0 = new Animal();
//         Animal a1 = new Dog();
//         Animal a2 = new Cat();
        
//         a0.Speak();
//         a1.Speak();
//         a2.Speak();
//     }
// }