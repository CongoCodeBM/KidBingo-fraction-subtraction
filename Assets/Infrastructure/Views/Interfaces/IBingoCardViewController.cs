using System;

namespace BrilliantBingo.Code.Infrastructure.Views.Interfaces
{
    public interface IBingoCardViewController
    {
        #region Events

        event EventHandler BadBingoStated;

        event EventHandler WinBingoStated;

        #endregion

        #region Properties

        bool Finished { get; }

        bool IsWinBingo { get; }

        #endregion

        #region Methods

        void DisableCard();

        void EnableCard();

        #endregion
    }
}