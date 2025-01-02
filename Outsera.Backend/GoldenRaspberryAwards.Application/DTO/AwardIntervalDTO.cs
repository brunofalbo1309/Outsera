using GoldenRaspberryAwards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Application.DTO
{
    public class AwardIntervalDTO
    {
        public AwardIntervalDTO(List<ProducerAwardInterval> min, List<ProducerAwardInterval> max)
        {
            this.min = min;
            this.max = max;
        }

        public List<ProducerAwardInterval> min { get; private set; }
        public List<ProducerAwardInterval> max { get; private set; }
    }
}
