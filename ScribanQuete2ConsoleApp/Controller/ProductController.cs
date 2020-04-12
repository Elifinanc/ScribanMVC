using ScribanQuete2ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScribanQuete2ConsoleApp.Controller
{
    public class ProductController
    {
        public static void Write(string message)
        {
            string root = @"C:\Users\konuk\source\repos\ScribanQuete2ConsoleApp\ScribanQuete2ConsoleApp\bin\Debug\testFiles";
            TextWriter TextWrite = new StreamWriter(root + "/textwriter.html");

            TextWrite.Write(message);
            
            TextWrite.Flush();
            TextWrite.Close();
            TextWrite = null;
        }

        public static List<Product> DisplayDefaultProducts()
        {
            using (var context = new ProductContext())
            {
                var defaultList = (from p in context.Product
                                   select p).ToList();
                return defaultList;
            }
        }
    }
}
