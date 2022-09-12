using System;
using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure.Events.Args
{
    public class CardNumberUnmarkedEventArgs : EventArgs
    {
        #region Constructors

        public CardNumberUnmarkedEventArgs(BingoLetter numberColumnLetter, int numberVerticalIndex)
        {
            NumberColumnLetter = numberColumnLetter;
            NumberVerticalIndex = numberVerticalIndex;
        }

        #endregion

        #region Properties

        public BingoLetter NumberColumnLetter { get; private set; }

        public int NumberVerticalIndex { get; private set; }

        #endregion
    }
}