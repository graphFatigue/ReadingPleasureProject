using AutoMapper;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Common.DTOs.User;
using ReadingPleasure.Common.Exceptions.Users;

namespace ReadingPleasure.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStorageService _blobStorageService;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStorageService blobStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _unitOfWork.GetRepository<IUserRepository>().GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.GetRepository<IUserRepository>().GetByIdAsync(id, cancellationToken);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            user.Image += "?" + await _blobStorageService.GetSasTokenAsync("user-photos", user.Email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateAsync(Guid id,
           UpdateUserDto updateUserDto,
           CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork
                           .GetRepository<IUserRepository>()
                           .GetByIdAsync(id, cancellationToken)
                       ?? throw new UserNotFoundException();


            if (!string.IsNullOrWhiteSpace(updateUserDto.FirstName)
                && user.FirstName != updateUserDto.FirstName)
            {
                user.FirstName = updateUserDto.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(updateUserDto.LastName)
                && user.LastName != updateUserDto.LastName)
            {
                user.LastName = updateUserDto.LastName;
            }

            if (updateUserDto.ImageBytes != null)
            {
                var stream = new MemoryStream(updateUserDto.ImageBytes);

                var blobUri =
                    await _blobStorageService.UploadAsync(stream, "user-photos", user.Email);

                user.Image = blobUri;
            }

            if (updateUserDto.BirthDate != null)
            {
                user.BirthDate = updateUserDto.BirthDate;
            }

            _unitOfWork
                .GetRepository<IUserRepository>()
                .Update(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
