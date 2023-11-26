using Framework;

namespace Application;


public class CreatePersonCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}