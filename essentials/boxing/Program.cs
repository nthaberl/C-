using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Box some string data into a variable
            object BoxedData = "This is clearly a string";
            //Make sure it is the type you need before proceeding
            //safely unboxing uses the "is" keyword
            if (BoxedData is int) {
                //This shouldn't run
                Console.WriteLine("I guess we have an integer value in this box?");
            }
            if (BoxedData is string) {
                Console.WriteLine("It is totally a string in the box!");
            }

            //Safe explicit casting
            //if it fails, will throw a null instead of an exception
            //safe casts can only be used on nullable types (not int)
            object ActuallyString = "a string";
            string ExplicitString = ActuallyString as string;
            
            // THIS WON'T WORK!!
            // object ActuallyInt = 256;
            // int ExplicitInt = ActuallyInt as int;


            List <object> objects = new List<object>();
            objects.Add(7);
            objects.Add(28);
            objects.Add(-1);
            objects.Add(true);
            objects.Add("chair");

            int sum = 0;
            for (var i = 0; i < objects.Count; i++){
                System.Console.WriteLine(objects[i]);
                if (objects[i] is int){
                sum += (int)objects[i];
                }
            }
            System.Console.WriteLine(sum);

        }
    }
}
