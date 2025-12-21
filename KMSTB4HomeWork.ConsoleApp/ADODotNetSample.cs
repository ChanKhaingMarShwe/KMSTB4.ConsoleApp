using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSTB4HomeWork.ConsoleApp
{
    internal class ADODotNetSample
    {
        private readonly SqlConnectionStringBuilder _bd;

        public ADODotNetSample()
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
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "INSERT INTO Books (Title, Author, Price, Quantity, IsDelete, CreatedDate) VALUES ('C# Programming', 'John Doe', 50.00, 10, 0, GETDATE());";
            SqlCommand cmd = new SqlCommand(query, connection);

            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Book added successfully." : "Failed to add book.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
        }

        public void Read()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books;", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var no = dt.Rows.IndexOf(row) + 1;
                Console.WriteLine($"{no} - {row["Title"]} - {row["Author"]} - {row["Price"]} - {row["Quantity"]}");
            }
            Console.WriteLine("------------------------------------------------------");
        }

        public void Edit()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "SELECT * FROM Books WHERE BookId = 1;";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found.");
                return;
            }

            string title = dt.Rows[0]["Title"].ToString();
            string author = dt.Rows[0]["Author"].ToString();
            decimal price = Convert.ToDecimal(dt.Rows[0]["Price"]);
            Console.WriteLine($"{title} by {author} - ${price}");
            Console.WriteLine("------------------------------------------------------");
        }

        public void Update()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "UPDATE Books SET Title = 'Advanced C#', Price = 65.00, ModifiedDate = GETDATE() WHERE BookId = 1;";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Book updated successfully." : "Failed to update book.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
        }

        public void Delete()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "UPDATE Books SET IsDelete = 1, ModifiedDate = GETDATE() WHERE BookId = 1;";
            SqlCommand cmd = new SqlCommand(query, connection);

            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Book deleted (Soft Delete) successfully." : "Failed to delete book.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
