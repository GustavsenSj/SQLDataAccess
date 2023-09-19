using SQLDataAccess.Exception;
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
        try
        {
            return _customerCountryRepository.GetCustomersCountByCountry();
        }
        catch (System.Exception ex)
        {
            throw new DataServiceException(
                "An error occurred while retrieving customer data: " + ex.Message);
        }
    }
}