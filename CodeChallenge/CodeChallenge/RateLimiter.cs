public class RateLimiter {
    // Thread safe requests limiter
    private readonly object _lock = new object();
    private readonly int _maxRequests;
    private int _currentRequests;
    private DateTime _resetTime;
    private TimeSpan _step;

    public RateLimiter(int maxRequests, TimeSpan timeSpan) {
        _maxRequests = maxRequests;
        _currentRequests = 0;
        _step = timeSpan;
        _resetTime = DateTime.UtcNow.Add(timeSpan);
    }

    public bool TryRequest() {
        lock (_lock) {
            if (DateTime.UtcNow >= _resetTime) {
                _currentRequests = 0;
                _resetTime = DateTime.UtcNow.Add(_step);
            }

            if (_currentRequests < _maxRequests) {
                _currentRequests++;
                return true;
            }

            return false;
        }
    }
}