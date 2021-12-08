using System;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        //Wizard should have a default health of 50 and Intelligence of 25
        //human constructor = name, strength, intelligence, dexterity, health
        public Wizard(string name) : base (name, 3, 50, 3, 50)
        {
        }

        public override int Attack (Human target)
        {
            int dmg = Intelligence * 5;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Health += dmg;
            Console.WriteLine($"{Name} now has {Health} HP");
            return target.Health;
        }

        public int Heal (Human target)
        {
            int heal = Intelligence * 10;
            target.Health += heal;
            Console.WriteLine($"{Name} healed {target.Name} for {heal} HP!");
            return target.Health;
        }
    }
}