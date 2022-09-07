using MediatR;
using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Data;

namespace Simple_CRUD.Queries
{
    public class GetPersonsRequestHandler : IRequestHandler<GetPersonsRequest, IEnumerable<Person>>
    {
        private readonly IDbContextFactory<SimpleCrudDbContext> dbContextFactory;

        public GetPersonsRequestHandler(IDbContextFactory<SimpleCrudDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<IEnumerable<Person>> Handle(GetPersonsRequest request, CancellationToken cancellationToken)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            request.Username = request?.Username?.ToLower();
            request.Fullname = request?.Fullname?.ToLower();
            request.Country = request?.Country?.ToLower();
            request.Role = request?.Role?.ToLower();

            var query = dbContext.Persons.AsNoTracking()
                .Where(p => 
                (request.Id == null || request.Id == p.Id) &&
                (string.IsNullOrEmpty(request.Username) || p.UserName.ToLower().Contains(request.Username)) &&
                (string.IsNullOrEmpty(request.Fullname) || p.FullName.ToLower().Contains(request.Fullname)) &&
                (request.Active == null || request.Active == p.Active) &&
                (request.Date == null || request.Date == p.Date) &&
                (string.IsNullOrEmpty(request.Country) || p.Country.ToLower().Contains(request.Country)) &&
                (string.IsNullOrEmpty(request.Role) || p.Role.ToLower().Contains(request.Role))
                )
                .Select(e => e.ToModel()).ToArray();

            return query;
        }
    }
}
