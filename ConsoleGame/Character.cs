using System;
namespace ConsoleGame
{
    public class Character
    {
        //properties
        public string Name { get; set; }
        public int Level { get; set; }
        public int Luck { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        //constructor
        public Character(string name)
        {
            Name = name;
            Level = 10;
            Luck = 5;
            MaxHealth = 100;
            CurrentHealth = 100;
        }

        //methods
        public int Attack(Character defender)
        {
            Random rnd =  new Random(Guid.NewGuid().GetHashCode());//instantiates new Random which has a new globally unique identifier
            double attackMultiplier = rnd.NextDouble() + 1; //gives a number between 1 and 0
            double damage = Level * attackMultiplier;

            int critChance = rnd.Next(101);//use 101 because Next is exclusice of the number passed in it
            if (Luck >= critChance)
            {
                damage *= 2;
                Console.WriteLine("Critical hit!");
            }

            int finalDam = (int)Math.Round(damage);//rounds double to a whole number
            defender.CurrentHealth -= finalDam;

            return finalDam;
        }
        //checks player's health
        public bool IsAlive()
        {
            if (CurrentHealth > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //resets player's health
        public void Rest()
        {
            CurrentHealth = MaxHealth;
        }
        //advances player's level
        public void Defeat(Character defender)
        {
            double dExp = defender.Level / 10;
            int experience = (int)Math.Round(dExp);

            Level += experience;
            Luck++;
        }
    }
}
