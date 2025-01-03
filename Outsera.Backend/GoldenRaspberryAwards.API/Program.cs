
using GoldenRaspberryAwards.Application.Commands;
using GoldenRaspberryAwards.Application.Interfaces;
using GoldenRaspberryAwards.Application.Options;
using GoldenRaspberryAwards.Application.Queries;
using GoldenRaspberryAwards.Application.Services;
using GoldenRaspberryAwards.Infrastructure.Persistence;
using MediatR;

namespace GoldenRaspberryAwards.API
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<SqliteDbContext>();

            builder.Services.AddScoped<IMovieListService, MovieListService>();
            builder.Services.AddScoped<IProducerAwardIntervalService, ProducerAwardIntervalService>();


            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<BulkInsertMovieCommand>());
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetAllMoviesQuery>());

            builder.Services.Configure<FileOption>(builder.Configuration.GetSection("FileOption"));


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetService<IMovieListService>();
                var mediator = services.GetService<IMediator>();
                var movielist = movieService.ValidateMovieList();
                mediator.Send(movieService.ValidateMovieList());
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
