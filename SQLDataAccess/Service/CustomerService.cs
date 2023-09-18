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

    public List<Customer> GetAllCustomersByName(string name)
    {
        return _customerRepository.GetAllCustomersByName(name);
    }

    public List<Customer> GetCustomerInRange(int limit, int offset)
    {
        return _customerRepository.GetCustomerInRange(limit, offset);
    }

    public bool AddCustomer(Customer customer)
    {
        return _customerRepository.AddCustomer(customer);
    }

    public bool UpdateCustomerWithId(int id, Customer customer)
    {
        return _customerRepository.UpdateCustomerWithId(id, customer);
    }

    public List<CustomerCountry> GetCustomersCountByCountry()
    {
        return _customerRepository.GetCustomersCountByCountry();
    }
}
