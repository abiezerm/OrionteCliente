public class NotFoundException : Exception
{
    public NotFoundException(string message = "", int entityId = 0, Type? entityType = null)
       : base(message)
    {
    }
}