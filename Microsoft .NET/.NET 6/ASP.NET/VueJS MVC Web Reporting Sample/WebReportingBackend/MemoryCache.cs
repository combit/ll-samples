using Microsoft.Extensions.Caching.Memory;

namespace VueJsMvcWebReportingSample
{
    public class MemoryCache
    {
        public static void Configure(IMemoryCache memoryCache)
        {
            Default = memoryCache;
        }

        public static IMemoryCache Default { get; private set; }
    }
}
