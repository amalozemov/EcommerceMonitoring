using System;


namespace ECMonitoring.Core.Devices
{
    // A Single-Shot - одновибратор. Нет механизма защиты от одновременного воздействия нескольких потоков.

    public class SingleShot : IDisposable
    {
        public enum SingleShotStatus
        {
            Timeout,
            Continues
        }

        public delegate void
            TriggerEventHandler();

        public event TriggerEventHandler Trigger;
        public int TimeInterval { get; private set; }
        public SingleShotStatus Status
        {
            get
            {
                if (_isTimeOut == true)
                    return SingleShotStatus.Timeout;
                else
                    return SingleShotStatus.Continues;
            }
        }
        bool _isTimeOut;
        System.Timers.Timer _timer;
        bool _isResetTimer;

        public SingleShot(int time_interval_ms, bool isResetTimer = true)
        {
            TimeInterval = time_interval_ms;
            _isResetTimer = isResetTimer;
            _timer = new System.Timers.Timer(time_interval_ms);
            _timer.AutoReset = false;
            _timer.Elapsed +=
                new System.Timers.ElapsedEventHandler(_timer_Elapsed);
        }
        //
        public void Dispose()
        {
            _timer.Stop();
            _timer.Elapsed -=
                new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Close();
            _timer.Dispose();
            Trigger = null;
            _isTimeOut = false;
        }

        /// Завершение периода.
        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _isTimeOut = true;
            _timer.Enabled = false;
            if (Trigger != null)
                Trigger();
        }
        

        /// Запуск одновибратора. Перезапуск одновибратора разрешается только если не истёк период TimeInterval.
        public SingleShotStatus Start()
        {
            if (_isTimeOut == true && _isResetTimer)
                return SingleShotStatus.Timeout;

            _timer.Enabled = false;
            _timer.Start();

            return SingleShotStatus.Continues;
        }

        /// Разрешает запуск одновибратора.
        public void Set()
        {
            _isTimeOut = false;
        }

        /// Запрещает запуск одновибратора.
        public void Reset()
        {
            _isTimeOut = true;
            _timer.Stop();
            _timer.Enabled = false;
        }
        
    }
}
