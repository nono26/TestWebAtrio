using Microsoft.EntityFrameworkCore;
using part2.Models;

namespace Infrastructure.Models;

public class PersonneContext : DbContext
{
    public PersonneContext(DbContextOptions<PersonneContext> options)
        : base(options)
    {
    }

    public DbSet<Personne> PersonneItems { get; set; } = null!;
}