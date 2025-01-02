using GoldenRaspberryAwards.Application.Commands;
using GoldenRaspberryAwards.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using GoldenRaspberryAwards.Core.Entities;
using GoldenRaspberryAwards.Application.Map;
using CsvHelper.Configuration;
using System.Globalization;
using GoldenRaspberryAwards.Application.Interfaces;

namespace GoldenRaspberryAwards.Application.Services
{
    public class MovieListService : IMovieListService
    {
        public BulkInsertMovieCommand ValidateMovieList(Stream stream, string fileName)
        {
            if (!Path.GetExtension(fileName).Equals(".csv"))
                throw new InvalidFileFormatException();


            var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using (var reader = new StreamReader(stream))
            using (var csvReader = new CsvReader(reader, cfg))
            {
                return new BulkInsertMovieCommand(csvReader.GetRecords<Movie>().ToList());
            }


        }
    }
}
