using System;
using System.Collections.Generic;

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
}

class Task
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}

class Project
{
    public string Title { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
}

class Admin : User
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Project> Projects { get; set; } = new List<Project>();
}

class Program
{
    static User loggedInUser = null;
    static Admin admin = new Admin();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Login();
                    break;
                case 3:
                    return;
            }
        }
    }

    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        User newUser = new User { Username = username, Password = password };
        admin.Users.Add(newUser);
        Console.WriteLine("Registration successful.");
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        foreach (var user in admin.Users)
        {
            if (user.Username == username && user.Password == password)
            {
                loggedInUser = user;
                Console.WriteLine("Login successful.");
                UserMenu();
                return;
            }
        }

        Console.WriteLine("Invalid username or password.");
    }

    static void UserMenu()
    {
        while (loggedInUser != null)
        {
            Console.WriteLine("1. See tasks\n2. Mark task as completed\n3. Logout");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayTasks();
                    break;
                case 2:
                    MarkTaskAsCompleted();
                    break;
                case 3:
                    loggedInUser = null;
                    return;
            }
        }
    }

    static void DisplayTasks()
    {
        Console.WriteLine("Your tasks:");
        foreach (var task in loggedInUser.Tasks)
        {
            Console.WriteLine($"{task.Title} - {(task.IsCompleted ? "Completed" : "Pending")}");
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Enter task title: ");
        string taskTitle = Console.ReadLine();

        foreach (var task in loggedInUser.Tasks)
        {
            if (task.Title == taskTitle)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
                return;
            }
        }

        Console.WriteLine("Task not found.");
    }
}
