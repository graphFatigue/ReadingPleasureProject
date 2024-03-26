using ReadingPleasure.Common.DTOs.Auth;

namespace ReadingPleasure.Abstractions.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task SignupAsync(SignupDto signupDto);
    }
}
