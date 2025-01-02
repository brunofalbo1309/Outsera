using GoldenRaspberryAwards.Application.DTO;
using GoldenRaspberryAwards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Application.Interfaces
{
    public interface IProducerAwardIntervalService
    {
        AwardIntervalDTO getAwardInterval(List<Movie> movies);
    }
}
