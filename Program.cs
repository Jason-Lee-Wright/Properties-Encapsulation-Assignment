﻿namespace Properties___Encapsulation_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of each class
            GameCharacter hero = new GameCharacter("Mario");
            Inventory backpack = new Inventory(); // capacity of 20
            PowerUp speedBoost = new PowerUp("Speed", 10.0f);

            // Test for GameCharacter
            hero.Health = 100;  // Should work
            hero.Health = -50;  // Should be prevented
            hero.Health = 550;  // Should be prevented
            Console.WriteLine(hero.Name + " living? : " + hero.IsAlive);  // Should be true
            hero.Health = 0; //should work
            Console.WriteLine(hero.Name + " living? : " + hero.IsAlive); //should be false

            //Test for Inventory
            backpack.Gold = 1000; // should work
            backpack.Gold = -10; // should not work
            Console.WriteLine(hero.Name + " has " + backpack.Gold + " gold"); // should be 1000
            backpack.ItemCount = 10; // should work (with default 20 capasity)
            backpack.ItemCount = backpack.Capacity + 10; // should not work 
            Console.WriteLine(hero.Name + " has " + backpack.ItemCount + " items"); // should be 10 
            Console.WriteLine("Is bag full? : " + backpack.IsFull + " " + backpack.ItemCount + $"/{backpack.Capacity} items"); // should be false
            backpack.ItemCount = backpack.Capacity;
            Console.WriteLine("Is bag full? : " + backpack.IsFull + " " + backpack.ItemCount + $"/{backpack.Capacity} items"); // should be true

            // test for Powerup
            Console.WriteLine(hero.Name + " was given " + speedBoost.Power + " for " + speedBoost.Duration);
            Console.WriteLine(speedBoost.Power + " active : " + speedBoost.IsActive);
        }
    }

    public class GameCharacter
    {
        // 1. Auto-implemented property
        public string Name { get; private set; }

        // accepts a name and defaults to "Player 1" if no name is provided
        public GameCharacter(string name = "Player 1")
        {
            Name = name;
        }

        // 2. Full property with validation
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                // Check if the current health is within the correct range.
                if (value < 0)
                {
                    return; // prevents negative values from being implimented
                }
                else if (value > 100)
                {
                    return; // prevents values over maximum.
                }
                else
                {
                    health = value; // set health to the valid value
                }
            }
        }

        // 3. Computed property
        public bool IsAlive
        {
            get
            {
                //If health is greater than 0 alive = true
                if (health > 0)
                {
                    return true;
                }
                // ealse you are dead
                else return false;
            }
        }
    }

    public class Inventory
    {
        // the max amount of items set with an Auto-implemention
        public int Capacity { get; private set; }

        //A constructor to set an automatic limit of 20, but accept other values
        public Inventory(int capacity = 20)
        {
            Capacity = capacity;
        }

        // value with valadation
        private int gold;

        // the constructor for the gold
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    gold = value;
                }
            }
        }

        // the amount of items the characer is holding
        private int itemCount;

        // the Constructor for the item count
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                if ((value < 0) || (value > Capacity))
                {
                    return;
                }
                else
                {
                    itemCount = value;
                }
            }
        }

        public bool IsFull
        {
            get
            {
                if (ItemCount == Capacity)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }

    public class PowerUp
    {
        //these are the main holders for the name of the boost, and the durration
        private string power;
        private float duration;

        //these are here so i can reference them in the WriteLine's
        public string Power { get { return power; } }
        public float Duration { get { return duration; } }

        //this is what is geting the name and durration from outside the class
        public PowerUp(string Power = "Boost", float Duration = 5.0f)
        {
            power = Power;

            duration = Duration;

            if (duration < 0)
            {
                duration = 0;
            }
        }

        public bool IsActive
        {
            get
            {
                return duration > 0;
            }
        }
    }
}
