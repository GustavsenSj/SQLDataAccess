using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

/// <summary>
/// Provides services for retrieving the top genre of a customer with a specified ID.
/// </summary>
public class CustomerGenreService
{
    private readonly CustomerGenreRepository _customerGenreRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerGenreService"/> class with the specified repository.
    /// </summary>
    /// <param name="customerGenreRepository">The repository used for retrieving top genre information.</param>
    public CustomerGenreService(CustomerGenreRepository customerGenreRepository)
    {
        _customerGenreRepository = customerGenreRepository;
    }

    /// <summary>
    /// Retrieves the top genre of a customer with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the customer for whom to retrieve the top genre.</param>
    /// <returns>The top genre of the customer with the specified ID.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no tracks or customer are found with the specified ID.</exception>
    public CustomerGenre GetTopGenreOfCustomerWithId(int id)
    {
        CustomerGenre? customerGenre = _customerGenreRepository.GetTopGenreOfCustomerWithId(id);
        if (customerGenre == null)
        {
            throw new InvalidOperationException("No tracks or customer found with Id: " + id);
        }

        return customerGenre;
    }
}