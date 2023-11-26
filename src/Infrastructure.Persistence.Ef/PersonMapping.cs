using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Ef;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People").HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}

public class PersonRepository : IPersonRepository
{
    PeopleDbContext _dbContext;

    public PersonRepository(PeopleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Person person)
    {
        await _dbContext.Set<Person>()
            .AddAsync(person);
       await _dbContext.SaveChangesAsync();
    }

   
}