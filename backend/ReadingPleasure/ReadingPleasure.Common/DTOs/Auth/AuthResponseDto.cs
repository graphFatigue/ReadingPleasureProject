
namespace ReadingPleasure.Common.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public Domain.Entities.User User { get; set; }
    }
}
