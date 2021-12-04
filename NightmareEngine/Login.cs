using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Objects;

namespace NightmareEngine
{
    public static class Login
    {
        public static void PlayerLogin()
        { 
            string name = "";
            string password = "";
            string playerClass = "";
            string race = "";
            bool login = false;
            string input;
            bool loop = true;

              while (!login)
             {

                World.message.WriteLine("Are you a new player?(y/n)");

                input = World.message.ReadLine().Result;
                
                // New User
                if (input == "y" || input == "yes")
                {
                    login = true;
                    while (loop)
                    {

                        World.message.WriteLine("\nWhat is your name?");
                        input = World.message.ReadLine().Result;
                        name = input;
                        World.message.WriteLine($"Are you sure {input} is the name you want? (y/n)");
                        input = World.message.ReadLine().Result;

                        if (input.ToLower() == "y" || input.ToLower() == "yes")
                        {
                            loop = false;
                        }
                        else if (input.ToLower() == "n" || input.ToLower() == "no")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    
                    // Gets new user password and checks if it meets requirements
                    loop = true;
                    while (loop)
                    {
                        World.message.WriteLine("\nEnter a password. (must contain upper case, lower case and a special character)");
                        password = World.message.ReadLine().Result;

                        if (Player.CheckPassword(password))
                        {
                            loop = false;
                        }
                        else
                        {
                            World.message.WriteLine("Invalid password!");
                        }
                    }

                    // Gets new user player class
                    loop = true;
                    while (loop)
                    {
                        World.message.WriteLine("\nWhat class do you want to be? (Warrior or mage)");
                        playerClass = World.message.ReadLine().Result;
                        if (playerClass.ToLower() == "warrior" || playerClass.ToLower() == "mage")
                        {
                            World.message.WriteLine($"You picked {playerClass}.");
                            loop = false;
                        }
                        else
                        {
                            World.message.WriteLine("Invalid choice.");
                        }

                    }

                    // Gets new user race
                    loop = true;
                    while (loop)
                    {
                        World.message.WriteLine("\nWhat race do you want to be? (Human or dwarf)");
                        race = World.message.ReadLine().Result;
                        if (race.ToLower() == "human" || race.ToLower() == "dwarf")
                        {
                            World.message.WriteLine($"You picked {race}.");
                            loop = false;
                        }
                        else
                        {
                            World.message.WriteLine("Invalid choice.");
                        }
                    }

                    // Saves new player
                    SqliteDataAccess.SaveNewPlayer(new Player(name, password, playerClass, race));
                    World.player = new Player(name, password, playerClass, race);
                    login = true;
                }

                // Returning User
                else if (input == "n" || input == "no")
                {
                    loop = true;
                    string loginName = "";
                    string pass = "";
                    while (loop)
                    {
                        World.message.WriteLine("Enter your characters name.");
                        loginName = World.message.ReadLine().Result;
                        if (!SqliteDataAccess.CheckForPlayer(loginName))
                        {
                            World.message.WriteLine("Not a user!");
                        }
                        else
                        {
                            loop = false;
                        }
                    }

                    // Checks for user password
                    loop = true;
                    while (loop)
                    {
                        World.message.WriteLine("Enter your password");
                        pass = World.message.ReadLine().Result;
                        if (!SqliteDataAccess.CheckForPass(loginName, pass))
                        {
                            World.message.WriteLine("Not the correct password!");
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                    SqliteDataAccess.LoadPlayer(loginName, pass);
                    login = true;
                }
                //TODO - for quick access to game, im tired of making a fake account each time i wanna test something.
                else if (input == "tester")
                {
                    SqliteDataAccess.LoadPlayer("Nicholas", "Password1!");
                    login = true;
                }
                else
                {
                    World.message.WriteLine("\nInvalid option!");
                }           
              }
            World.loggedIn = 1;
            if (World.player.equippedWeapon == null)
            {
                World.player.equippedWeapon = Weapon.RandomWeapon(World.weapons);
            }
        }
    }
}
