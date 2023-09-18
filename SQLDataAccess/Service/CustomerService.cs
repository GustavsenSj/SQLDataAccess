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

    public Customer GetCustomerById(int id)
    {
        Customer? customer = _customerRepository.GetCustomerById(id);

        if (customer == null)
        {
            throw new InvalidOperationException("Customer not found by ID: " + id);
        }

        return customer;

    }
}
