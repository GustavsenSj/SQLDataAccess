using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;
using SQLDataAccess.Repositories;
using SQLDataAccess.Service;

// Set up connections 
string connectionString = GetConnectionString();

//call functions
// Console.WriteLine("All customers \n----------------");
// PrintCustomer(connectionString);
//
// Console.WriteLine("-----------\n Find by Id \n-------------");
// FindAndPrintCustomerById(1, connectionString);
//
//
// Console.WriteLine("-----------\n Find by Name \n-------------");
// PrintCustomerByName(connectionString, "Bj");
//
//
// Console.WriteLine("-----------\n Get with limit and offset \n-------------");
// PrintCustomerWithOffset(connectionString, 10, 5);
//
//
// Console.WriteLine("-----------\n Add customer \n-------------");
// TryToAddCustomer(connectionString, new Customer()
// {
//     FirstName = "Sjur",
//     LastName = "Gustavsen",
//     Country = "Norway",
//     PostalCode = "0087",
//     Phone = "54888548",
//     Email = "mail@CoolMail.com"
// });

// Console.WriteLine("-----------\n Update customer \n-------------");
// TryToUpdateCustomer(connectionString, 60, new Customer()
// {
//     FirstName = "Sjur Updated",
//     LastName = "Gustavsen",
//     Country = "Norway",
//     PostalCode = "0087",
//     Phone = "54888548",
//     Email = "mail@CoolMail.com"
// });


Console.WriteLine("-----------\n Customer count by country \n-------------");
PrintCustomerCountByCountry(connectionString);

return;

static string GetConnectionString()
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


static void PrintCustomer(string connectionString)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);
    try
    {
        List<Customer> customers = customerService.GetAllCustomers();

        foreach (var customer in customers)
        {
            Console.WriteLine(
                $"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Postal: {customer.PostalCode}, Phone: {customer.Phone}, Email: {customer.Email} ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static void PrintCustomerByName(string connectionString, string name)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);
    try
    {
        List<Customer> customers = customerService.GetAllCustomersByName(name);

        foreach (var customer in customers)
        {
            Console.WriteLine(
                $"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Postal: {customer.PostalCode}, Phone: {customer.Phone}, Email: {customer.Email} ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static void FindAndPrintCustomerById(int id, string connectionString)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);
    try
    {
        Customer customer = customerService.GetCustomerById(id);
        Console.WriteLine(
            $"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Postal: {customer.PostalCode}, Phone: {customer.Phone}, Email: {customer.Email} ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static void PrintCustomerWithOffset(string connectionString, int limit, int offset)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);
    try
    {
        List<Customer> customers = customerService.GetCustomerInRange(limit, offset);

        foreach (var customer in customers)
        {
            Console.WriteLine(
                $"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Postal: {customer.PostalCode}, Phone: {customer.Phone}, Email: {customer.Email} ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static void TryToAddCustomer(string connectionString, Customer customer)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);

    bool success = customerService.AddCustomer(customer);

    Console.WriteLine($"Added customer: {success}");
}

static void TryToUpdateCustomer(string connectionString, int id, Customer customer)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);

    bool success = customerService.UpdateCustomerWithId(id, customer);

    Console.WriteLine($"Update customer: {success}");
}

static void PrintCustomerCountByCountry(string connectionString)
{
    DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
    var customerRepository = new CustomerRepository(dbConnection);
    var customerService = new CustomerService(customerRepository);

    List<CustomerCountry> customerCountry = customerService.GetCustomersCountByCountry();

    foreach (var country in customerCountry)
    {
        Console.WriteLine($"Country: {country.Country}, Count: {country.Count} ");
    }
}