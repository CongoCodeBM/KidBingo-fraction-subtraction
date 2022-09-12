using BrilliantBingo.Code.Infrastructure.Events.Handlers;
using BrilliantBingo.Code.Infrastructure.Views.Interfaces;

namespace BrilliantBingo.Code.Infrastructure.Collections.Interfaces
{
    public interface IBingoCardsCollection
    {
        #region Methods

        void AddCard(IBingoCardViewController cardView);

        void ClearCollection();

        void DisableAllCards();

        void EnableAllCards();

        #endregion

        #region Events

        event AllCardsFinishToPlayEventHandler AllCardsFinishToPlay;

        #endregion
    }
}