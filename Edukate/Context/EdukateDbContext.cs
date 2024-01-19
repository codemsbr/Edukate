using Edukate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Edukate.Context
{
    public class EdukateDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public EdukateDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
