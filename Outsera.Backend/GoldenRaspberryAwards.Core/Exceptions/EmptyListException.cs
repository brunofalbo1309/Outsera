using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Core.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException() : base("Lista de filmes esta vazia")
        {
        }
    }
}
