using Microsoft.Xna.Framework;

namespace ThemisEngine.Interfaces
{
    public interface IUpdatable
    {
        //Yes Updatable is spelled wrong, but it doesn't conflict with IUpdateable in XNA
        void Update(GameTime gameTime, Vector2? clickLocation);
    }
}
