using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSDapperExample.ConsoleApp
{
    internal class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
