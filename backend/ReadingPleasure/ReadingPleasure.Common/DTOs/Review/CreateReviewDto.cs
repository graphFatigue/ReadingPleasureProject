using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPleasure.Common.DTOs.Review
{
    public class CreateReviewDto
    {
        public string Content { get; set; }
        public Guid ReaderId { get; set; }
        public Guid BookId { get; set; }
    }
}
