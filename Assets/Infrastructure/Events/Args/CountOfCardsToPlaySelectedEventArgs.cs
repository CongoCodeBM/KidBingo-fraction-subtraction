using System;
using BrilliantBingo.Code.Infrastructure.Layout;

namespace BrilliantBingo.Code.Infrastructure.Events.Args
{
    public class CountOfCardsToPlaySelectedEventArgs : EventArgs
    {
        public CountOfCardsToPlaySelectedEventArgs(BingoCardsLayout cardsLayout)
        {
            CardsLayout = cardsLayout;
        }

        public BingoCardsLayout CardsLayout { get; private set; }
    }
}