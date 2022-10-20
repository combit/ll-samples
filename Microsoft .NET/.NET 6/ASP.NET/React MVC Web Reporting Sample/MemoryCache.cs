using Microsoft.Extensions.Caching.Memory;

namespace ReactMVCWebReportingSample
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
