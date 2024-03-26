using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Authors
{
    public class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException() : base("Author was not found")
        {
        }
    }
}
