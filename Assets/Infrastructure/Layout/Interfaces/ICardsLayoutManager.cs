using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Layout.Interfaces
{
    public interface ICardsLayoutManager
    {
        #region Properties

        Vector2 SingleCardLayoutPosition { get; }

        Vector2 TwoCardsLayoutPosition { get; }

        Vector2 ThreeCardsLayoutPosition { get; }

        Vector2 FourCardsLayoutPosition { get; }

        #endregion

        #region Methods

        void LayoutOneCard(GameObject firstCard);

        void LayoutTwoCards(GameObject firstCard, GameObject secondCard);

        void LayoutThreeCards(GameObject firstCard, GameObject secondCard,
            GameObject thirdCard);

        void LayoutFourCards(GameObject firstCard, GameObject secondCard,
            GameObject thirdCard, GameObject fourthCard);

        #endregion
    }
}