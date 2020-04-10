using System;
using System.Collections.Generic;
using NinjasInSpace.Models;
using NinjasInSpace.Interfaces;

namespace NinjasInSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            RayGun green = new RayGun("green ray gun", 2);
            RayGun red = new RayGun("red ray gun", 4);
            SpaceArmor titanium = new SpaceArmor("titanium space armor", 50);
            SpaceArmor alien = new SpaceArmor("alien tech space armor", 100);
            GravBoots nike = new GravBoots("Nike grav boots", 2);
            GravBoots adidas = new GravBoots("Adidas grav boots", 4);
            AlienText romulan = new AlienText("book of Romulan wisdom", 2);
            AlienText vulcan = new AlienText("book of Vulcan wisdom", 4);
            IEquipable[] treasure = new IEquipable[8] {green, red, titanium, alien, nike, adidas, romulan, vulcan};

            ConsoleYellow("********NINJAS IN SPACE********");

            Hero player = PlayerSetup();
            
            ConsoleYellow($"You, {player.Name}, have been chosen(randomly selected) to join a team of developer ninjas on a space quest!  To seek out new algorithms, new data structures, and go where no else wants to go! DEEP SPACE!!!\n\nHere you will encounter aliens, space monsters, and the unknown to bring back algorithms to benefit all humans. You now must choose your team.\n\nPress Enter to Start");

            ConsoleKey key  = Console.ReadKey(true).Key;
            while(key != ConsoleKey.Enter)
            {
                key  = Console.ReadKey(true).Key;
            }
            Console.WriteLine("Please select two crew members");

            Hero teammate1 = TeamSetup();
            Hero teammate2 = TeamSetup();

            List<Hero> party = new List<Hero>() {player, teammate1, teammate2};

            int planet = 0;

            while (planet < 5)
            {
                Console.WriteLine("");
                ConsoleYellow($"Welcome to Planet {planet+1}!");
                ConsoleYellow("=====================");
                List<Enemy> enemies = new List<Enemy>();
                
                Spider enemy1 = new Spider("Space Spider 1");
                Zombie enemy2 = new Zombie("Space Zombie 1");
                Xenomorph enemy3 = new Xenomorph("Xenomorph 1");
                enemies.Add(enemy1);
                enemies.Add(enemy2);
                enemies.Add(enemy3);

                Random die = new Random();
                int round = 0;
                while (SumHealthParty(party) > 0 && SumHealthEnemies(enemies) > 0)
                {
                    int turn = round % 6;
                    if (turn >= 0 && turn <3)
                    {
                        if (party[turn].Health > 0)
                        {
                            Console.WriteLine("");
                            EncounterStatus(party, enemies);
                            if (party[turn] is Ninja)
                            {
                                Ninja ninjaClone = (Ninja) party[turn];
                                Console.WriteLine($"{ninjaClone.Name}'s turn. (A)ttack or (B)ackstab?");
                                string Action = Console.ReadLine();
                                Console.WriteLine($"Target? (1){enemies[0].Name} (2){enemies[1].Name} (3){enemies[2].Name}");
                                string Target = Console.ReadLine();
                                if (Action == "A")
                                {
                                    ninjaClone.Attack(enemies[int.Parse(Target)-1]);
                                }
                                else if (Action == "B")
                                {
                                    ninjaClone.Backstab(enemies[int.Parse(Target)-1]);
                                }
                                else if (Action == "Z")
                                {
                                    enemies[int.Parse(Target)-1].Health = 0;
                                    Console.WriteLine("Let's get this over with");
                                    Console.WriteLine("");
                                }
                            }
                            else if (party[turn] is Samurai)
                            {
                                Samurai samuraiClone = (Samurai) party[turn];
                                Console.WriteLine($"{samuraiClone.Name}'s turn. (A)ttack or (M)editate?");
                                string Action = Console.ReadLine();
                                if (Action == "A")
                                {
                                    Console.WriteLine($"Target? (1){enemies[0].Name} (2){enemies[1].Name} (3){enemies[2].Name}");
                                    string Target = Console.ReadLine();
                                    samuraiClone.Attack(enemies[int.Parse(Target)-1]);
                                }
                                else if (Action == "M")
                                {
                                    samuraiClone.Meditate();
                                }
                                else if (Action == "Z")
                                {
                                    Console.WriteLine($"Target? (1){enemies[0].Name} (2){enemies[1].Name} (3){enemies[2].Name}");
                                    string Target = Console.ReadLine();
                                    enemies[int.Parse(Target)-1].Health = 0;
                                    Console.WriteLine("Let's get this over with");
                                    Console.WriteLine("");
                                }
                            }
                            else if (party[turn] is Wizard)
                            {
                                Wizard wizardClone = (Wizard) party[turn];
                                Console.WriteLine($"{wizardClone.Name}'s turn. (A)ttack or (S)hield?");
                                string Action = Console.ReadLine();
                                if (Action == "A")
                                {
                                    Console.WriteLine($"Target? (1){enemies[0].Name} (2){enemies[1].Name} (3){enemies[2].Name}");
                                    string Target = Console.ReadLine();
                                    wizardClone.Attack(enemies[int.Parse(Target)-1]);
                                }
                                else if (Action == "S")
                                {
                                    Console.WriteLine($"Target? (1){party[0].Name} (2){party[1].Name} (3){party[2].Name}");
                                    string Target = Console.ReadLine();
                                    wizardClone.Shield(party[int.Parse(Target)-1]);
                                }
                                else if (Action == "Z")
                                {
                                    Console.WriteLine($"Target? (1){enemies[0].Name} (2){enemies[1].Name} (3){enemies[2].Name}");
                                    string Target = Console.ReadLine();
                                    enemies[int.Parse(Target)-1].Health = 0;
                                    Console.WriteLine("Let's get this over with");
                                    Console.WriteLine("");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (enemies[turn-3].Health > 0)
                        {
                            Console.WriteLine("");
                            EncounterStatus(party, enemies);
                            if (enemies[turn-3] is Zombie)
                            {
                                Zombie zombieClone = (Zombie) enemies[turn-3];
                                Console.WriteLine($"{zombieClone.Name}'s turn.");
                                Random rand = new Random();
                                bool attacked = false;
                                while (!attacked)
                                {
                                    int target = rand.Next(3);
                                    if (party[target].Health > 0)
                                    {
                                        zombieClone.Attack(party[target]);
                                        attacked = true;
                                    }
                                }
                                Console.WriteLine("Please press \"Enter\" to continue");
                                string Action = Console.ReadLine();
                            }
                            else if (enemies[turn-3] is Spider)
                            {
                                Spider spiderClone = (Spider) enemies[turn-3];
                                Console.WriteLine($"{spiderClone.Name}'s turn.");
                                Random rand = new Random();
                                bool attacked = false;
                                while (!attacked)
                                {
                                    int target = rand.Next(3);
                                    if (party[target].Health > 0)
                                    {
                                        spiderClone.Attack(party[target]);
                                        attacked = true;
                                    }
                                }
                                Console.WriteLine("Please press \"Enter\" to continue");
                                string Action = Console.ReadLine();
                            }
                            else if (enemies[turn-3] is Xenomorph)
                            {
                                Xenomorph xenoClone = (Xenomorph) enemies[turn-3];
                                Console.WriteLine($"{xenoClone.Name}'s turn.");
                                Random rand = new Random();
                                bool attacked = false;
                                while (!attacked)
                                {
                                    int target = rand.Next(3);
                                    if (party[target].Health > 0)
                                    {
                                        xenoClone.Attack(party[target]);
                                        attacked = true;
                                    }
                                }
                                Console.WriteLine("Please press \"Enter\" to continue");
                                string Action = Console.ReadLine();
                            }
                        }
                    }
                    if (SumHealthEnemies(enemies) <= 0)
                    {
                        Console.WriteLine("All enemies vanquished! Congratulations!");
                        int d8 = die.Next(8);
                        IEquipable foundTreasure = treasure[d8];
                        Equipment equipClone = (Equipment) foundTreasure;
                        Console.WriteLine($"You found {equipClone.Name}! {equipClone.Desc} Who should equip it?");
                        string choice = "0";
                        while( choice != "1" && choice != "2" && choice != "3")
                        {
                            Console.WriteLine($"Please type the number of the hero you would like to equip:\n1. {party[0].Name}\n2. {party[1].Name}\n3. {party[2].Name}");
                            choice = Console.ReadLine();
                        }
                        switch (choice)
                        {
                            case("1"):
                                foundTreasure.Equip(party[0]);
                                Console.WriteLine($"{party[0].Name} has equipped the {equipClone.Name}");
                                party[0].ShowStats();
                                Console.WriteLine("");
                                break;
                            case("2"):
                                foundTreasure.Equip(party[1]);
                                Console.WriteLine($"{party[1].Name} has equipped the {equipClone.Name}");
                                party[1].ShowStats();
                                Console.WriteLine("");
                                break;
                            case("3"):
                                foundTreasure.Equip(party[2]);
                                Console.WriteLine($"{party[2].Name} has equipped the {equipClone.Name}");
                                party[2].ShowStats();
                                Console.WriteLine("");
                                break;
                        }
                        Console.WriteLine("Onward to the next planet! Good thing you brought clones of everyone!");
                        player.Health = player.MaxHealth;
                        teammate1.Health = teammate1.MaxHealth;
                        teammate2.Health = teammate2.MaxHealth;
                        Console.WriteLine("");
                        planet++;
                        if (planet == 5)
                        {
                            ConsoleYellow("You've certainly accomplished something! Saved the universe? Sure! Congratulations!");
                        }
                    }
                    if (SumHealthParty(party) <= 0)
                    {
                        ConsoleYellow("Your party was killed in self-defense! Game over!");
                        planet = 5;
                    }
                    round++;
                }
            }
        }

        static void ConsoleYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static Hero PlayerSetup()
        {
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();
            string choice = "0";

            while( choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Please type the number of the hero you would like to be:\n1. Ninja\n2. Wizard\n3. Samurai");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case("1"):
                    Ninja ninjaHero = new Ninja(name);
                    return ninjaHero;
                case("2"):
                    Wizard wizardHero = new Wizard(name);
                    return wizardHero;
                case("3"):
                    Samurai samuraiHero = new Samurai(name);
                    return samuraiHero;
            }
            return null;
        }
        static Hero TeamSetup()
        {
            Console.WriteLine("");
            Console.WriteLine("What is your crew member's name?");

            string name = Console.ReadLine();
            string choice = "0";

            while( choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Please type the number of the hero your new crew member is:\n1. Ninja\n2. Wizard\n3. Samurai");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case("1"):
                    Ninja ninjaHero = new Ninja(name);
                    return ninjaHero;
                case("2"):
                    Wizard wizardHero = new Wizard(name);
                    return wizardHero;
                case("3"):
                    Samurai samuraiHero = new Samurai(name);
                    return samuraiHero;
            }
            return null;
        }

        static int SumHealthParty(List<Hero> group)
        {
            int totalHealth = 0;
            foreach (Hero character in group)
            {
                totalHealth += character.Health;
            }
            return totalHealth;
        }

        static int SumHealthEnemies(List<Enemy> group)
        {
            int totalHealth = 0;
            foreach (Enemy character in group)
            {
                totalHealth += character.Health;
            }
            return totalHealth; 
        }

        static void EncounterStatus(List<Hero> party, List<Enemy> enemies)
        {
            Console.WriteLine("Party");
            Console.WriteLine("========");
            foreach (Hero character in party)
            {
                Console.WriteLine($"{character.Name}: {character.Health} HP");
            }
            Console.WriteLine("");
            Console.WriteLine("Enemies");
            Console.WriteLine("========");
            foreach (Enemy character in enemies)
            {
                Console.WriteLine($"{character.Name}: {character.Health} HP");
            }
            Console.WriteLine("");
        }
    }
}