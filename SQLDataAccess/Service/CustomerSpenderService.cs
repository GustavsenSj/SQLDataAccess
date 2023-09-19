using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

public class CustomerSpenderService
{
    private readonly CustomerSpenderRepository _customerSpenderRepository;

    public CustomerSpenderService(CustomerSpenderRepository customerSpenderRepository)
    {
        _customerSpenderRepository = customerSpenderRepository;
    }

    public List<CustomerSpender> GetTopXHighestSpenders(int count)
    {
        return _customerSpenderRepository.GetTopXHighestSpenders(count);
    }
}