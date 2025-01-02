using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Core.Entities
{
    public class ProducerAwardInterval
    {
        public ProducerAwardInterval(string producer, int interval, int previousWin, int followingWin)
        {
            this.producer = producer;
            this.interval = interval;
            this.previousWin = previousWin;
            this.followingWin = followingWin;
        }

        public string producer { get; private set; }
        public int interval { get; private set; }
        public int previousWin { get; private set; }
        public int followingWin { get; private set; }
    }
}
