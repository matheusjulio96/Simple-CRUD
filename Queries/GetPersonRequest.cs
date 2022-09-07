using MediatR;

namespace Simple_CRUD.Queries
{
    public class GetPersonRequest : GetPerson, IRequest<Person>
    {
    }

    public class GetPerson
    {
        public int Id { get; set; }
    }
}
