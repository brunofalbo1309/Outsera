using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Core.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException() : base("Formato inválido de arquivo")
        {
            
        }
    }
}
