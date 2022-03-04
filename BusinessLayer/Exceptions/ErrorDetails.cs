using Microsoft.VisualBasic.CompilerServices;
using System.Net;
public class ErrorDetails
{
    public HttpStatusCode Status;
    public string Message;
    public string Title;
    public string TraceId;
    public ErrorDetails(HttpStatusCode status, string title, string message, string traceId)
    {
        Message = message;
        Title = title;
        TraceId = traceId;
        Status = status;
    }
}

