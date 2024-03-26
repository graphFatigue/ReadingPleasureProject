using ReadingPleasure.Common.Exceptions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Common.Exceptions.Reviews
{
    public class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException() : base("Review was not found")
        {
        }
    }
}
