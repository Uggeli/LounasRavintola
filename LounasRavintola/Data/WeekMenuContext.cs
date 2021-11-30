using Microsoft.EntityFrameworkCore;
using LounasRavintola.Models;

namespace LounasRavintola.Data
{
    public class WeekMenuContext : DbContext
    {
        public WeekMenuContext(DbContextOptions<WeekMenuContext> options) : base(options)
        {
        }

        public DbSet<WeekMenu> WeekMenus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }

    public enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    
}
