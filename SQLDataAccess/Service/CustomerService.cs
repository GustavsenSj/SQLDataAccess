using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;
public class CustomerService
{
    private readonly CustomerRepository _customerRepository;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }

    // Add other methods for business logic related to customers
}
