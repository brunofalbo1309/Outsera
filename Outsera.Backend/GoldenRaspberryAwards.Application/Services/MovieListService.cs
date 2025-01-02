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
using CsvHelper.Configuration;
using System.Globalization;
using GoldenRaspberryAwards.Application.Interfaces;
using GoldenRaspberryAwards.Application.Options;

namespace GoldenRaspberryAwards.Application.Services
{
    public class MovieListService : IMovieListService
    {
        public BulkInsertMovieCommand ValidateMovieList(FileOption fileOption)
        {
            var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };


            var filePath = Path.Combine(fileOption.Folder, fileOption.Name);

            if (!File.Exists(filePath))
            {
                throw new FileNotExistsException(fileOption.Folder);
            }



            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader, cfg))
            {
                return new BulkInsertMovieCommand(csvReader.GetRecords<Movie>().ToList());
            }
        }
    }
}

