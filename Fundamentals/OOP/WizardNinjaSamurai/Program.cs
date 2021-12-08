using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human Nat = new Human("Nat");
            Console.WriteLine(Nat.Health);
            Wizard Fat = new Wizard("Fat");
            Console.WriteLine(Fat.Health);
            Fat.Attack(Nat);
            Fat.Heal(Nat);
            Ninja Matt = new Ninja("Matt");
            Matt.Steal(Nat);
            Samurai Pat = new Samurai("Pat");
            Console.WriteLine(Pat.Meditate());
            System.Console.WriteLine(Nat.Health);

        }
    }
}