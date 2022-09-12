using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Events.Handlers;
using BrilliantBingo.Code.Infrastructure.Generators.Interfaces;
using BrilliantBingo.Code.Infrastructure.Models;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Generators
{
    public class BingoBallsSource : MonoBehaviour, IBingoBallsSource
    {
        #region Fields

        private BingoBallGenerator _bingoBallGenerator;

        private bool _enabled;

        #endregion

        #region Methods

        public void Awake()
        {
            _bingoBallGenerator = new BingoBallGenerator();
            _enabled = true;
        }

        private void RequestNextBingoBall()
        {
            if (!_enabled) return;
            var ball = _bingoBallGenerator.GenerateRandomBingoBall();
            OnBingoBallGenerated(ball);
        }

        #endregion

        #region IBingoBallsSource

        #region Events

        public event BingoBallGeneratedEventHandler BingoBallGenerated;
        private void OnBingoBallGenerated(BingoBall ball)
        {
            var handler = BingoBallGenerated;
            if (handler == null) return;
            handler(this, new BingoBallGeneratedEventArgs(ball));
        }

        #endregion

        #region Methods

        public void Begin(float frequency)
        {
            InvokeRepeating("RequestNextBingoBall", 0.1f, frequency);
        }

        public void Stop()
        {
            _enabled = false;
            gameObject.SetActive(false);
        }

        #endregion

        #endregion
    }
}