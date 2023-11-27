using Framework;

namespace Infrastructure.Query.Ef;

public class GetPersonRequest : IQuery
{
    public long Id { get; set; }

}