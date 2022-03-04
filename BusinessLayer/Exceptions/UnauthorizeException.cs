public class UnauthorizeException : Exception
{

    public UnauthorizeException(string message)
    {
        message = base.Message;

    }
}