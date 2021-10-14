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
            Player player = World.player;
            bool login = false;
            bool passFlag = false;
            string input;
            bool nameFlag = false;
            bool classFlag = false;
            bool raceFlag = false;

            while (!login)
            {

                Console.WriteLine("Are you a new player?(y/n)");
                input = Console.ReadLine().ToLower();

                // New User
                if (input == "y" || input == "yes")
                {
                    //login = true;
                    while (!nameFlag) 
                    { 
                    
                        Console.WriteLine("\nWhat is your name?");
                        input = Console.ReadLine();
                        player.name = input;
                        Console.WriteLine($"Are you sure {input} is the name you want? (y/n)");
                        input = Console.ReadLine();

                        if(input.ToLower() == "y" || input.ToLower() == "yes")
                        {
                            nameFlag = true;
                        }
                        else if(input.ToLower() == "n" || input.ToLower() == "no")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    while (!passFlag)
                    {
                        Console.WriteLine("\nEnter a password. (must contain upper case, lower case and a special character)");
                        string pass = Console.ReadLine();

                        if (Player.CheckPassword(pass))
                        {
                            player.password = pass;
                            passFlag = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }

                    // TODO - input validation
                    Console.WriteLine("\nWhat class do you want to be? (Warrior or mage)");
                    player.playerClass = Console.ReadLine();

                    Console.WriteLine("\nWhat race do you want to be? (Human or dwarf)");
                    player.race = Console.ReadLine();

                    // Saves new player
                    SqliteDataAccess.SaveNewPlayer(player);
                    login = true;
                }
                // Returning User
                else if (input == "n" || input == "no")
                {
                    bool loop = true; 
                    string loginName = "";
                    string pass = "";
                    while(loop)
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

                    loop = true;
                    while(loop)
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
