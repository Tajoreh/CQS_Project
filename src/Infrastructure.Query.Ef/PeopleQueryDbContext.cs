using System.Security.Cryptography.X509Certificates;
using Infrastructure.Query.Ef.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Query.Ef;

public class PeopleQueryDbContext : DbContext
{

    public PeopleQueryDbContext(DbContextOptions options) : base(options)
    {


    }
    public virtual DbSet<Person> People { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);

        base.OnModelCreating(modelBuilder);
    }


}