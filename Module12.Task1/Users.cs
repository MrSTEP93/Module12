using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12.Task1
{
    public class User
    {
        public string Login { get; }
        public string Name { get; private set; }
        public bool IsPremium { get; private set; }

        public User(string login, string name, bool isPremium)
        {
            Login = login;
            Name = name;
            IsPremium = isPremium;
        }
    
        public static User CheckUser(string _login, in List<User> userList)
        {
            bool success = false;
            foreach (var user in userList)
            {
                if (user.Login == _login)
                {
                    success = true;
                    return user;
                }
            }
            if (!success)
            {
                throw new Exception("Пользователь с таким логином не найден");
            }
            return null;
        }

        public static User CreateNew(string _login)
        {
            Console.WriteLine("Давайте создадим вашу учетную запись");
            Console.Write("Введите ваше имя: ");
            string _name = Console.ReadLine();
            User newUser = new User(_login, _name, false);
            Console.WriteLine("Учетная запись создана");
            return newUser;
        }
    }
}
