using System.ComponentModel.DataAnnotations;

public class ValidationException : Exception
{
    public ValidationException(string message)
        : base(message)
        {

        }
}
    
