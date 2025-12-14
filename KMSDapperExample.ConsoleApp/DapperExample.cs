using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSDapperExample.ConsoleApp
{
    internal class DapperExample
    {
        private readonly SqlConnectionStringBuilder _bd;
        public DapperExample()
        {
            _bd = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "KMSBatch4MiniPOS",
                UserID = "sa",
                Password = "YourPassword123!",
                TrustServerCertificate = true
            };
        }

        public void AddProduct()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "Insert Into Tbl_Product(ProductName,Price,Quantity,IsDelete,CreatedDateTime) Values('BlueBerry',5000,3,0,GETDATE());";
                int result = connection.Execute(query);
                string message = result > 0 ? "Product added successfully." : "Failed to add product.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Read()
        {
            using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tbl_Product;";
                List<ProductDTO> result = connection.Query<ProductDTO>(query).ToList();

                foreach (var item in result)
                {
                    Console.WriteLine("Product Name: " + item.ProductName);
                    Console.WriteLine("Price: " + item.Price);
                    Console.WriteLine("Quantity: " + item.Quantity);

                }
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Edit()
        {
           using (IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tbl_Product WHERE ProductId = 4;";
               ProductDTO item=connection.Query<ProductDTO>(query).FirstOrDefault()!;
                if(item is null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Update()
        {
            using(IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Tbl_Product SET ProductName='Strawberry', Price=6000, Quantity=5 WHERE ProductId=4;";
                int result = connection.Execute(query);
                string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public void Delete()
        {
            using(IDbConnection connection = new SqlConnection(_bd.ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Tbl_Product WHERE ProductId=4;";
                int result = connection.Execute(query);
                string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
                Console.WriteLine(message);
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}