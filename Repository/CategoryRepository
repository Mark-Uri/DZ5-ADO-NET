using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    public class CategoryRepository
    {
        private readonly AppDbContext context1;

        public CategoryRepository()
        {
            context1 = new AppDbContext();
        }

        public Category AddCategory(string name)
        {
            var category = new Category { Name = name };
            context1.Categories.Add(category);
            context1.SaveChanges();


            Console.WriteLine($"Категория \"{name}\" добавлена!");
            return category;
        }

        public List<Category> GetAllCategories()
        {
            return context1.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return context1.Categories.Find(id);
        }

        public bool UpdateCategory(int id, string newName)
        {
            var category = context1.Categories.Find(id);
            if (category != null)
            {
                category.Name = newName;
                context1.SaveChanges();


                Console.WriteLine($"Категория ID {id} обновлена до \"{newName}\"");
                return true;
            }
            else
            {
                Console.WriteLine($"Категория с ID {id} не найдена");
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            var category = context1.Categories.Find(id);
            if (category != null)
            {
                context1.Categories.Remove(category);
                context1.SaveChanges();


                Console.WriteLine($"Категория ID {id} удалена");
                return true;
            }
            else
            {
                Console.WriteLine($"Категория с ID {id} не найдена");

                return false;
            }
        }
    }
}
