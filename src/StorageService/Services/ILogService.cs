using StorageService.Models;

namespace StorageService.Services;

public interface ILogService
{
    Task Write<T>(T entry) where T: IStringConvertible;
}