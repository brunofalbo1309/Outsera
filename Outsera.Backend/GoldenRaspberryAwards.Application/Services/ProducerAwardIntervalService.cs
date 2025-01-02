using GoldenRaspberryAwards.Core.Entities;
using GoldenRaspberryAwards.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Index.Chain;
using System.Runtime.ExceptionServices;
using NetTopologySuite.DataStructures;
using Microsoft.VisualBasic;
using GoldenRaspberryAwards.Application.DTO;

namespace GoldenRaspberryAwards.Application.Services
{
    public class ProducerAwardIntervalService : IProducerAwardIntervalService
    {


        public AwardIntervalDTO getAwardInterval(List<Movie> movies)
        {
            List<ProducerAwardInterval> producerAwardMinIntervals = new List<ProducerAwardInterval>();
            List<ProducerAwardInterval> producerAwardMaxIntervals = new List<ProducerAwardInterval>();

            var movieLists = movies.Where(m => m.winner.Equals("yes"))
                                    .OrderBy(m => m.year)
                                    .GroupBy(m => m.producers)
                                    .Where(a => a.Count() > 1)
                                    .ToList();

            if (movieLists.Count > 0)
            {
                foreach (var movieList in movieLists)
                {


                    int anoAnterior = 0, interval = 0, previousWin = 0, followingWin = 0;
                    var producer = movieList.Key;
                    foreach (var movie in movieList.ToList())
                    {
                        previousWin = (previousWin == 0) ? movie.year : previousWin;
                        followingWin = movie.year;

                        interval += (anoAnterior == 0) ? 0 : movie.year - anoAnterior;
                        anoAnterior = movie.year;
                    }


                    var producerAwardInterval = new ProducerAwardInterval(producer, interval, previousWin, followingWin);

                    if (!producerAwardMinIntervals.Any())
                    {
                        producerAwardMinIntervals.Add(producerAwardInterval);
                    }
                    else
                    {
                        if (producerAwardMinIntervals[0].interval == producerAwardInterval.interval)
                        {
                            producerAwardMinIntervals.Add(producerAwardInterval);
                        }
                        else if (producerAwardMinIntervals[0].interval > producerAwardInterval.interval)
                        {
                            producerAwardMinIntervals[0] = producerAwardInterval;
                        }
                    }

                    if (!producerAwardMaxIntervals.Any())
                    {
                        producerAwardMaxIntervals.Add(producerAwardInterval);
                    }
                    else
                    {
                        if (producerAwardMaxIntervals[0].interval == producerAwardInterval.interval)
                        {
                            producerAwardMaxIntervals.Add(producerAwardInterval);
                        }
                        else if (producerAwardMaxIntervals[0].interval < producerAwardInterval.interval)
                        {
                            producerAwardMaxIntervals[0] = producerAwardInterval;
                        }
                    }
                }
            }

            return new AwardIntervalDTO(producerAwardMinIntervals, producerAwardMaxIntervals);
        }
    }
}
