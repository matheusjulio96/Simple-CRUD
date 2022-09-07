using MediatR;
using Simple_CRUD.Infrastructure;

namespace Simple_CRUD.Commands
{
    public class DeletePersonCommand : DeletePerson, IRequest<CommandResponse<Person>>
    {
    }

    public class DeletePerson
    {
        public int Id { get; set; }
    }
}
