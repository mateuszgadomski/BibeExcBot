using Timer = System.Threading.Timer;

namespace VibeExcBot.Utilities
{
    public static class TimerUtility
    {
        private static Timer? _timer;

        public static void StartTimer(TimerCallback callback, object state, TimeSpan delaySeconds, TimeSpan intervalSeconds)
        {
            var dueTimeMilliseconds = (int)delaySeconds.TotalMilliseconds;
            var periodMilliseconds = (int)intervalSeconds.TotalMilliseconds;

            _timer = new Timer(callback, state, dueTimeMilliseconds, periodMilliseconds);
        }

        public static void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                _timer.Dispose();
                _timer = null;
            }
        }

        public static bool IsTimerState(bool isRunning)
        {
            return isRunning ? _timer != null : _timer == null;
        }
    }
}
