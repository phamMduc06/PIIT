using PIIT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PIIT.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("ConnectionString")
        {
            /*  this.Configuration.LazyLoadingEnabled = false;
              this.Configuration.ProxyCreationEnabled = false;*/
        }
        public DbSet<Coin> Coin { get; set; }
        public DbSet<CoinMarket> CoinMarket { get; set; }
    }
}