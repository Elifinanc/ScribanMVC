using Scriban;
using ScribanQuete2ConsoleApp.Controller;
using ScribanQuete2ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribanQuete2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ProductList = new List<Product>();
            using (var context = new ProductContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //List<Product> ProductList = new List<Product>();
                for (int i = 1; i <= 10; i++)
                {
                    Product newProduct = new Product { Name = "ProductName" + i, Price = 10 };
                    ProductList.Add(newProduct);
                }
                context.AddRange(ProductList);
                context.SaveChanges();
            }

            var html = File.ReadAllText("C:/Users/konuk/source/repos/ScribanQuete2ConsoleApp/ScribanQuete2ConsoleApp/View/HTMLPage1.html");
            var template = Template.Parse(html);
            var result = template.Render(new { Products = ProductList });

            ProductController.Write(result);
        }
    }
}
