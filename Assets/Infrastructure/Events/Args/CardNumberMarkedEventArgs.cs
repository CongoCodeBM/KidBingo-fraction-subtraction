using System;
using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure.Events.Args
{
    public class CardNumberMarkedEventArgs : EventArgs
    {
        #region Constructors

        public CardNumberMarkedEventArgs(BingoLetter numberColumnLetter, int numberVerticalIndex, int number)
        {
            NumberColumnLetter = numberColumnLetter;
            NumberVerticalIndex = numberVerticalIndex;
            Number = number;
        }

        #endregion

        #region Properties

        public BingoLetter NumberColumnLetter { get; private set; }

        public int NumberVerticalIndex { get; private set; }

        public int Number { get; private set; }

        #endregion
    }
}