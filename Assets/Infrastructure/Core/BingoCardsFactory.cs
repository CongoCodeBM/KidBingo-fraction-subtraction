using BrilliantBingo.Code.Infrastructure.Core.Interfaces;
using BrilliantBingo.Code.Infrastructure.Layout;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Core
{
    public class BingoCardsFactory : MonoBehaviour, IBingoCardsFactory
    {
        #region Fields

        [SerializeField]
        private GameObject _bingoCardPrefab;

        #endregion

        #region Methods

        private GameObject InstantiateCard(Vector3 position)
        {
            return (GameObject)Instantiate(_bingoCardPrefab, position, Quaternion.identity);
        }

        private void CreateAndLayoutOne()
        {
            var card = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.SingleCardLayoutPosition);

            CoreGameObjectsLocator.Default.CardsLayoutManager.LayoutOneCard(card);
        }

        private void CreateAndLayoutTwo()
        {
            var first = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.TwoCardsLayoutPosition);
            var second = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.TwoCardsLayoutPosition);
            CoreGameObjectsLocator.Default.CardsLayoutManager.LayoutTwoCards(first, second);
        }

        private void CreateAndLayoutThree()
        {
            var first = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.ThreeCardsLayoutPosition);
            var second = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.ThreeCardsLayoutPosition);
            var third = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.ThreeCardsLayoutPosition);
            CoreGameObjectsLocator.Default.CardsLayoutManager.LayoutThreeCards(first, second, third);
        }

        private void CreateAndLayoutFour()
        {
            var first = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.FourCardsLayoutPosition);
            var second = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.FourCardsLayoutPosition);
            var third = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.FourCardsLayoutPosition);
            var fourth = InstantiateCard(CoreGameObjectsLocator.Default.CardsLayoutManager.FourCardsLayoutPosition);
            CoreGameObjectsLocator.Default.CardsLayoutManager.LayoutFourCards(first, second, third, fourth);
        }

        #endregion

        #region IBingoCardsFactory

        #region Methods

        public void CreateAndLayout(BingoCardsLayout layout)
        {
            switch (layout)
            {
                case BingoCardsLayout.SingleCard:
                    CreateAndLayoutOne();
                    break;
                case BingoCardsLayout.TwoCards:
                    CreateAndLayoutTwo();
                    break;
                case BingoCardsLayout.ThreeCards:
                    CreateAndLayoutThree();
                    break;
                case BingoCardsLayout.FourCards:
                    CreateAndLayoutFour();
                    break;
            }
        }

        #endregion

        #endregion
    }
}