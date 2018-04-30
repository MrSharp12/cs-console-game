using System;

namespace ConsoleGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.Clear();

            Character player = new Character(name);
            Console.WriteLine(player.Luck);

            bool stayMenuLoop = true;

            Console.WriteLine($"{name}, eh?  Tell me, {name}, are you experienced, tough, or lucky?");
            do
            {
                Console.WriteLine("1: Experienced \n" +
                                  "2: Tough \n" +
                                  "3: Lucky");
                string entry = Console.ReadLine();
                switch(entry)
                {
                    case "1":
                        player.Level += 5;
                        stayMenuLoop = false;
                        break;

                    case"2":
                        player.MaxHealth += 25;
                        player.CurrentHealth += 25;
                        stayMenuLoop = false;
                        break;

                    case "3":
                        player.Luck += 10;
                        stayMenuLoop = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("I didn't catch that, can you repeat yourself?");
                        break;
                }
            } while (stayMenuLoop);

            bool stayBattleLoop = true;

            Character giantRat = new Character("Giant Rat");

            Console.WriteLine("A giant rat appears!");
            Console.WriteLine("...Press Enter to Continue...");
            Console.ReadLine();

            do
            {
                stayMenuLoop = true;
                Console.Clear();

                do
                {
                    Console.WriteLine($"You have {player.CurrentHealth} HP remaining");
                    if (giantRat.CurrentHealth == giantRat.MaxHealth)
                        Console.WriteLine("The rat is uninjured.");
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >=3)
                        Console.WriteLine("The rat is on death's doorstep.");
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >= 2)
                        Console.WriteLine("The rat is bloodied and wheezing.");
                    else if (Math.Round((double)giantRat.MaxHealth / giantRat.CurrentHealth) >= 1)
                        Console.WriteLine("The rat has taken some wounds");

                    Console.WriteLine(giantRat.CurrentHealth);
                    Console.WriteLine(Math.Round((double)(giantRat.MaxHealth / giantRat.CurrentHealth)));

                    Console.WriteLine("\n What would you like to do? \n" +
                                        "1: Attack \n" +
                                        "2: Run Away \n");
                    string entry = Console.ReadLine();
                    switch (entry)
                    {
                        case "1":
                            Console.WriteLine();
                            Console.WriteLine($"You attack {giantRat.Name} for {player.Attack(giantRat)} damage!");
                            if (!giantRat.IsAlive())
                            {
                                player.Defeat(giantRat);
                                Console.WriteLine("You have defeated the giant rat!");
                                stayBattleLoop = false;
                            }
                            stayMenuLoop = false;
                            break;
                        case "2":
                            stayMenuLoop = false;
                            stayBattleLoop = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please choose to fight or run.");
                            break;
                    }
                } while (stayMenuLoop);

                if (stayBattleLoop)
                {
                    Console.WriteLine($"The rat attacks you for {giantRat.Attack(player)} damage!");
                    Console.WriteLine(". . . Press Enter to continue . . .");
                    Console.ReadLine();
                }

                if (!player.IsAlive())
                    stayBattleLoop = false;
                
            } while (stayBattleLoop);
        }
    }
}
