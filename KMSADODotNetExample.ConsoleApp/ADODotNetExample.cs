using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSADODotNetExample.ConsoleApp
{
    internal class ADODotNetExample
    {
        private readonly SqlConnectionStringBuilder _bd;
        public ADODotNetExample()
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
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "Insert Into Tbl_Product(ProductName,Price,Quantity,IsDelete,CreatedDateTime) Values('BlueBerry',5000,3,0,GETDATE());";
            SqlCommand cmd = new SqlCommand(query, connection);
            
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Product added successfully." : "Failed to add product.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
            connection.Close();
        }

        public void Read()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT  * FROM Tbl_Product;", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var no = dt.Rows.IndexOf(row)+1;
                Console.WriteLine($"{no} - {row["ProductName"]} - {row["Price"]} - {row["Quantity"]}");
            }
            Console.WriteLine("------------------------------------------------------");
            connection.Close();
        }

        public void Edit()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "Select * From Tbl_Product Where ProductId=2;";
          
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            if (dt.Rows.Count is 0)
              {  Console.WriteLine("No record found to update.");
                return;
            }           
            string productName = dt.Rows[0]["ProductName"].ToString();
            decimal price = Convert.ToDecimal( dt.Rows[0]["Price"]);
            int quantity = Convert.ToInt32( dt.Rows[0]["Quantity"]);
            Console.WriteLine($"{productName} - {price} - {quantity}");
            Console.WriteLine("------------------------------------------------------");
            connection.Close();

        }

        public void Update()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "Update Tbl_Product Set ProductName='Mango', Price=6000, Quantity=10 Where ProductId=2;";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
            connection.Close();
        }

        public void Delete()
        {
            using SqlConnection connection = new SqlConnection(_bd.ConnectionString);
            connection.Open();
            string query = "Delete From Tbl_Product Where ProductId=2;";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------------------------");
            connection.Close();
        }
    }
}
