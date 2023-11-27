using Framework;
using Infrastructure.Query.Ef.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Ef;

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