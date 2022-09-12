using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Events.Handlers;
using BrilliantBingo.Code.Infrastructure.Layout;
using UnityEngine;
using UnityEngine.UI;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class SelectCardsCountDialogView : MonoBehaviour
    {
        #region Events

        public event CountOfCardsToPlaySelectedEventHandler CountOfCardsSeleced;
        private void OnCountOfCardsSelected(BingoCardsLayout layout)
        {
            var handler = CountOfCardsSeleced;
            if (handler == null) return;
            handler(this, new CountOfCardsToPlaySelectedEventArgs(layout));
        }

        #endregion

        #region Fields

        private const string DialogAppearanceAnimationTriggerName
            = "ShowSelectCardsCountDialogTrigger";

        [SerializeField]
        private Button _oneCardGameButton;

        [SerializeField]
        private Button _twoCardGameButton;

        [SerializeField]
        private Button _threeCardGameButton;

        [SerializeField]
        private Button _fourCardGameButton;

        private bool _initialized;

        #endregion

        #region Methods

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void DisableInput()
        {
            _oneCardGameButton.interactable = false;
            _twoCardGameButton.interactable = false;
            _threeCardGameButton.interactable = false;
            _fourCardGameButton.interactable = false;
        }

        public void EnableInput()
        {
            _oneCardGameButton.interactable = true;
            _twoCardGameButton.interactable = true;
            _threeCardGameButton.interactable = true;
            _fourCardGameButton.interactable = true;
  
        }

        public void Initialize()
        {
            if (_initialized) return;
            _oneCardGameButton.onClick.AddListener(OnOneCardGameButtonClick);
            _twoCardGameButton.onClick.AddListener(OnTwoCardGameButtonClick);
            _threeCardGameButton.onClick.AddListener(OnThreeCardGameButtonClick);
            _fourCardGameButton.onClick.AddListener(OnFourCardGameButtonClick);
            _initialized = true;
        }
        
        private void OnOneCardGameButtonClick()
        {
            OnCountOfCardsSelected(BingoCardsLayout.SingleCard);
        }

        private void OnTwoCardGameButtonClick()
        {
            OnCountOfCardsSelected(BingoCardsLayout.TwoCards);
        }

        private void OnThreeCardGameButtonClick()
        {
            OnCountOfCardsSelected(BingoCardsLayout.ThreeCards);
        }

        private void OnFourCardGameButtonClick()
        {
            OnCountOfCardsSelected(BingoCardsLayout.FourCards);
        }

        #endregion
    }
}