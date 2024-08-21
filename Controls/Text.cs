using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;
using ThemisEngine.StackUtil;

namespace ThemisEngine.Controls
{
    public class Text : IPaintable, IUpdatable, IStackable
    {
        //TODO: It would be great if a text could be given a point and then have one of
        // it's corners or middle of one of it's sides pinned to it.
        // So that as the text changes it stays there. Auto-centering text.

        //TODO: There should really be updatable and static text classes.
        // Then update won't be called on every text and the implementation will be cleaner.

        public string TextString = "";
        public string FormatString = "";
        public Func<string> FormatValue;

        public SpriteFont Font = Resources.Font;
        public float Scale = 1;
        public Color Color = Resources.DefaultColor;

        public Vector2 Position;
        public Vector2 TextSize => Font.MeasureString(TextString) * Scale;
        public float Right => Position.X + TextSize.X;
        public float Bottom => Position.Y + TextSize.Y;

        public Text() { }

        public Text(Vector2 pos, string tString, string fString = null, string formatValues = null)
        {
            Position = pos;
            TextString = tString;
            FormatString = fString;
            if (FormatString != null && formatValues != null)
            {
                TextString = string.Format(FormatString, formatValues);
            }
        }

        public Text(string tString, Vector2? pos = null)
        {
            TextString = tString;
            if (pos.HasValue)
            {
                Position = pos.Value;
            }
        }

        public Text(string fString, Func<string> fValue, Vector2? pos = null)
        {
            FormatString = fString;
            FormatValue = fValue;
            Update(null, null);
            if (pos.HasValue)
            {
                Position = pos.Value;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(Font, TextString, Position, Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void CenterHorizontally(int xCoord)
        {
            Position.X = xCoord - TextSize.X / 2;
        }

        public void CenterVertically(int yCoord)
        {
            Position.Y = yCoord - TextSize.Y / 2;
        }

        public void Update(GameTime gameTime, Vector2? clickLocation)
        {
            if (FormatString != null && FormatValue != null)
            {
                TextString = string.Format(FormatString, FormatValue.Invoke());
            }
        }

        public Rectangle GetRect()
        {
            return new Rectangle(Position.ToPoint(), TextSize.ToPoint());
        }

        public void SetLocation(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }
    }
}
