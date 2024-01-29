using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegistrationApp
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserManager
    {
        private List<User> users = new List<User>();
        private string filePath;

        public UserManager(string filePath)
        {
            this.filePath = filePath;
            LoadUsers();
        }

        public void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                users = File.ReadAllLines(filePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Split(','))
                    .Select(data => new User { Id = int.Parse(data[0]), Username = data[1], Password = data[2] })
                    .ToList();
            }
        }

        public void SaveUsers()
        {
            var lines = users.Select(user => $"{user.Id},{user.Username},{user.Password}");
            File.WriteAllLines(filePath, lines);
        }

        public bool IsUsernameTaken(string username)
        {
            return users.Any(user => user.Username == username);
        }

        public void RegisterUser(string username, string password)
        {
            if (!IsUsernameTaken(username))
            {
                var newUser = new User
                {
                    Id = users.Count + 1,
                    Username = username,
                    Password = password
                };

                users.Add(newUser);
                SaveUsers();
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("The provided username already exists. Registration failed.");
            }
        }

        public User Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }
    }

    internal class Program
    {
        static UserManager userManager;

        static void Main(string[] args)
        {
            userManager = new UserManager("D:\\Programming\\ProgrammingBasics\\ProjectsC#\\projectOOP\\data.txt");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;

                    case "2":
                        Login();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.WriteLine("Registering a new user:");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            userManager.RegisterUser(username, password);
        }

        static void Login()
        {
            Console.WriteLine("Logging in:");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var loggedInUser = userManager.Login(username, password);

            if (loggedInUser != null)
            {
                Console.WriteLine($"Welcome, {loggedInUser.Username}!");
            }
            else
            {
                Console.WriteLine("Login failed. Username or password is incorrect.");
            }
        }
    }
}

