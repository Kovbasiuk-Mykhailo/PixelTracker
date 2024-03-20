using System.Globalization;

namespace StorageService.Models;

public class Visit(
    string? referer,
    string? userAgent,
    string? ipAddress,
    DateTime visitedAt) : IStringConvertible
{
    public string? Referer { get; } = referer;

    public string? UserAgent { get; } = userAgent;

    public string? IpAddress { get; } = ipAddress;

    public DateTime VisitedAt { get; } = visitedAt;
    
    
    public override string ToString()
    {
        return string.Join('|', VisitedAt.ToString("o", CultureInfo.InvariantCulture), Referer ?? "null", UserAgent ?? "null", IpAddress ?? "null");
    }
}