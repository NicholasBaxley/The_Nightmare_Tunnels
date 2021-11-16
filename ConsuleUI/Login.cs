using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsuleUI
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

                Console.WriteLine("Are you a new player?(y/n)");
                input = Console.ReadLine().ToLower();

                // New User
                if (input == "y" || input == "yes")
                {
                    while (loop)
                    {

                        Console.WriteLine("\nWhat is your name?");
                        input = Console.ReadLine();
                        name = input;
                        Console.WriteLine($"Are you sure {input} is the name you want? (y/n)");
                        input = Console.ReadLine();

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
                        Console.WriteLine("\nEnter a password. (must contain upper case, lower case and a special character)");
                        password = Console.ReadLine();

                        if (Player.CheckPassword(password))
                        {
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }

                    // Gets new user player class
                    loop = true;
                    while (loop)
                    {
                                                                                                    // TODO - input validation
                        Console.WriteLine("\nWhat class do you want to be? (Warrior or mage)");
                        playerClass = Console.ReadLine();
                        if(playerClass.ToLower() == "warrior" || playerClass.ToLower() == "mage")
                        {
                            Console.WriteLine($"You picked {playerClass}.");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }

                    }

                    // Gets new user race
                    loop = true;
                    while (loop)
                    {
                        Console.WriteLine("\nWhat race do you want to be? (Human or dwarf)");
                        race = Console.ReadLine();
                        if(race.ToLower() == "human" || race.ToLower() == "dwarf")
                        {
                            Console.WriteLine($"You picked {race}.");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
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
                        Console.WriteLine("Enter your characters name.");
                        loginName = Console.ReadLine();
                        if (!SqliteDataAccess.CheckForPlayer(loginName))
                        {
                            Console.WriteLine("Not a user!");
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
                        Console.WriteLine("Enter your password");
                        pass = Console.ReadLine();
                        if (!SqliteDataAccess.CheckForPass(loginName, pass))
                        {
                            Console.WriteLine("Not the correct password!");
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
                    Console.WriteLine("\nInvalid option!");
                }
            }
        }
    }
}
