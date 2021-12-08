using System;

namespace objConst
{
    class Program
    {
        static void Main(string[] args)
        {
        // Notice the type for the new object reference
        // is the same as the class name
        Vehicle myVehicle = new Vehicle(7);
        Console.WriteLine($"My vehicle is holding {myVehicle.MaxNumPassengers} people");
        

        //Understanding Access Modifiers
        Vehicle v = new Vehicle(5, "Green");
        Console.WriteLine(v.Color);
        Console.WriteLine(v.MaxNumPassengers);
        }

        
    }
    //Make sure to include the Vehicle class separate from the Program class
public class Vehicle
{


//Encapsulation
//     private int maxNumPassengers;
//     private string color;
//     public int MaxNumPassengers
//     {
//         get { return maxNumPassengers; }
//     }
//     public string Color
//     {
//         get { return color; }
//     }
//     public Vehicle(int maxPass, string col)
//     {
//         maxNumPassengers = maxPass;
//         color = col;
//     }
// }

    //Accessibility of class members is defaulted to private
    //so we must add the public keyword to anything we
    //want to allow outside access to.
    
    // this unassigned integer will default to 0
    public int MaxNumPassengers;
    public string Color;
    public double MaxSpeed;
    //Notice the Constructor function doesn't need
    //a return type or the static keyword
    public Vehicle(int val)
    {
        MaxNumPassengers = val;
    }
    //if we want an instance of our class to have an initial value, then don't pass in a parameter and set NumPassengers to whatever integer
    //ex
    // public Vehicle ()
    // {
    //     NumPassengers = 5;
    // }

    // vehicleObject.MakeNoise("HOOONK!") will invoke this one
    public void MakeNoise(string noise)
    {
    Console.WriteLine(noise);
    }
// vehicleObject.MakeNoise() will invoke this one
    public void MakeNoise()
    {
    Console.WriteLine("BEEP!");
    }

    public string ColorProp
    {
        get
        {
    	    // Simply referencing the property will invoke the "getter", such as:
    	    // Console.WriteLine(vehicleObject.ColorProp);
    	    // and will return the following:
    
            return $"This thing is {Color}";
        }
        set
        {
    	    // Assigning a value to a property, such as:
    	    // vehicleObject.ColorProp = "Blue";
    	    // will invoke the "setter", and the "value" keyword will become the assigned value
    	    // ("Blue" in this example)
    
            Color = value;
        }
    }
}
