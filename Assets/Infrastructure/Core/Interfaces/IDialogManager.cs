using System;
using BrilliantBingo.Code.Infrastructure.Layout;

namespace BrilliantBingo.Code.Infrastructure.Core.Interfaces
{
    public interface IDialogManager
    {
        #region Methods

        void ShowSelectCardsCountDialog(Action<BingoCardsLayout> resultCallback);

        #endregion
    }
}