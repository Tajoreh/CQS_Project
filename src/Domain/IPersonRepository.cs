using Framework;

namespace Domain;

public interface IPersonRepository: IRepository
{
    Task Create(Person person);
}