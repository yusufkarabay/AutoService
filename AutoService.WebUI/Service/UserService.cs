using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository=userRepository;
            _unitOfWork=unitOfWork;
        }
    }

    public interface IUserService
    {
    }
}
