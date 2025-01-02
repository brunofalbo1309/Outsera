using GoldenRaspberryAwards.Application.Commands;
using GoldenRaspberryAwards.Application.Interfaces;
using GoldenRaspberryAwards.Application.Queries;
using GoldenRaspberryAwards.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAwards.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {

        private readonly IMovieListService _movieListService;
        private readonly IMediator _mediator;

        private readonly IProducerAwardIntervalService _producerAwardIntervalService;

        public MovieController(IMovieListService movieListService, IMediator mediator, IProducerAwardIntervalService producerAwardIntervalService)
        {
            _movieListService = movieListService;
            _mediator = mediator;

            _producerAwardIntervalService = producerAwardIntervalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var moveiList = _mediator.Send(new GetAllMoviesQuery()).Result;
            return Ok(moveiList);
        }

        [HttpGet("GetProducerAwardInterval")]
        public async Task<IActionResult> GetProducerAwardInterval()
        {
            var retorno = _producerAwardIntervalService.getAwardInterval(_mediator.Send(new GetAllMoviesQuery()).Result);
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovies(IFormFile file)
        {
            var bulkInsertMovieCommand = _movieListService.ValidateMovieList(file.OpenReadStream(), file.FileName);

            var retorno = await _mediator.Send(bulkInsertMovieCommand);

            return Ok(retorno);
        }
    }
}
