using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMSTB4EFExample.ConsoleApp.Database.AppDbContextModels;

namespace KMSTB4EFExample.ConsoleApp
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
            List<TblProduct> lst=_db.TblProducts.ToList();
            foreach(var item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);
            }
            Console.WriteLine("------------------------------------");

        }
        public void Create()
        {
            TblProduct product = new TblProduct()
            {
                ProductName = "Kiwi",
                Price = 2000,
                Quantity = 10,
                IsDelete = false,
                CreatedDateTime = DateTime.Now
            };
            _db.TblProducts.Add(product);
            int result=_db.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving Failed";

            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");



        }
        public void Edit()
        {
            var item=_db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if (item is null) return;

            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Quantity);


            Console.WriteLine("------------------------------------");

        }
        public void Update()
        {
            var item = _db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if(item is null) return;
            item.ProductName = "Green Apple";
            int result=_db.SaveChanges();

            string message = result > 0 ? "Updating successful" : "Updating Failed";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
        }
        public void Delete()
        {
            var item= _db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if (item is null) return;
            item.IsDelete = true;
            int result= _db.SaveChanges();
            string message = result > 0 ? "Deleting successful" : "Deleting Failed";
            Console.WriteLine(message);
            Console.WriteLine("------------------------------------");
        }   
    }
}
