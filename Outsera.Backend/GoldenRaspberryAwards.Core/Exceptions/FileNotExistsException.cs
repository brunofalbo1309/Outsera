using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberryAwards.Core.Exceptions
{
    public class FileNotExistsException : Exception
    {
        public FileNotExistsException(string filePath) : base($"Arquivo não existe no diretótio {filePath}")
        {
        }
    }
}
