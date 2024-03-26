using AutoMapper;
using ReadingPleasure.Common.DTOs.Review;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.MappingProfiles
{
    public class ReviewMappingProfile: Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReviewDto, Review>();
        }
    }
}
