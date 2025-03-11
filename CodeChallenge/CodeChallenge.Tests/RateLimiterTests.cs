namespace CodeChallenge.Tests;

public class RateLimiterTests
{
    [Fact]
    public void TryRequest_WithinLimit_ReturnsTrue()
    {
        var limiter = new RateLimiter(2, TimeSpan.FromSeconds(1));
        Assert.True(limiter.TryRequest());
        Assert.True(limiter.TryRequest());
        Assert.False(limiter.TryRequest()); // Third call exceeds limit
    }

    [Fact]
    public void TryRequest_AfterReset_ReturnsTrue()
    {
        var limiter = new RateLimiter(1, TimeSpan.FromMilliseconds(100));
        limiter.TryRequest();
        Thread.Sleep(150); // Wait for window to expire
        Assert.True(limiter.TryRequest()); // Should reset and allow
    }
}
