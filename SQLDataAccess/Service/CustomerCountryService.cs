using SQLDataAccess.Exception;
using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

/// <summary>
/// Provides services for retrieving customer count by country information.
/// </summary>
public class CustomerCountryService
{
    private readonly CustomerCountryRepository _customerCountryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerCountryService"/> class with the specified repository.
    /// </summary>
    /// <param name="customerCountryRepository">The repository used for retrieving customer count by country information.</param>
    public CustomerCountryService(CustomerCountryRepository customerCountryRepository)
    {
        _customerCountryRepository = customerCountryRepository;
    }

    /// <summary>
    /// Retrieves a list of customer count by country information.
    /// </summary>
    /// <returns>A list of <see cref="CustomerCountry"/> objects representing customer count by country data.</returns>
    /// <exception cref="DataServiceException">Thrown when an error occurs during data retrieval.</exception>
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