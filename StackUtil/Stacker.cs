using Microsoft.Xna.Framework;

namespace ThemisEngine.StackUtil
{
    public static class Stacker
    {
        /// <summary>
        /// Starting at the location of A, go margin distance in the dir direction and positon B,
        /// shifting it orthogonally according to relative.
        /// </summary>
        /// <param name="A">The already positioned control</param>
        /// <param name="dir">The direction the new control B should be placed in relation to A</param>
        /// <param name="B">The new control to position</param>
        /// <param name="relative">0 - 1.0 inclusive. Look at this function's code for diagram.</param>
        /// relative = 0
        /// AAAAAAA           or   A
        /// B                      BBBBB
        ///
        /// relative = 0.5
        /// AAAAAAA           or     A
        ///    B                   BBBBB
        ///
        /// relative = 1
        /// AAAAAAA           or       A
        ///       B                BBBBB
        public static void Stack(this IStackable B, IStackable A, StackDir dir, float relative, int margin)
        {
            if (relative < 0 || relative > 1)
            {
                throw new Exception($"Relative is outside 0-1: {relative}");
            }

            var aRect = A.GetRect();
            var bRect = B.GetRect();

            if (dir == StackDir.goDown)
            {
                var newY = aRect.Bottom + margin;
                var newX = aRect.X + relative * aRect.Width - relative * bRect.Width;
                B.SetLocation((int)newX, newY);
            }
            else if (dir == StackDir.goUp)
            {
                var newY = aRect.Top + margin + bRect.Height;
                var newX = aRect.X + relative * aRect.Width - relative * bRect.Width;
                B.SetLocation((int)newX, newY);
            }
            else if (dir == StackDir.goRight)
            {
                var newX = aRect.Right + margin;
                var newY = aRect.Y + relative * aRect.Height - relative * bRect.Height;
                B.SetLocation(newX, (int)newY);
            }
            else if (dir == StackDir.goLeft)
            {
                var newX = aRect.Left + margin + bRect.Width;
                var newY = aRect.Y + relative * aRect.Height - relative * bRect.Height;
                B.SetLocation(newX, (int)newY);
            }
        }

        /// <summary>
        /// Sets the control at a new position in relation to a point.
        /// Using 0.5 for both relation args will position the control
        /// so that it's center is on the point. Using 0 will put the
        /// control's top left corner on the point.
        /// </summary>
        /// <param name="B">The control to move</param>
        /// <param name="point">The point</param>
        /// <param name="xRelative">How far along the width the point should be</param>
        /// <param name="yRelation">How far along the height the point should be</param>
        public static void StackInteriorPointRelative(this IStackable B, Vector2 point, float xRelative, float yRelation)
        {
            var rect = B.GetRect();
            var newX = point.X - xRelative * rect.Width;
            var newY = point.Y - yRelation * rect.Height;
            B.SetLocation((int)newX, (int)newY);
        }

        //public static void StackExteriorPoint(this IStackable B, Vector2 p, int? xMargin, int? yMargin, float? xRelative, float? yRelative)
        //{
        //    if(xMargin.HasValue && xRelative.HasValue)
        //    {
        //        throw new System.Exception("Can't define both margin and relative for x.");
        //    }
        //    if (yMargin.HasValue && yRelative.HasValue)
        //    {
        //        throw new System.Exception("Can't define both margin and relative for y.");
        //    }

        //    var rect = B.GetRect();
        //    var newX = rect.X;
        //    if (xMargin.HasValue)
        //    {
        //        newX =
        //    }
        //}

        /// <summary>
        /// Move B such that p is the specified distance away from each specified side.
        /// </summary>
        /// <param name="B">The control to move</param>
        /// <param name="p">The point</param>
        /// <param name="left">How far the point should be to the left of B. Can't be used with right.</param>
        /// <param name="right">How far the point should be to the right of B. Can't be used with left.</param>
        /// <param name="top">How far the point should be above the top of B. Can't be used with bottom.</param>
        /// <param name="bottom">How far the point should be below the bottom of B. Can't be used with top.</param>
        public static void StackPointInt(this IStackable B, Vector2 p, int? left = null, int? right = null, int? top = null, int? bottom = null)
        {
            if (left.HasValue && right.HasValue)
            {
                throw new Exception("Can't use both left and right arguments");
            }
            if (top.HasValue && bottom.HasValue)
            {
                throw new Exception("Can't use both left and right arguments");
            }

            var rect = B.GetRect();
            var newX = rect.X;
            var newY = rect.Y;

            if (left.HasValue)
            {
                newX = (int)p.X + left.Value;
            }
            else if (right.HasValue)
            {
                newX = (int)p.X - (right.Value + rect.Width);
            }

            if (top.HasValue)
            {
                newY = (int)p.Y + top.Value;
            }
            else if (bottom.HasValue)
            {
                newY = (int)p.Y - (bottom.Value + rect.Height);
            }

            B.SetLocation(newX, newY);
        }

    }
}
