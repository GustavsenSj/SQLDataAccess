
using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;
using SQLDataAccess.Repositories;
using SQLDataAccess.Service;

// Set up connections 
DatabaseConnection dbConnection = new DatabaseConnection(GetConnectionString());
var customerRepository = new CustomerRepository(dbConnection);
var customerService = new CustomerService(customerRepository);

//call functions

PrintCustomer();

string GetConnectionString()
{
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
    {
        DataSource = "N-NO-01-03-2688",
        InitialCatalog = "Chinook",
        IntegratedSecurity = true,
        TrustServerCertificate = true
    };
    return builder.ConnectionString;
}


void PrintCustomer()
{
    List<Customer> customers = customerService.GetAllCustomers();

    foreach (var customer in customers)
    {
        Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Postal: {customer.PostalCode}, Phone: {customer.Phone}, Email: {customer.Email} ");
    }
    
}
