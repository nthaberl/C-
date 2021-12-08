using System;

namespace Human
{
    class Human
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human human = new Human("Nat");
            Console.WriteLine(human.HumanName);
            Console.WriteLine(human.HumanHealth);
            Human two = new Human("fat", 5, 5, 5, 5);
            Console.WriteLine(two.HumanName);
            two.Attack(human);
        }
        //Create a Human class with four public fields: 
        //Name (string) , Strength (int), Intelligence (int), Dexterity (int)
        public string HumanName;
        public int HumanStrength;
        public int HumanIntelligence;
        public int HumanDexterity;

        //Add an additional private field for health (int), 
        private int HumanHealth;

        //and a public property to access or "get" health
        public int HP
        {
            get {return HumanHealth;}
        }

    //Add a constructor method that takes a string to initialize Name - 
    //and that will initialize Strength, Intelligence, and Dexterity to a default value of 3, and health to default value of 100
        public Human(string name)
        {
            HumanName = name;
            HumanStrength = 3;
            HumanIntelligence = 3;
            HumanDexterity = 3;
            HumanHealth = 100;
        }

    //Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human (string name, int strength, int intelligence, int dexterity, int health)
        {
            HumanName = name;
            HumanStrength = strength;
            HumanIntelligence = intelligence;
            HumanDexterity = dexterity;
            HumanHealth = health;
        }

// Now add a new method called Attack, which when invoked, should reduce the health of a Human object that is passed as a parameter. 
// The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker). 
// This method should return the remaining health of the target object.
        public int Attack (Human attacked)
        {
            int damage = HumanStrength*5;
            attacked.HumanHealth -= damage;
            Console.WriteLine($"{attacked.HumanName} took {damage} damage and now has {attacked.HumanHealth} HP Left");
            return attacked.HumanHealth;
        }
    }
}
