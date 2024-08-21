using Microsoft.Xna.Framework;
using System;
using ThemisEngine.Interfaces;

namespace ThemisEngine.Controls
{
    public class Timer : IUpdatable
    {
        private double _currentElapsed;
        public double _triggerIntervalMilliseconds;

        /// <summary>
        /// If false, the timer still counts down, but the timer's effect won't happen.
        /// </summary>
        public bool Enabled = true;

        public event EventHandler Trigger;

        public Timer(double triggerIntervalMilliseconds)
        {
            _triggerIntervalMilliseconds = triggerIntervalMilliseconds;
            _currentElapsed = _triggerIntervalMilliseconds;
        }

        public void TriggerTimer()
        {
            if (!Enabled) return;

            Trigger?.Invoke(null, EventArgs.Empty);
        }

        public void Update(GameTime gameTime, Vector2? clickLocation)
        {
            _currentElapsed -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_currentElapsed < 0)
            {
                TriggerTimer();
                _currentElapsed = _triggerIntervalMilliseconds + _currentElapsed;
            }
        }
    }
}
