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
using Microsoft.Extensions.Options;

namespace GoldenRaspberryAwards.Application.Services
{
    public class MovieListService : IMovieListService
    {
        public MovieListService(IOptions<FileOption> fileOption)
        {
            _fileOption = fileOption.Value;
        }

        private readonly FileOption _fileOption;

        public BulkInsertMovieCommand ValidateMovieList()
        {
            var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };


            var filePath = Path.Combine(_fileOption.Folder, _fileOption.Name);

            if (!File.Exists(filePath))
            {
                throw new FileNotExistsException(_fileOption.Folder);
            }



            var reader = new StreamReader(filePath);
            var csvReader = new CsvReader(reader, cfg);
                //var retorno = csvReader.GetRecords<Movie>().ToList();
                return new BulkInsertMovieCommand(csvReader.GetRecords<Movie>().ToList());
            
        }
    }
}

