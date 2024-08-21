using Microsoft.Xna.Framework;

namespace ThemisEngine.StackUtil
{
    public interface IStackable
    {
        /// <summary>
        /// Returns the rectangle defining the bounds of the control
        /// </summary>
        /// <returns>The bounding rectangle</returns>
        Rectangle GetRect();

        /// <summary>
        /// Sets the X any Y coordinates of the bounding rectangle of the control
        /// </summary>
        /// <param name="location">The new X and Y for the bounding rectangle</param>
        void SetLocation(int X, int Y);
    }
}
