using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

public class CustomerCountryService
{
    private readonly CustomerCountryRepository _customerCountryRepository;

    public CustomerCountryService(CustomerCountryRepository customerCountryRepository)
    {
        _customerCountryRepository = customerCountryRepository;
    }

    public List<CustomerCountry> GetCustomersCountByCountry()
    {
        return _customerCountryRepository.GetCustomersCountByCountry();
    }
}