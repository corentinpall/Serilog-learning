namespace Logging.Core;

public class LogDetail
{
    public DateTime Timestamp { get; set; }
    public string Message { get; set; }
    
    // WHERE
    public string Product { get; set; }
    public string Layer { get; set; }
    public string Location { get; set; }
    public string Hostname { get; set; }
    
    // WHO
    public string UserId { get; set; }
    public string UserName { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    
    // EVERYTHING ELSE
    public long? ElapsedMilliseconds { get; set; } // Only for performance entries
    public Exception Exception { get; set; } // The exception for error logging
    public string CorrelationId { get; set; } // Exception shielding from server to client
    public Dictionary<string, object> AdditionalInfo { get; set; } // Catch-all for everything else

    public LogDetail()
    {
        Timestamp = DateTime.Now;
    }
}