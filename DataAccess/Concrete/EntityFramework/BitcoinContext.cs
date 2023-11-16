using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context : Db tabloları ile proje classlarını bağlamak
    public class BitcoinContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bitcoin;Username=postgres;Password=12345");
        }

        public DbSet<BitcoinValue> bitcoinvalues { get; set; }

    }
}
