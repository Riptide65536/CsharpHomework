namespace AlarmClockDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alarmClock = new AlarmClock();

            int deltaSeconds = 10;

            // 设置响铃时间（示例：当前时间+5秒）
            alarmClock.AlarmTime = DateTime.Now.AddSeconds(deltaSeconds);

            // 订阅Tick事件
            alarmClock.Tick += (sender, time) =>
            {
                Console.WriteLine($"[Tick] 当前时间：{time:HH:mm:ss}");
            };

            // 订阅Alarm事件
            alarmClock.Alarm += (sender, alarmTime) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Alarm] 闹钟已响铃！设定时间：{alarmTime:HH:mm:ss}");
                Console.ResetColor();
                Environment.Exit(0); // 结束程序
            };

            Console.WriteLine($"闹钟已启动，将在{alarmClock.AlarmTime:HH:mm:ss}响铃...");
            Console.ReadLine();
        }
    }
}
