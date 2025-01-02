using GoldenRaspberryAwards.Core.Entities;
using MediatR;

namespace GoldenRaspberryAwards.Application.Commands
{
    public class BulkInsertMovieCommand : IRequest<int>
    {
        public BulkInsertMovieCommand(List<Movie> movies)
        {
            Movies = movies;
        }

        public List<Movie> Movies { get; private set; }
    }
}