using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{
    public interface ICarService
    {
    }
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork)
        {
            _carRepository=carRepository;
            _unitOfWork=unitOfWork;
        }
    }


}
