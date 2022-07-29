using CommandsService.Models;

namespace CommandService.SyncDataClient.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}