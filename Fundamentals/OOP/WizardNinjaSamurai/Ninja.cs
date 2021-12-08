using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human{
        public Ninja (string name) : base (name, 3, 3, 175, 100)
        {
            
        }

        public override int Attack(Human target)
        {
            Random random = new Random();

            int damage = 5 * Dexterity;
            int critChance = 20;
            for (int i = 0; i < 100; i++)
            {
                int crit = random.Next(100);
                if(crit < critChance)
                {
                    damage += 10;
                }
            }
            target.Health -= damage;
            return target.Health;
        }

        public int Steal(Human target)
        {
            Console.WriteLine($"{Name}'s HP: {Health}, {target.Name}'s HP: {target.Health}");
            target.Health -= 5;
            this.Health += 5;
            Console.WriteLine($"{Name} stole 5 HP from {target.Name}. {Name}'s Health: {Health}, {target.Name}'s health: {target.Health}");
            return target.Health;
        }
    }
}