using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;

namespace ThemisEngine.EngineUtil
{
    public class BaseSpace : IUpdatable, IPaintable
    {
        public List<IUpdatable> Updatables = [];
        public List<IPaintable> Drawables = [];

        private readonly List<object> _toRemove = [];
        private readonly List<object> _toAdd = [];

        public virtual void Update(GameTime gameTime, Vector2? clickLocation)
        {
            UpdateControlLists();
            Updatables.ForEach(u => u.Update(gameTime, clickLocation));
            UpdateControlLists();
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Drawables.ForEach(d => d.Draw(sb));
        }

        public void AddControl(object control)
        {
            _toAdd.Add(control);
        }

        public void AddControls(List<object> controls)
        {
            _toAdd.AddRange(controls);
        }

        public void RemoveControl(object control)
        {
            _toRemove.Add(control);
        }

        public void RemoveControls(List<object> controls)
        {
            _toRemove.AddRange(controls);
        }

        private void UpdateControlLists()
        {
            foreach (var control in _toRemove)
            {
                if (control is IUpdatable)
                {
                    Updatables.Remove((IUpdatable)control);
                }

                if (control is IPaintable)
                {
                    Drawables.Remove((IPaintable)control);
                }
            }
            _toRemove.Clear();

            foreach (var control in _toAdd)
            {
                if (control is IUpdatable)
                {
                    Updatables.Add((IUpdatable)control);
                }

                if (control is IPaintable)
                {
                    Drawables.Add((IPaintable)control);
                }
            }
            _toAdd.Clear();
        }

    }
}
