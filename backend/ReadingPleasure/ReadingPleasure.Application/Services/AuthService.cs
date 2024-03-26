using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.Auth;
using ReadingPleasure.Common.Exceptions.Auth;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUnitOfWork unitOfWork,
            IJwtService jwtService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
            {
                throw new InvalidCredentialsAuthException();
            }

            await CheckPasswordSigninAsync(user, loginDto.Password);

            //TODO: Get permissions

            var jwtAccessToken = await GenerateTokenAsync(user);

            return new AuthResponseDto
            {
                AccessToken = jwtAccessToken,
                User = user,
            };
        }

        public async Task SignupAsync(SignupDto signupDto)
        {
            var user = _mapper.Map<User>(signupDto);

            await CreateUserAsync(user, signupDto.Password);

            await CreateReaderAsync(user.Id, signupDto);
        }

        #region Private methods

        private async Task<string> GenerateTokenAsync(
            User user)
        {
            var jwtAccessToken = await _jwtService.GenerateTokenAsync(user);
            return jwtAccessToken;
        }

        private async Task CheckPasswordSigninAsync(User user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                throw new InvalidCredentialsAuthException();
            }
        }

        private async Task CreateUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }

        private async Task CreateReaderAsync(Guid userId, SignupDto signupDto)
        {
            var user = await _unitOfWork.GetRepository<IUserRepository>().GetByIdAsync(userId);


            var reader = new Reader
            {
                Id = Guid.NewGuid(),
                UserId = user!.Id,
            };

            user.Reader = reader;
            user.ReaderId = reader.Id;

            await _unitOfWork
                .GetRepository<IReaderRepository>()
                .AddAsync(reader);

            _unitOfWork.GetRepository<IUserRepository>().Update(user);

            await _unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
