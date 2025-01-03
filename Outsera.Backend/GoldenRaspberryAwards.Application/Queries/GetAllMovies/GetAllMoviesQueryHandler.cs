using GoldenRaspberryAwards.Core.Entities;
using GoldenRaspberryAwards.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Application.Queries.GetAllMovies
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<Movie>>
    {
        private readonly SqliteDbContext _dbContext;

        public GetAllMoviesQueryHandler(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var retorno = _dbContext.Movies.ToList<Movie>();
            return retorno;
        }
    }
}
