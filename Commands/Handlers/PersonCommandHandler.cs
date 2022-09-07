using MediatR;
using Microsoft.EntityFrameworkCore;
using Simple_CRUD.Data;
using Simple_CRUD.Infrastructure;

namespace Simple_CRUD.Commands.Handlers
{
    public class PersonCommandHandler :
        IRequestHandler<CreatePersonCommand, CommandResponse<Person>>,
        IRequestHandler<UpdatePersonCommand, CommandResponse<Person>>,
        IRequestHandler<DeletePersonCommand, CommandResponse<Person>>
    {
        private readonly IDbContextFactory<SimpleCrudDbContext> dbContextFactory;

        public PersonCommandHandler(IDbContextFactory<SimpleCrudDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<CommandResponse<Person>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var entity = new PersonEntity
            {
                UserName = request.UserName,
                FullName = request.FullName,
                Date = request.Date,
                Active = request.Active,
                Country = request.Country,
                Role = request.Role
            };

            await dbContext.Persons.AddAsync(entity);
            var entries = await dbContext.SaveChangesAsync();

            return new CommandResponse<Person> { 
                Success = entries > 0, 
                Message = "Inserido com sucesso",
                Data = entity.ToModel()
            };
        }

        public async Task<CommandResponse<Person>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var entity = await dbContext.Persons.FindAsync(keyValues: request.Id);
            
            if (entity is null) return new CommandResponse<Person> { Success = false, Message = "Não encontrado" };

            entity.UserName = request.UserName;
            entity.FullName = request.FullName;
            entity.Date = request.Date;
            entity.Active = request.Active;
            entity.Country = request.Country;
            entity.Role = request.Role;

            dbContext.Persons.Update(entity);
            var entries = await dbContext.SaveChangesAsync();

            if (entries > 0)
                return new CommandResponse<Person>
                {
                    Success = true,
                    Message = "Alterado com sucesso",
                    Data = entity.ToModel()
                };
            else
                return new CommandResponse<Person>
                {
                    Success = false,
                    Message = "Nenhuma mudança realizada",
                    Data = entity.ToModel()
                };
        }

        public async Task<CommandResponse<Person>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();

            var entity = await dbContext.Persons.FindAsync(keyValues: request.Id);

            if (entity is null) return new CommandResponse<Person> { Success = false, Message = "Não encontrado" };

            dbContext.Persons.Remove(entity);
            var entries = await dbContext.SaveChangesAsync();

            if (entries > 0)
                return new CommandResponse<Person>
                {
                    Success = true,
                    Message = "Excluído com sucesso",
                    Data = entity.ToModel()
                };
            else
                return new CommandResponse<Person>
                {
                    Success = false,
                    Message = "Nenhuma mudança realizada",
                    Data = entity.ToModel()
                };
        }
    }
}
