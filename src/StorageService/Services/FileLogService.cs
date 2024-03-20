using Microsoft.Extensions.Options;
using StorageService.Configuration;
using StorageService.Models;

namespace StorageService.Services;

public class FileLogService(
    IOptions<StorageOptions> options,
    ILogger<FileLogService> logger) : ILogService
{
    private readonly StorageOptions _options = options.Value;

    public async Task Write<T>(T entry)
        where T: IStringConvertible
    {
        try
        {
            await File.AppendAllTextAsync(_options.Path, $"{entry.ToString()}{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Failed adding new entry to file. FilePath: {_options.Path}");
        }   
    }
}