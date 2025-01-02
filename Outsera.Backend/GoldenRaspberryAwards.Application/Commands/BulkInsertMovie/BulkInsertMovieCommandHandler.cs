using EFCore.BulkExtensions;
using GoldenRaspberryAwards.Core.Entities;
using GoldenRaspberryAwards.Infrastructure.Persistence;
using MediatR;

namespace GoldenRaspberryAwards.Application.Commands
{
    public class BulkInsertMovieCommandHandler : IRequestHandler<BulkInsertMovieCommand, int>
    {
        private readonly SqliteDbContext _dbContext;

        public BulkInsertMovieCommandHandler(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(BulkInsertMovieCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Database.EnsureCreatedAsync(cancellationToken);

            //await _dbContext.Movies.AddAsync(new Movie(2010,"title","studio","producer","winner"));

            await _dbContext.BulkInsertAsync<Movie>(request.Movies);


            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
