using MediatR;
using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Data;

namespace Simple_CRUD.Queries
{
    public class GetPersonRequestHandler : IRequestHandler<GetPersonRequest, Person>
    {

        private readonly IDbContextFactory<SimpleCrudDbContext> dbContextFactory;

        public GetPersonRequestHandler(IDbContextFactory<SimpleCrudDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<Person> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var entity = await dbContext.Persons.FindAsync(keyValues: request.Id);
            return entity?.ToModel();
        }
    }
}
