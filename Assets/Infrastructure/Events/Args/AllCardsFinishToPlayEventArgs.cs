using System;

namespace BrilliantBingo.Code.Infrastructure.Events.Args
{
    public class AllCardsFinishToPlayEventArgs : EventArgs
    {
        public AllCardsFinishToPlayEventArgs(int winCardsCount)
        {
            WinCardsCount = winCardsCount;
        }

        public int WinCardsCount { get; private set; }
    }
}