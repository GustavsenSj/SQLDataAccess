using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

/// <summary>
/// Provides services for managing customer data.
/// </summary>
public class CustomerService
{
    private readonly CustomerRepository _customerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerService"/> class with the specified repository.
    /// </summary>
    /// <param name="customerRepository">The repository used for accessing customer data.</param>
    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <summary>
    /// Retrieves all customers.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    public List<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }


    /// <summary>
    /// Retrieves a customer by their ID.
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve.</param>
    /// <returns>The customer with the specified ID.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no customer is found with the specified ID.</exception>
    public Customer GetCustomerById(int id)
    {
        Customer? customer = _customerRepository.GetCustomerById(id);

        if (customer == null)
        {
            throw new InvalidOperationException("Customer not found by ID: " + id);
        }

        return customer;
    }


    /// <summary>
    /// Retrieves customers by their name.
    /// </summary>
    /// <param name="name">The name or part of the name to search for.</param>
    /// <returns>A list of customers whose name contains the specified search term.</returns>
    public List<Customer> GetAllCustomersByName(string name)
    {
        return _customerRepository.GetAllCustomersByName(name);
    }


    /// <summary>
    /// Retrieves a range of customers with pagination.
    /// </summary>
    /// <param name="limit">The maximum number of customers to retrieve.</param>
    /// <param name="offset">The number of customers to skip before retrieving.</param>
    /// <returns>A list of customers within the specified range.</returns>
    public List<Customer> GetCustomerInRange(int limit, int offset)
    {
        return _customerRepository.GetCustomerInRange(limit, offset);
    }


    /// <summary>
    /// Adds a new customer.
    /// </summary>
    /// <param name="customer">The customer to add.</param>
    /// <returns>True if the customer was added successfully; otherwise, false.</returns>
    public bool AddCustomer(Customer customer)
    {
        return _customerRepository.AddCustomer(customer);
    }

    /// <summary>
    /// Updates an existing customer with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="customer">The updated customer information.</param>
    /// <returns>True if the customer was updated successfully; otherwise, false.</returns>
    public bool UpdateCustomerWithId(int id, Customer customer)
    {
        return _customerRepository.UpdateCustomerWithId(id, customer);
    }
}