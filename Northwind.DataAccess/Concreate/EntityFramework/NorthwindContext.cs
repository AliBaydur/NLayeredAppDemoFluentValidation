using Northwind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concreate.EntityFramework
{
    public class NorthwindContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
