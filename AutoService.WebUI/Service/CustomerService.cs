using AutoService.WebUI.Repositories;

namespace AutoService.WebUI.Service
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository=customerRepository;
            _unitOfWork=unitOfWork;
        }
    }

    public interface ICustomerService
    {
    }
}
