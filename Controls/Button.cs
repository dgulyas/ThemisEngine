using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;
using ThemisEngine.StackUtil;

namespace ThemisEngine.Controls
{
    public class Button : IPaintable, IUpdatable, IStackable
    {
        //The size of the button is set in the constructor based on the text size.
        //If the text is changed to be bigger the button won't grow.

        public Texture2D Texture;

        public Rectangle Rect;
        public Color Color;
        public bool Visible = true;

        public event EventHandler Click;

        private static readonly int textXOffset = 10;
        private static readonly int textYOffset = 6;

        private readonly Text _text;

        public Button(string text, Vector2 location = default, Texture2D texture = default, SpriteFont font = default, Color buttonColor = default, Color txtColor = default)
        {
            Texture = texture == default ? Resources.Square : texture;
            Color = buttonColor == default ? Resources.DefaultColor : buttonColor;
            location = location == default ? Vector2.One : location;

            if (text != null)
            {
                _text = new Text
                {
                    Font = font == default ? Resources.Font : font,
                    Color = txtColor == default ? Resources.DefaultBackgroundColor : buttonColor,
                    TextString = text,
                    Position = GetTextLocation(location),
                };
                var tSize = _text.TextSize;
                Rect = new Rectangle((int)location.X, (int)location.Y, (int)tSize.X + 2 * textXOffset, (int)tSize.Y + 2 * textYOffset);
            }
        }

        public void Update(GameTime gameTime, Vector2? clickLocation)
        {
            if (Visible && clickLocation.HasValue && ContainsPoint(clickLocation.Value))
            {
                Click?.Invoke(null, EventArgs.Empty);
            }
        }

        public bool ContainsPoint(Vector2 point)
        {
            return Visible && Rect.Contains(point);
        }

        public void Draw(SpriteBatch sb)
        {
            if (!Visible) return;

            sb.Draw(Texture, Rect, Color);
            _text?.Draw(sb);
        }

        public void SetLocation(int X, int Y)
        {
            Rect.X = X;
            Rect.Y = Y;
            if (_text != null)
            {
                _text.Position = GetTextLocation(Rect.Location.ToVector2());
            }
        }

        public void CenterHorizontally(int xCoord)
        {
            SetLocation(xCoord - Rect.Width / 2, Rect.Y);
        }

        public void CenterVertically(int yCoord)
        {
            SetLocation(Rect.X, yCoord - Rect.Height / 2);
        }

        public string TextString
        {
            get { return _text.TextString; }
            set { _text.TextString = value; }
        }

        private static Vector2 GetTextLocation(Vector2 buttonLocation)
        {
            return new Vector2(buttonLocation.X + textXOffset, buttonLocation.Y + textYOffset);
        }

        public Rectangle GetRect()
        {
            return Rect;
        }

    }
}
