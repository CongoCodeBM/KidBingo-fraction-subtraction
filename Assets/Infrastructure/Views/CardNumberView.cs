using System;
using System.Globalization;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Events.Handlers;
using BrilliantBingo.Code.Infrastructure.Models;
using UnityEngine;
using UnityEngine.UI;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class CardNumberView : MonoBehaviour
    {
        #region Events

        public event CardNumberMarkedEventHandler Marked;
        private void OnMarked()
        {
            var handler = Marked;
            if (handler == null) return;
            handler(this, new CardNumberMarkedEventArgs(_columnLetter, _verticalIndex, _number));
        }

        public event CardNumberUnmarkedEventHandler Unmarked;
        private void OnUnmarked()
        {
            var handler = Unmarked;
            if (handler == null) return;
            handler(this, new CardNumberUnmarkedEventArgs(_columnLetter, _verticalIndex));
        }

        #endregion

        #region Fields

        private BingoLetter _columnLetter;

        private int _verticalIndex;

        private int _number;

        private bool _initialized;

        private Text _text;

        private Color _defaultTextColot;

        private Color _highlightedTextColor;

        private Button _button;

        private bool _marked;

        private Color _normalColor;

        #endregion

        #region Methods

        public void Initialize(BingoLetter columnLetter, int verticalIndex, int number)
        {
            if (_initialized)
            {
                throw new InvalidOperationException("CardNumberView already initialzied");
            }
            _columnLetter = columnLetter;
            _verticalIndex = verticalIndex;
            _number = number;


            _defaultTextColot = GetText().color;
            _highlightedTextColor = Color.white;
            _normalColor = GetButton().colors.normalColor;
            GetButton().onClick.AddListener(Clicked);
            GetText().text = _number.ToString(CultureInfo.InvariantCulture);

            _initialized = true;
        }

        private void Clicked()
        {
            if (_marked)
            {
                Unmark();
            }
            else
            {
                Mark();
            }
        }

        private void Mark()
        {
            var c = _button.colors;
            c.normalColor = c.pressedColor;
            c.highlightedColor = c.pressedColor;
            _button.colors = c;
            _text.color = _highlightedTextColor;
            _marked = true;
            OnMarked();
        }

        private void Unmark()
        {
            var c = _button.colors;
            c.normalColor = _normalColor;
            c.highlightedColor = _normalColor;
            _button.colors = c;
            _text.color = _defaultTextColot;
            _marked = false;
            OnUnmarked();
        }

        public void EnableInput()
        {
            _button.interactable = true;
        }

        public void DisableInput()
        {
            _button.interactable = false;
        }

        private Text GetText()
        {
            if (_text == null)
            {
                _text = GetComponentInChildren<Text>();
            }
            return _text;
        }

        private Button GetButton()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            return _button;
        }

        #endregion
    }
}