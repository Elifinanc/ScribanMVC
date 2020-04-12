using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ScribanQuete2ConsoleApp.Model;

namespace ScribanQuete2ConsoleApp.Controller
{
    public class ProductContext: DbContext
    {
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=MVCScribanQuete;Integrated Security=True;MultipleActiveResultSets=true");
        }
    }
}
