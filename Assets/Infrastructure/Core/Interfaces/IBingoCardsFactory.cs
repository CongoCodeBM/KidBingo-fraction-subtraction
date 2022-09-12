using BrilliantBingo.Code.Infrastructure.Layout;

namespace BrilliantBingo.Code.Infrastructure.Core.Interfaces
{
    public interface IBingoCardsFactory
    {
        #region Methods

        void CreateAndLayout(BingoCardsLayout layout);

        #endregion
    }
}