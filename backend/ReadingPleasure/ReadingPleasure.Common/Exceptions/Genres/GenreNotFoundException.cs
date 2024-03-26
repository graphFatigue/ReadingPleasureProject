using ReadingPleasure.Common.Exceptions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Common.Exceptions.Genres
{
    public class GenreNotFoundException : NotFoundException
    {
        public GenreNotFoundException() : base("Genre was not found")
        {
        }
    }
}
