using Microsoft.Xna.Framework;
using ThemisEngine.Drawing;
using ThemisEngine.EngineUtil;

namespace ThemisEngine.Controls
{
    //TODO: The rectangle surrounding the text/button isn't vertically aligned
    //with them. It's also a solid color, when it should be solid black with orange outline.
    public class MessageBox : BaseSpace
    {
        private static readonly int xBorder = 10;
        private static readonly int yBorder = 6;

        private readonly List<object> _controls = new List<object>();

        public MessageBox(string message)
        {
            var horCenter = (int)Resources.ScreenCenter.X;
            var text = new Text(new Vector2(), message);
            text.CenterHorizontally(horCenter);
            _controls.Add(text);

            var okButton = new Button("Ok", new Vector2(0, text.Bottom + 10));
            okButton.Click += (a, b) => RemoveControls(_controls);
            okButton.CenterHorizontally(horCenter);
            _controls.Add(okButton);

            //TODO: Make both text and buttons have the same interface for getting size.
            var maxWidth = text.TextSize.X > okButton.Rect.Width ? text.TextSize.X : okButton.Rect.Width;
            var boxWidth = (int)maxWidth + xBorder * 2;
            var boxHeight = (int)(okButton.Rect.Bottom - text.Position.Y) + 2 * yBorder;
            var boxX = horCenter - boxWidth / 2;
            var boxY = (int)Resources.ScreenCenter.Y - boxHeight / 2;

            var box = new Box(new Rectangle(boxX, boxY, boxWidth, boxHeight));
            _controls.Insert(0, box);

            AddControls(_controls);
        }

    }
}
