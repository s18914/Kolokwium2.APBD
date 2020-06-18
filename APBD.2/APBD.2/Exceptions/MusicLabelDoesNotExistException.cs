using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Exceptions
{
    public class MusicLabelDoesNotExistException : Exception
    {
        public MusicLabelDoesNotExistException()
        {
        }

        public MusicLabelDoesNotExistException(string message) : base(message)
        {
        }

        public MusicLabelDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
