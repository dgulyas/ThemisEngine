using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThemisEngine.Interfaces;

namespace ThemisEngine.Controls
{
    public class NumberPicker : IUpdatable, IPaintable
    {
        public int? MaxNumber;
        public int? MinNumber;
        public int Number;

        private Vector2 _position;

        private List<Button> _buttons = [];
        private Text _currNumberText;

        public NumberPicker(
            Vector2 position,
            int startingNumber,
            int[] buttonValues,
            string formatString = null,
            int? minNumber = null,
            int? maxNumber = null)
        {
            _position = position;

            Number = startingNumber;
            MaxNumber = maxNumber;
            MinNumber = minNumber;

            formatString = formatString == null ? "{0}" : formatString;
            _currNumberText = new Text(formatString, () => Number.ToString(), _position);

            _buttons = new List<Button>();

            var p = new Vector2(_currNumberText.Position.X, _currNumberText.Bottom + 20);
            foreach (int buttonValue in buttonValues)
            {
                var rect = AddPriceChangeButton(buttonValue, p);
                p = new Vector2(rect.Right + 20, rect.Y);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            _currNumberText.Draw(sb);
            _buttons.ForEach(b => b.Draw(sb));
        }

        public void Update(GameTime gameTime, Vector2? clickLocation)
        {
            _buttons.ForEach(b => b.Update(null, clickLocation));
            _currNumberText.Update(null, null);
        }

        private Rectangle AddPriceChangeButton(int amount, Vector2 position)
        {
            var text = amount.ToString();
            if (amount > 0)
            {
                text.Prepend('+');
            }
            var b = new Button(text, position);
            b.Click += (sender, args) => ChangeNumber(amount);
            _buttons.Add(b);
            return b.Rect;
        }

        private void ChangeNumber(int diff)
        {
            var newNumber = Number + diff;

            if (MaxNumber.HasValue && newNumber > MaxNumber.Value)
            {
                return;
            }
            if (MinNumber.HasValue && newNumber < MinNumber.Value)
            {
                return;
            }

            Number += diff;
        }

    }
}
