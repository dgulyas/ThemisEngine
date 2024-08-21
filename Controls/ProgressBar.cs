using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ThemisEngine.Drawing;
using ThemisEngine.Interfaces;

namespace ThemisEngine.Controls
{
    internal class ProgressBar : IPaintable, IUpdatable
    {
        /// <summary>
        /// The percentage complete. 0-100.
        /// </summary>
        public int Progress
        {
            get { return _progress; }
            set
            {
                if (value < 0) value = 0;
                if (value > 100) value = 100;
                _progress = value;
            }
        }

        private Rectangle _barRect;
        private Rectangle _outlineRect;
        private Func<int> _progressFunc;
        private int _progress;

        /// <summary>
        ///
        /// </summary>
        /// <param name="rect">The space that the progress bar should take up</param>
        /// <param name="progressFunc">A function called every update, setting Progress to it's value</param>
        public ProgressBar(Rectangle rect, Func<int> progressFunc = null)
        {
            _outlineRect = rect;
            _barRect = new Rectangle(rect.Location + new Point(1, 2), rect.Size - new Point(2, 2));
            _progressFunc = progressFunc;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawRectangle(_outlineRect, Resources.DefaultColor, 2);

            var bar = new Rectangle(_barRect.X, _barRect.Y, _barRect.Width * Progress / 100, _barRect.Height);
            var color = Progress < 100 ? Resources.DefaultColor : Color.OrangeRed;

            sb.Draw(Resources.Square, bar, color);
        }

        public void Update(GameTime gameTime, Vector2? clickLocation)
        {
            if (_progressFunc != null)
            {
                Progress = _progressFunc.Invoke();
            }
        }

    }
}
