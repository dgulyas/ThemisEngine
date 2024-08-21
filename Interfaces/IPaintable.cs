using Microsoft.Xna.Framework.Graphics;

namespace ThemisEngine.Interfaces
{
    //Should be IDrawable, but conflicts with the XNA interface.
    public interface IPaintable
    {
        //spriteBatch.Begin() will already have been called
        //when it's passed into Draw.
        void Draw(SpriteBatch sb);
    }
}
