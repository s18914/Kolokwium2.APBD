using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Exceptions
{
    public class ArtistDoesNotExistException : Exception
    {
        public ArtistDoesNotExistException()
        {
        }

        public ArtistDoesNotExistException(string message) : base(message)
        {
        }
    }
}
