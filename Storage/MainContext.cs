using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    internal class MainContext: DbContext
    {
        protected Logger log = LogManager.GetCurrentClassLogger();
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; }

        public MainContext()
        {
            var path = Environment.CurrentDirectory;
            DbPath = Path.Combine(path, "storage.sqlite");
            log.Info("Using DB in " + DbPath);
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            SQLitePCL.Batteries.Init();
        }
    }
}
