using Microsoft.Extensions.Caching.Memory;

namespace MvcWebReportingSample
{
    public static class MemoryCache
    {
        public static void Configure(IMemoryCache memoryCache)
        {
            Default = memoryCache;
        }

        public static IMemoryCache Default { get; private set; }
    }
}
