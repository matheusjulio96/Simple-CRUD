using MediatR;

namespace Simple_CRUD.Queries
{
    public class GetPersonsRequest : GetPersons, IRequest<IEnumerable<Person>>
    {
    }

    public class GetPersons
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public DateTime? Date { get; set; }
        public bool? Active { get; set; }
        public string? Country { get; set; }
        public string? Role { get; set; }
        //paginacao
    }
}
