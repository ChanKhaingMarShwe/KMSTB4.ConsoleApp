using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMSTB4HomeWork.ConsoleApp.Database.AppDbContextModels;

namespace KMSTB4HomeWork.ConsoleApp
{
    internal class EFCore2Sample
    {
        private readonly AppDbContext _db;

        public EFCore2Sample(AppDbContext db)
        {
            _db = db;
        }

        public EFCore2Sample()
        {
        }

        public void Read()
        {
            List<Book> lst = _db.Books.ToList();

            foreach (var item in lst)
            {
                Console.WriteLine($"ID: {item.BookId}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Author: {item.Author}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Quantity: {item.Quantity}");
                Console.WriteLine("---");
            }
            Console.WriteLine("------------------------------------");
        }

        public void Create()
        {
            Book book = new Book()
            {
                Title = "Java",
                Author = "Java Developer",
                Price = 4500,
                Quantity = 5,
                IsDelete = false,
                CreatedDate = DateTime.Now
            };

            _db.Books.Add(book);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Book Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
        }

        public void Edit()
        {
            var item = _db.Books.FirstOrDefault(x => x.BookId == 1);

            if (item is null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"ID: {item.BookId}");
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Author: {item.Author}");
            Console.WriteLine("------------------------------------");
        }

        public void Update()
        {
            var item = _db.Books.FirstOrDefault(x => x.BookId == 1);
            if (item is null) return;

            item.Title = "Updated Book Title";
            item.ModifiedDate = DateTime.Now; 

            int result = _db.SaveChanges();

            string message = result > 0 ? "Updating successful" : "Updating Failed";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
        }

        public void Delete()
        {
            var item = _db.Books.FirstOrDefault(x => x.BookId == 2);
            if (item is null) return;

 
            item.IsDelete = true;
            item.ModifiedDate = DateTime.Now;

            int result = _db.SaveChanges();

            string message = result > 0 ? "Deleting successful" : "Deleting Failed";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
        }
    }
}
