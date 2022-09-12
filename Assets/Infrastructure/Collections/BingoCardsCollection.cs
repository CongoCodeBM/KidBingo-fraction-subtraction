using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Collections.Interfaces;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Events.Handlers;
using BrilliantBingo.Code.Infrastructure.Views.Interfaces;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Collections
{
    public class BingoCardsCollection : IBingoCardsCollection
    {
        #region Fields

        private static BingoCardsCollection _instance;

        private IList<IBingoCardViewController> _bingoCards;

        #endregion

        #region IBingoCardsCollection

        #region Methods

        public void AddCard(IBingoCardViewController cardController)
        {
            SubscribeOnCardEvents(cardController);
            _bingoCards.Add(cardController);
        }

        public void ClearCollection()
        {
            UnsubscribeFromCardsEvents();
            _bingoCards.Clear();
        }

        public void DisableAllCards()
        {
            foreach (var card in _bingoCards)
            {
                card.DisableCard();
            }
        }

        public void EnableAllCards()
        {
            foreach (var card in _bingoCards)
            {
                card.EnableCard();
            }
        }

        #endregion

        #region Events

        public event AllCardsFinishToPlayEventHandler AllCardsFinishToPlay;
        private void OnAllCardsFinishToPlay(int winCardsCount)
        {
            winCardsCount = Math.Max(0, winCardsCount);
            var handler = AllCardsFinishToPlay;
            if (handler == null) return;
            handler(this, new AllCardsFinishToPlayEventArgs(winCardsCount));
        }

        #endregion

        #endregion

        #region Constructors

        private BingoCardsCollection()
        {
            _bingoCards = new List<IBingoCardViewController>();
        }

        #endregion

        #region Properties

        public static BingoCardsCollection Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BingoCardsCollection();
                }
                return _instance;
            }
        }

        #endregion

        #region Methods

        private void SubscribeOnCardEvents(IBingoCardViewController cardController)
        {
            cardController.BadBingoStated -= OnBadBingoStated;
            cardController.BadBingoStated += OnBadBingoStated;
            cardController.WinBingoStated -= OnWinBingoStated;
            cardController.WinBingoStated += OnWinBingoStated;
        }

        private void UnsubscribeFromCardsEvents()
        {
            foreach (var card in _bingoCards)
            {
                card.BadBingoStated -= OnBadBingoStated;
                card.WinBingoStated -= OnWinBingoStated;
            }
        }

        private void OnBadBingoStated(object sender, EventArgs e)
        {
            CheckEndGame();
        }

        private void OnWinBingoStated(object sender, EventArgs e)
        {
            CheckEndGame();
        }

        private void CheckEndGame()
        {
            if (!IsAllCardsFinished()) return;
            var winCardsCount = GetWinCardsCount();
            OnAllCardsFinishToPlay(winCardsCount);
        }

        private bool IsAllCardsFinished()
        {
            var result = true;
            foreach (var card in _bingoCards)
            {
                if (!card.Finished)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private int GetWinCardsCount()
        {
            var result = 0;
            foreach (var card in _bingoCards)
            {
                if (card.Finished && card.IsWinBingo)
                {
                    result++;
                }
            }
            return result;
        }

        #endregion
    }
}