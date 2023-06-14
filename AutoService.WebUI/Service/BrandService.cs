using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{
    public interface IBrandService
    {
    }
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork=unitOfWork;
        }
    }
}
