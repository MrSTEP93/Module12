using System;
using System.Collections.Generic;
using System.Threading;

namespace Module12.Task1
{
    internal class Program
    {
        static List<User> users;

        static void Main(string[] args)
        {
            CreateUsers();
            Console.WriteLine("Hello, GUEST!");
            Console.Write("Write your login: ");
            string currentlogin = Console.ReadLine();
            User currentUser = null;
            try
            {
                currentUser = User.CheckUser(currentlogin, in users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                currentUser =User.CreateNew(currentlogin);
                users.Add(currentUser);
            }

            Greetings(in currentUser);
        }
        
        static void CreateUsers()
        {
            users = new()
            {
                new User("mrstep", "Aleksey", true),
                new User("makendorf", "Lexa", false),
                new User("alison", "kote", true),
                new User("stalker", "Pyotr sergeevich", false)
            };
        }

        static void Greetings(in User user)
        {
            Console.WriteLine($"Привет, {user.Name}!!! Рады видеть вас снова");
            if (!user.IsPremium)
            {
                ShowAds();
            } else
            {
                Console.WriteLine("Спасибо, что пользуетесь премиальным сервисом!");
            }
        }

        static void ShowAds()
        {
            string[] advMessages = 
                { "Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com",
                "Купите подписку на МыКомбо и слушайте музыку везде и всегда!",
                "Спишите долги легально и навсегда -->",
                "Боль уйдет навсегда, стоит лишь применить один старый советский р..."
                };

            Random random = new Random();
            Console.WriteLine(advMessages[random.Next(0,4)]);
            // Остановка на 1 с
            Thread.Sleep(3000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}
