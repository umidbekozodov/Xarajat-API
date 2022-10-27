namespace Xarajat_API.Helpers;

public static class RandomGenerator
{
    public static string GetRandomString() => Guid.NewGuid().ToString("n").Substring(0, 8);
    
}