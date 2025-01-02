using GoldenRaspberryAwards.Application.Commands;
using GoldenRaspberryAwards.Application.Interfaces;
using GoldenRaspberryAwards.Application.Options;
using GoldenRaspberryAwards.Application.Queries;
using GoldenRaspberryAwards.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GoldenRaspberryAwards.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {

        private readonly IMovieListService _movieListService;
        private readonly IMediator _mediator;

        private readonly IProducerAwardIntervalService _producerAwardIntervalService;

        private readonly FileOption _fileOption;

        public MovieController(IMovieListService movieListService, IMediator mediator, IProducerAwardIntervalService producerAwardIntervalService, IOptions<FileOption> fileOption)
        {
            _movieListService = movieListService;
            _mediator = mediator;
            _producerAwardIntervalService = producerAwardIntervalService;
            _fileOption = fileOption.Value;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetProducerAwardInterval()
        {
            var retorno = _producerAwardIntervalService.getAwardInterval(_mediator.Send(new GetAllMoviesQuery()).Result);
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovieList()
        {
            var bulkInsertMovieCommand = _movieListService.ValidateMovieList(_fileOption);

            var retorno = await _mediator.Send(bulkInsertMovieCommand);

            return Ok(retorno);
        }
    }
}
