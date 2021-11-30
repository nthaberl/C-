using System;

namespace objConst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        // Notice the type for the new object reference
        // is the same as the class name
        Vehicle myVehicle = new Vehicle();
        Console.WriteLine($"My vehicle is holding {myVehicle.NumPassengers} people");
        Vehicle myVehicle = new Vehicle(7);
        Console.WriteLine($"My vehicle is holding {myVehicle.NumPassengers} people");
        }

        
    }
    //Make sure to include the Vehicle class separate from the Program class
public class Vehicle
{
    //Accessibility of class members is defaulted to private
    //so we must add the public keyword to anything we
    //want to allow outside access to.
    
    // this unassigned integer will default to 0
    public int NumPassengers;
         //Notice the Constructor function doesn't need
     //a return type or the static keyword
    public Vehicle(int val)
    {
        NumPassengers = val;
    }
    //if we want an instance of our class to have an initial value, then don't pass in a parameter and set NumPassengers to whatever integer
    //ex
    // public Vehicle ()
    // {
    //     NumPassengers = 5;
    // }
    }
}
