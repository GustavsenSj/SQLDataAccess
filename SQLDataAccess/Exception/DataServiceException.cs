namespace SQLDataAccess.Exception;
public class DataServiceException : System.Exception
{
    public DataServiceException(string message) : base(message)
    {
    }
}
