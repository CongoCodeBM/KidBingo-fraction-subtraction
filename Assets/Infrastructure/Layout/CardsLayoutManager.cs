using BrilliantBingo.Code.Infrastructure.Layout.Interfaces;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Layout
{
    public class CardsLayoutManager : MonoBehaviour, ICardsLayoutManager
    {
        #region Fields

        [SerializeField]
        private RectTransform _singleCardLayout;

        [SerializeField]
        private RectTransform _twoCardsLayout;

        [SerializeField]
        private RectTransform _threeCardsLayout;

        [SerializeField]
        private RectTransform _fourCardsLayout;

        #endregion

        #region Methods

        public void Awake()
        {
            _singleCardLayout.gameObject.SetActive(false);
            _twoCardsLayout.gameObject.SetActive(false);
            _threeCardsLayout.gameObject.SetActive(false);
            _fourCardsLayout.gameObject.SetActive(false);
        }

        #endregion

        #region ICardsLayoutManager

        #region Properties

        public Vector2 SingleCardLayoutPosition
        {
            get { return _singleCardLayout.anchoredPosition; }
        }

        public Vector2 TwoCardsLayoutPosition
        {
            get { return _twoCardsLayout.anchoredPosition; }
        }

        public Vector2 ThreeCardsLayoutPosition
        {
            get { return _threeCardsLayout.anchoredPosition; }
        }

        public Vector2 FourCardsLayoutPosition
        {
            get { return _fourCardsLayout.anchoredPosition; }
        }

        #endregion

        #region Methods

        public void LayoutOneCard(GameObject firstCard)
        {
            _singleCardLayout.gameObject.SetActive(true);

            firstCard.GetComponent<RectTransform>().SetParent(_singleCardLayout, false);
            firstCard.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }

        public void LayoutTwoCards(GameObject firstCard, GameObject secondCard)
        {
            _twoCardsLayout.gameObject.SetActive(true);
            firstCard.GetComponent<RectTransform>().SetParent(_twoCardsLayout, false);
            firstCard.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            secondCard.GetComponent<RectTransform>().SetParent(_twoCardsLayout, false);
            secondCard.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }

        public void LayoutThreeCards(GameObject firstCard, GameObject secondCard, 
            GameObject thirdCard)
        {
            _threeCardsLayout.gameObject.SetActive(true);
            firstCard.GetComponent<RectTransform>().SetParent(_threeCardsLayout, false);
            firstCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            secondCard.GetComponent<RectTransform>().SetParent(_threeCardsLayout, false);
            secondCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            thirdCard.GetComponent<RectTransform>().SetParent(_threeCardsLayout, false);
            thirdCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }

        public void LayoutFourCards(GameObject firstCard, GameObject secondCard, 
            GameObject thirdCard, GameObject fourthCard)
        {
            _fourCardsLayout.gameObject.SetActive(true);
            firstCard.GetComponent<RectTransform>().SetParent(_fourCardsLayout, false);
            firstCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            secondCard.GetComponent<RectTransform>().SetParent(_fourCardsLayout, false);
            secondCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            thirdCard.GetComponent<RectTransform>().SetParent(_fourCardsLayout, false);
            thirdCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            fourthCard.GetComponent<RectTransform>().SetParent(_fourCardsLayout, false);
            fourthCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }

        #endregion

        #endregion
    }
}