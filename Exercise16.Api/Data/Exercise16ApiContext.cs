using Exercise16.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercise16.Api.Data
{
    public class Exercise16ApiContext : DbContext
    {
        public Exercise16ApiContext (DbContextOptions<Exercise16ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Device { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
