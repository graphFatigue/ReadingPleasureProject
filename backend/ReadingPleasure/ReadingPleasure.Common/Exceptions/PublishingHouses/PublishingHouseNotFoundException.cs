using ReadingPleasure.Common.Exceptions.Shared;

namespace ReadingPleasure.Common.Exceptions.PublishingHouses
{
    public class PublishingHouseNotFoundException : NotFoundException
    {
        public PublishingHouseNotFoundException() : base("Publishing House was not found")
        {
        }
    }
}
