using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;

namespace ThemisEngine.Drawing
{
    public class Paintable : IPaintable
    {
        public Action<SpriteBatch> DrawAction;

        public Paintable(Action<SpriteBatch> drawAction)
        {
            DrawAction = drawAction;
        }

        public void Draw(SpriteBatch sb)
        {
            DrawAction(sb);
        }
    }
}
