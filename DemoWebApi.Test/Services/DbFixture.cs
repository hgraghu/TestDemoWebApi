using DemoWebApi.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebApi.Test.Services
{
    public class DbFixture :IDisposable
    {
        public ApplicationDBContext DemoWebDbContext { get; set; }
        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            DemoWebDbContext = new ApplicationDBContext(options);
            _ = TempSeedDB.SeedDb(DemoWebDbContext);
        }

        public void Dispose()
        {
            DemoWebDbContext.Dispose();
        }
    }
}
