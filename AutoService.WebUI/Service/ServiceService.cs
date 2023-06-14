using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository=serviceRepository;
            _unitOfWork=unitOfWork;
        }
    }

    public interface IServiceService
    {
    }
}
