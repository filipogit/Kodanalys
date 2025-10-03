using System;

namespace Kodanalys
{
    class Program
    class Program
    {
        static UserManager userManager = new UserManager();

        static void AddUser()
        {
            Console.Write("Ange namn: ");
            string name = Console.ReadLine();

            if (userManager.AddUser(name))
                Console.WriteLine("Användaren har lagts till.");
            else
                Console.WriteLine("Listan är full!");
        }

        static void ShowUsers()
        {
            Console.WriteLine("Användare:");
            foreach (var user in userManager.GetUsers())
            {
                Console.WriteLine(user);
            }
        }

        static void RemoveUser()
        {
            Console.Write("Ange namn att ta bort: ");
            string name = Console.ReadLine();

            if (userManager.RemoveUser(name))
                Console.WriteLine("Användaren togs bort.");
            else
                Console.WriteLine("Användaren hittades inte.");
        }

        static void SearchUser()
        {
            Console.Write("Ange namn att söka: ");
            string name = Console.ReadLine();

            if (userManager.UserExists(name))
                Console.WriteLine("Användaren finns i listan.");
            else
                Console.WriteLine("Användaren hittades inte.");
        }
    }

