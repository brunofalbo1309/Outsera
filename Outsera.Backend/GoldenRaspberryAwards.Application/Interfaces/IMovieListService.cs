﻿using GoldenRaspberryAwards.Application.Commands;
using GoldenRaspberryAwards.Application.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Application.Interfaces
{
    public interface IMovieListService
    {
        BulkInsertMovieCommand ValidateMovieList();
    }
}
