using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace Tion.MagicAirTester.Tester
{
    public sealed class AppTimer : IDisposable
    {
        private bool _forever;
        private Timer _timer;
        private bool _isInitialized;

        /// <summary>
        /// Timer
        /// </summary>
        public void Initialize(int interval, bool forever = false)
        {
            _forever = forever;
            _timer = new Timer { Interval = interval };
            if (!_isInitialized)
            {
                _timer.Tick += OnTimer;
                _isInitialized = true;
            }
        }

        public event EventHandler TimerComplete;

        private void OnTimer(object sender, EventArgs e)
        {
            OnTimerComplete();
            if (_forever)
                _timer.Start();
            else
            {
                _timer.Stop();
                _isInitialized = false;
                _timer.Tick -= OnTimer;
            }
        }

        /// <summary>
        /// Start timer
        /// </summary>
        public void Start()
        {
            _timer?.Start();
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        public void Stop()
        {
            _timer?.Stop();
        }

        private void OnTimerComplete()
        {
            TimerComplete?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
