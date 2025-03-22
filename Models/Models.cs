using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DZ_4
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public byte[]? ProfilePicture { get; set; }

        
        public List<Order> Orders { get; set; } = new();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Order> Orders { get; set; } = new();
    }

   
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }

        
        public List<Product> Products { get; set; } = new();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }

    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int Rating { get; set; }

       

        public int UserId { get; set; }
        public User User { get; set; } 

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
