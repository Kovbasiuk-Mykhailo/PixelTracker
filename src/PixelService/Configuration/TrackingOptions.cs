using System.Net.Mime;

namespace PixelService.Configuration;

public class TrackingOptions
{
    public const string SectionName = "TrackingOptions";
    
    public string ImagePath { get; init; } = default!;

    public string ImageType { get; init; } = MediaTypeNames.Image.Gif;
}