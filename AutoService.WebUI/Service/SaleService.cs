using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(ISaleRepository saleRepository, IUnitOfWork unitOfWork)
        {
            _saleRepository=saleRepository;
            _unitOfWork=unitOfWork;
        }
    }

    public interface ISaleService
    {
    }
}
