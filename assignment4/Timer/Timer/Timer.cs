using System.Timers;

namespace AlarmClockDemo
{
    public class AlarmClock
    {
        // 定义事件委托类型
        public delegate void TickHandler(object sender, DateTime time);
        public delegate void AlarmHandler(object sender, DateTime alarmTime);

        // 声明事件
        public event TickHandler? Tick;
        public event AlarmHandler? Alarm;

        // 定时器与属性
        private readonly System.Timers.Timer _timer;
        public DateTime AlarmTime { get; set; }

        public AlarmClock()
        {
            _timer = new System.Timers.Timer(1000); // 间隔1秒触发一次
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        // 定时器触发逻辑
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            var currentTime = DateTime.Now;

            // 触发Tick事件（每秒一次）
            Tick?.Invoke(this, currentTime);

            // 检查是否到达响铃时间（精确到秒）
            if (currentTime >= AlarmTime && currentTime.Second == AlarmTime.Second)
            {
                Alarm?.Invoke(this, AlarmTime);
            }
        }
    }
}