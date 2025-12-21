using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSTB4HomeWork.ConsoleApp
{

    internal class DapperSample
    {
        private readonly SqlConnectionStringBuilder _bd;
        public DapperSample()
        {
            _bd = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "BookManagement",
                UserID = "sa",
                Password = "YourPassword123!",
                TrustServerCertificate = true
            };
        }


        public void Create()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Books (Title, Author, Price, Quantity, IsDelete, CreatedDate) 
                             VALUES ('C#', 'C# Developer', 4500, 20, 0, GETDATE());";

                int result = connection.Execute(query);
                string message = result > 0 ? "Book added successfully." : "Failed to add book.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Read()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                // Only select books where IsDelete is 0 (False)
                string query = "SELECT * FROM Books;";
                List<BookDTO> result = connection.Query<BookDTO>(query).ToList();

                foreach (var item in result)
                {
                    Console.WriteLine($"Title: {item.Title}");
                    Console.WriteLine($"Author: {item.Author}");
                    Console.WriteLine($"Price: {item.Price}");
                    Console.WriteLine($"Quantity: {item.Quantity}");
                    Console.WriteLine("---");
                }
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Edit()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Books WHERE BookId = 1;";
                BookDTO item = connection.Query<BookDTO>(query).FirstOrDefault()!;

                if (item is null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                Console.WriteLine($"ID: {item.BookId}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Author: {item.Author}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Update()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                // Updates Title, Price and sets the ModifiedDate
                string query = @"UPDATE Books 
                             SET Title = 'Advanced C#', Price = 9000, ModifiedDate = GETDATE() 
                             WHERE BookId = 1;";

                int result = connection.Execute(query);
                string message = result > 0 ? "Book updated successfully." : "Failed to update book.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Delete()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Books SET IsDelete = 1, ModifiedDate = GETDATE() WHERE BookId = 1;";

                int result = connection.Execute(query);
                string message = result > 0 ? "Book deleted successfully." : "Failed to delete book.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }



    }
}
