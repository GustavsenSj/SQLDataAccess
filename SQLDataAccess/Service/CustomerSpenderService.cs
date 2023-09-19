using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

/// <summary>
/// Provides services for retrieving information about the highest spenders among customers.
/// </summary>
public class CustomerSpenderService
{
    private readonly CustomerSpenderRepository _customerSpenderRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerSpenderService"/> class with the specified repository.
    /// </summary>
    /// <param name="customerSpenderRepository">The repository used for accessing customer spender data.</param>
    public CustomerSpenderService(CustomerSpenderRepository customerSpenderRepository)
    {
        _customerSpenderRepository = customerSpenderRepository;
    }

    /// <summary>
    /// Retrieves the top X highest spenders among customers.
    /// </summary>
    /// <param name="count">The number of highest spenders to retrieve.</param>
    /// <returns>A list of customers who have spent the most, ordered by descending total spent.</returns>
    public List<CustomerSpender> GetTopXHighestSpenders(int count)
    {
        return _customerSpenderRepository.GetTopXHighestSpenders(count);
    }
}