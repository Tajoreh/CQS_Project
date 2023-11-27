using Framework;

namespace Application;

public class CreatePersonRequest : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}