using GoldenRaspberryAwards.Core.Entities;
using MediatR;

namespace GoldenRaspberryAwards.Application.Queries
{
    public class GetAllMoviesQuery : IRequest<List<Movie>>
    {
    }
}
