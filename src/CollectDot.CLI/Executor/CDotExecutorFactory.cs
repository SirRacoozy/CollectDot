using CollectDot.CLI.Interfaces;

namespace CollectDot.CLI.Executor;

public static class CDotExecutorFactory
{
    public static ICDotExecutor GetCDotExecutor()
    {
        return new CDotTestExecutor();
        
        var platform = Environment.OSVersion.Platform;

        return platform switch
        {
            PlatformID.Win32NT => new CDotWindowsExecutor(),
            PlatformID.MacOSX => new CDotUnixExecutor(),
            PlatformID.Unix => new CDotUnixExecutor(),
            _ => throw new PlatformNotSupportedException($"The platform '{platform.ToString()}' is not supported.")
        };
    }
}