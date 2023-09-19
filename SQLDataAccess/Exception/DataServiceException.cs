namespace SQLDataAccess.Exception;

/// <summary>
/// Represents an exception specific to data service operations.
/// </summary>
public class DataServiceException : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataServiceException"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    public DataServiceException(string message) : base(message)
    {
    }
}