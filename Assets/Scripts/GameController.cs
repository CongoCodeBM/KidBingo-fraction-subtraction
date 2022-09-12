using System;
using BrilliantBingo.Code.Infrastructure.Core;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Layout;
using BrilliantBingo.Code.Infrastructure.Views;
using UnityEngine;

namespace BrilliantBingo.Code.Scripts
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        private float _ballGenerationFrequency = 3f;

        [SerializeField]
        private ReadySteadyGoView _readySteadyGoView;

        #endregion

        #region Methods

        public void Awake()
        {
            _readySteadyGoView.Hide();
            _readySteadyGoView.Go += OnGo;

            CoreGameObjectsLocator.Default.CardsCollection.AllCardsFinishToPlay -= OnAllCardsFinishToPlay;
            CoreGameObjectsLocator.Default.CardsCollection.AllCardsFinishToPlay += OnAllCardsFinishToPlay;
        }

        public void Start()
        {
            Invoke("ShowDialog", 1f);
        }

        private void ShowDialog()
        {
            CoreGameObjectsLocator.Default.DialogManager.ShowSelectCardsCountDialog(OnCountOfCardsSelected);
        }

        private void OnCountOfCardsSelected(BingoCardsLayout layout)
        {
            CoreGameObjectsLocator.Default.CardsFactory.CreateAndLayout(layout);
            CoreGameObjectsLocator.Default.CardsCollection.DisableAllCards();
            _readySteadyGoView.Show();
        }

        private void OnAllCardsFinishToPlay(object sender, AllCardsFinishToPlayEventArgs e)
        {
            Debug.Log("Game is over. Count of win cards: " + e.WinCardsCount);
            CoreGameObjectsLocator.Default.BingoBallsSource.Stop();
        }

        private void OnGo(object sender, EventArgs e)
        {
            CoreGameObjectsLocator.Default.CardsCollection.EnableAllCards();
            CoreGameObjectsLocator.Default.BingoBallsSource.Begin(_ballGenerationFrequency);
        }

        #endregion
    }
}