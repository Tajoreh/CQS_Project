using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;
using Domain;

namespace Infrastructure.Persistence.Ef;
public class PeopleDbContext : DbContext
{

    public PeopleDbContext(DbContextOptions options) : base(options)
    {


    }
    public virtual DbSet<Person> Persons { get; set; } = null!;
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);

        base.OnModelCreating(modelBuilder);
    }

   
}