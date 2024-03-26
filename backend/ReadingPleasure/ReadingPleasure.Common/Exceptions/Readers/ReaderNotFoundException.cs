using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.Readers
{
    public class ReaderNotFoundException : NotFoundException
    {
        public ReaderNotFoundException() : base("Reader was not found")
        {
        }
    }
}
