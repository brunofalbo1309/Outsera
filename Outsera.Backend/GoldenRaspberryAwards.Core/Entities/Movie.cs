using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Core.Entities
{
    public class Movie : BaseEntity
    {
        public Movie(int year, string title, string studios, string producers, string winner)
        {
            this.year = year;
            this.title = title;
            this.studios = studios;
            this.producers = producers;
            this.winner = winner;
        }

        public int year { get; private set; }
        public string title { get; private set; }
        public string studios { get; private set; }
        public string producers { get; private set; }
        public string winner { get; private set; }
    }
}
