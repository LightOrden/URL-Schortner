using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;

namespace Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Url> Urls { get; set; }
    }
}
