using Domain;
using Framework;

namespace Application;

public class PersonCommandHandlers :
    ICommandHandler<CreatePersonCommand>
    
{
    private readonly IPersonRepository _personRepository;


    public PersonCommandHandlers(IPersonRepository personRepository)
    {
        _personRepository = personRepository;

    }

    public async Task Handle(CreatePersonCommand command)
    {
        var person=new Person()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
        };

        await _personRepository.Create(person);

    }

}
public class PersonRequestHandlers :
    IRequestHandler<CreatePersonRequest,long>
    
{
    private readonly IPersonRepository _personRepository;


    public PersonRequestHandlers(IPersonRepository personRepository)
    {
        _personRepository = personRepository;

    }

    public async Task<long> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = new Person()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        await _personRepository.Create(person);

        return person.Id;
    }
}