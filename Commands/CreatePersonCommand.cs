using MediatR;
using Simple_CRUD.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Simple_CRUD.Commands
{
    public class CreatePersonCommand : CreatePerson, IRequest<CommandResponse<Person>>
    {
    }

    public class CreatePerson
    {
        [Required]
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public string Country { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
