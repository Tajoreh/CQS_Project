using System.Security.Cryptography.X509Certificates;
using Framework;
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

public class GetPersonRequest : IQuery
{
    public long Id { get; set; }

}
public class PersonQueryHandlers :
    IQueryHandler<GetPersonRequest, Person>
{
    private readonly PeopleQueryDbContext _dbContext;

    public PersonQueryHandlers(PeopleQueryDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Person> Handle(GetPersonRequest request)
    {
       return await _dbContext.Set<Person>()
            .FirstOrDefaultAsync(x => x.Id == request.Id);
    }
}