using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    public class UserRepository
    {
        private readonly AppDbContext context2;

        public UserRepository()
        {
            context2 = new AppDbContext();
        }

        public User AddUser(string username, string password)
        {
            var user = new User { Username = username, Password = password };
            context2.Users.Add(user);
            context2.SaveChanges();

            Console.WriteLine($"Пользователь \"{username}\" добавлен");
            return user;
        }

        public List<User> GetAllUsers()
        {
            return context2.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context2.Users.Find(id);
        }

        public bool UpdateUser(int id, string newUsername)
        {
            var user = context2.Users.Find(id);
            if (user != null)
            {
                user.Username = newUsername;
                context2.SaveChanges();


                Console.WriteLine($"Пользователь ID {id} теперь \"{newUsername}\"");
                return true;
            }
            else
            {

                Console.WriteLine($"Пользователь с ID {id} не найден");

                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            var user = context2.Users.Find(id);
            if (user != null)
            {
                context2.Users.Remove(user);
                context2.SaveChanges();


                Console.WriteLine($"Пользователь ID {id} удалён");
                return true;
            }
            else
            {
                Console.WriteLine($"Пользователь с ID {id} не найден");
                return false;
            }
        }
    }
}
