namespace StorageService.Configuration;

public class StorageOptions
{
    public const string SectionName = "StorageOptions";

    public string Path { get; init; } = default!;
}