using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ThemisEngine
{
    public static class Resources
    {
        public static SpriteFont Font { get; private set; }
        public static Texture2D Circle { get; private set; }
        public static Texture2D Square { get; private set; }

        public static readonly Color DefaultBackgroundColor = Color.Black;
        public static readonly Color DefaultColor = Color.Orange;

        public static readonly Vector2 ScreenSize = new Vector2(1500, 1500);
        public static readonly Vector2 ScreenCenter = ScreenSize / 2;

        public static void LoadAssets(ContentManager CM)
        {
            Font = CM.Load<SpriteFont>("Font1");
            Circle = CM.Load<Texture2D>("Circle");
            Square = CM.Load<Texture2D>("Square");
        }
    }

}
