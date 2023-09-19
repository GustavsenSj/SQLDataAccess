using SQLDataAccess.Models;
using SQLDataAccess.Repositories;

namespace SQLDataAccess.Service;

public class CustomerGenreService
{
     private readonly CustomerGenreRepository _customerGenreRepository;
    
        public CustomerGenreService(CustomerGenreRepository customerGenreRepository)
        {
            _customerGenreRepository = customerGenreRepository;
        }
    
 public CustomerGenre GetTopGenreOfCustomerWithId(int id)
    {
        CustomerGenre? customerGenre = _customerGenreRepository.GetTopGenreOfCustomerWithId(id);
        if (customerGenre == null)
        {
            throw new InvalidOperationException("No tracks or customer found with Id: " + id);
        }

        return customerGenre;
    }}