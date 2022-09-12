using BrilliantBingo.Code.Infrastructure.Collections;
using BrilliantBingo.Code.Infrastructure.Core;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class BingoBallsTubeView : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private GameObject _bingoBallPrefab;

        [SerializeField]
        private Sprite _bBallSprite;

        [SerializeField]
        private Sprite _iBallSprite;

        [SerializeField]
        private Sprite _nBallSprite;

        [SerializeField]
        private Sprite _gBallSprite;

        [SerializeField]
        private Sprite _oBallSprite;

        [SerializeField]
        private RectTransform _bingoBallAppearancePosition;

        private BingoBallViewsQueue _bingoBallViewsQueue;

        private const int PooledBallsCount = 7;

        #endregion

        #region Methods

        public void Awake()
        {
            _bingoBallViewsQueue = new BingoBallViewsQueue(gameObject.transform, _bingoBallPrefab, PooledBallsCount,
                _bingoBallAppearancePosition.anchoredPosition);

            _bingoBallViewsQueue.SetBBallSprite(_bBallSprite);
            _bingoBallViewsQueue.SetIBallSprite(_iBallSprite);
            _bingoBallViewsQueue.SetNBallSprite(_nBallSprite);
            _bingoBallViewsQueue.SetGBallSprite(_gBallSprite);
            _bingoBallViewsQueue.SetOBallSprite(_oBallSprite);

            CoreGameObjectsLocator.Default.BingoBallsSource.BingoBallGenerated -= OnBingoBallGenerated;
            CoreGameObjectsLocator.Default.BingoBallsSource.BingoBallGenerated += OnBingoBallGenerated;
        }

        private void OnBingoBallGenerated(object sender, BingoBallGeneratedEventArgs e)
        {
            _bingoBallViewsQueue.Enqueue(e.Ball.Letter, e.Ball.Number);
        }

        #endregion
    }
}