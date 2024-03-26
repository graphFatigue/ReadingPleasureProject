using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Books
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException() : base("Book was not found")
        {
        }
    }
}
