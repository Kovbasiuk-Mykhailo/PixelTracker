namespace Messaging.Contract;

public class PageVisitedEvent(
    string? referer,
    string? userAgent,
    string? ipAddress,
    DateTime visitedAt)
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public string? Referer { get; } = referer;

    public string? UserAgent { get; } = userAgent;

    public string? IpAddress { get; } = ipAddress;

    public DateTime VisitedAt { get; } = visitedAt;
}