using System;

namespace Kodanalys
{

    class Program
    {
        static UserManager userManager = new UserManager();

        static void Main(string[] args)
        {
            userManager.LoadFromFile();

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        ShowUsers();
                        break;
                    case "3":
                        RemoveUser();
                        break;
                    case "4":
                        SearchUser();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }

                Console.WriteLine();
            }

            userManager.SaveToFile();
        }

        static void ShowMenu()
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Lägg till användare");
            Console.WriteLine("2. Visa alla användare");
            Console.WriteLine("3. Ta bort användare");
            Console.WriteLine("4. Sök användare");
            Console.WriteLine("5. Avsluta");
        }

        static void AddUser()
        {
            string name = PromptForValidName("Ange namn: ");
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
            string name = PromptForValidName("Ange namn att ta bort: ");
            if (userManager.RemoveUser(name))
                Console.WriteLine("Användaren togs bort.");
            else
                Console.WriteLine("Användaren hittades inte.");
        }

        static void SearchUser()
        {
            string name = PromptForValidName("Ange namn att söka: ");
            if (userManager.UserExists(name))
                Console.WriteLine("Användaren finns i listan.");
            else
                Console.WriteLine("Användaren hittades inte.");
        }

        static string PromptForValidName(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
