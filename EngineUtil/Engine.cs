using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThemisEngine.Interfaces;

namespace ThemisEngine.EngineUtil
{
    public class Engine
    {
        private MouseState _previousMouseState;
        public GameEngineState EngineState;

        public Engine(string initialSpaceID)
        {
            EngineState = new GameEngineState
            {
                ActiveSpace = initialSpaceID
            };
        }

        public void Update(GameTime gameTime)
        {
            foreach (var space in EngineState.Spaces.Values)
            {
                if (space.ID == EngineState.ActiveSpace)
                {
                    space.Update(gameTime, GetClickLocation());
                }
                else
                {
                    space.Update(gameTime, null);
                }
            }
            if (EngineState.NextActiveSpace != null)
            {
                EngineState.ActiveSpace = EngineState.NextActiveSpace;
                EngineState.NextActiveSpace = null;
            }

        }

        private Vector2? GetClickLocation()
        {
            Vector2? clickLocation = null;

            var mouseState = Mouse.GetState();
            if (_previousMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                clickLocation = new Vector2(mouseState.X, mouseState.Y);
            }
            _previousMouseState = mouseState;
            return clickLocation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            EngineState.Spaces[EngineState.ActiveSpace].Draw(spriteBatch);
            spriteBatch.End();
        }

        public void AddSpace(ISpace space, string? ID = null)
        {
            space.Initialize(this);
            space.ID = ID ?? space.ID;
            EngineState.Spaces.Add(space.ID, space);
        }
    }
}
