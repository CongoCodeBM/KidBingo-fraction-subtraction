using System;
using BrilliantBingo.Code.Infrastructure.Core.Interfaces;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Layout;
using BrilliantBingo.Code.Infrastructure.Views;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Core
{
    public class DialogManager : MonoBehaviour, IDialogManager
    {
        #region Fields

        [SerializeField]
        private GameObject _dialogSurface;

        [SerializeField]
        private SelectCardsCountDialogView _selectCardsCountDialogView;

        private Action<BingoCardsLayout> _countOfCardsSelectedCallback;

        #endregion

        #region Methods

        public void Awake()
        {
            _dialogSurface.SetActive(false);
            _selectCardsCountDialogView.Initialize();

            _selectCardsCountDialogView.CountOfCardsSeleced -= OnCountOfCardsSelected;
            _selectCardsCountDialogView.CountOfCardsSeleced += OnCountOfCardsSelected;

            _selectCardsCountDialogView.Hide();
        }

        public void ShowSelectCardsCountDialog(Action<BingoCardsLayout> resultCallback)
        {
            _countOfCardsSelectedCallback = resultCallback;
            _dialogSurface.SetActive(true);
            _selectCardsCountDialogView.Show();
        }

        private void OnCountOfCardsSelected(object sender, CountOfCardsToPlaySelectedEventArgs e)
        {
            _selectCardsCountDialogView.Hide();
            _dialogSurface.SetActive(false);
            if (_countOfCardsSelectedCallback == null) return;
            _countOfCardsSelectedCallback(e.CardsLayout);
        }

        #endregion
    }
}