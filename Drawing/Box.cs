using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;

namespace ThemisEngine.Drawing
{
    internal class Box : IPaintable
    {
        private Rectangle _rect;

        public Box(Vector2 size)
        {
            _rect = new Rectangle(0, 0, (int)size.X, (int)size.Y);
        }

        public Box(Rectangle rect)
        {
            _rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Resources.Square, _rect, Resources.DefaultColor);
        }

        public void SetOffset(Vector2 anchor, float xOffset, float yOffset)
        {
            _rect.X = (int)(anchor.X - _rect.Width * xOffset);
            _rect.Y = (int)(anchor.Y - _rect.Height * yOffset);
        }
    }
}
