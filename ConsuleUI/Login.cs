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
        public static void PlayerLogin(Player player)
        {
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
                    Console.WriteLine(Write.SaveNewPlayer(player));
                }
                else if (input == "n" || input == "no")
                {
                    Console.WriteLine("Enter your characters name");
                    string loginName = Console.ReadLine();
                    Console.WriteLine("Enter your password");
                    string pass = Console.ReadLine();

                    Console.WriteLine(Read.LoadPlayer(loginName, pass, new Player()));

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
