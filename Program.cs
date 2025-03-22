using Microsoft.EntityFrameworkCore;

namespace DZ_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var category1 = new Category { Name = "Электроника" };
                var category2 = new Category { Name = "Одежда" };

                var product1 = new Product { Name = "Смартфон", Price = 599.99m, Category = category1 };
                var product2 = new Product { Name = "Футболка", Price = 19.99m, Category = category2 };
                var product3 = new Product { Name = "Ноутбук", Price = 999.99m, Category = category1 };



                var user1 = new User { Username = "Alice", Password = "1234" };
                var user2 = new User { Username = "Bob", Password = "qwerty" };

                var order1 = new Order { User = user1, Products = new() { product1, product3 } };
                var order2 = new Order { User = user2, Products = new() { product2 } };

                context.AddRange(category1, category2, product1, product2, product3, user1, user2, order1, order2);
                context.SaveChanges();
            }

            Console.WriteLine("Данные успешно добавлены в базу!");



            using (var context = new AppDbContext())
            {
                var users = context.Users.ToList();
                Console.WriteLine("Список пользователей: ");

                foreach (var user in users)
                {
                    Console.WriteLine($"ID:  {user.Id}             Логин: {user.Username}");
                }

                var orders = context.Orders.Include(o => o.User).Include(o => o.Products).ToList();
                Console.WriteLine("\n Список заказов:");

                foreach (var order in orders)
                {
                    Console.WriteLine($"Заказ ID: {order.Id}    Пользователь: {order.User.Username}    Дата: {order.OrderDate}");
                    foreach (var product in order.Products)
                        Console.WriteLine($"  - Товар: {product.Name}    Цена: {product.Price} грн");
                }


                    
            }

            using (var context = new AppDbContext())
            {
                int userId = 1; 

                var user = context.Users.Find(userId);

                if (user != null)
                    Console.WriteLine($"Найден пользователь: {user.Username}");
                else
                    Console.WriteLine("Пользователь не найден");
            }






            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == "Alice");
                if (user != null)
                {
                    user.Password = "newpassword123";
                    context.SaveChanges();


                    Console.WriteLine($"Пароль пользователя {user.Username} изменён ");
                }
            }



            using (var context = new AppDbContext())
            {
                var userToDelete = context.Users.FirstOrDefault(u => u.Username == "Bob");
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                    Console.WriteLine($" Пользователь {userToDelete.Username} удалён");
                }
            }




        }
    }
}
