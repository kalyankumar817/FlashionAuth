using FlashionAuth.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlashionAuth.Data
{
    public class MvcDemoDbContext:DbContext
    {
        public MvcDemoDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Logindata>Logindatas { get; set; }
        public DbSet<Signupdata>Signupdatas { get; set; }
    }
}
