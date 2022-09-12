using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Models;
using BrilliantBingo.Code.Infrastructure.Views;
using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace BrilliantBingo.Code.Infrastructure.Collections
{
    public class BingoBallViewsQueue
    {
        #region Fields

        private readonly BingoBallObjectPool _bingoBallObjectPool;

        private readonly int _maxBallsInQueue;

        private readonly IDictionary<BingoLetter, Sprite> _bingoLetterToSprite
            = new Dictionary<BingoLetter, Sprite>();

        private readonly Vector3 _generatedBallAppearancePosition;

        private readonly Queue<BingoBallView> _ballsQueue;

        #endregion

        #region Internal types

        private class BingoBallObjectPool
        {
            #region Fields

            private readonly GameObject _bingoBallPrefab;

            private readonly Transform _bingoBallViewParentTransform;

            private readonly int _prefabInstancesCount;

            private readonly IList<BingoBallView> _bingoBallsPool;

            #endregion

            #region Constructors

            public BingoBallObjectPool(Transform bingoBallViewParentTransform, 
                GameObject bingoBallPrefab, int prefabInstancesCount)
            {
                _bingoBallViewParentTransform = bingoBallViewParentTransform;
                _bingoBallPrefab = bingoBallPrefab;
                _prefabInstancesCount = prefabInstancesCount;
                _bingoBallsPool = InitializePool(_bingoBallPrefab, _bingoBallViewParentTransform, _prefabInstancesCount);
            }

            #endregion

            #region Methods

            private IList<BingoBallView> InitializePool(GameObject prefab, Transform parentTransform, int instancesCount)
            {
                var list = new List<BingoBallView>();
                if (instancesCount <= 0)
                {
                    throw new Exception("Can't initialize objects pool. Instances count should be greater than zero");
                }
                for (var i=0; i < instancesCount; i++)
                {
                    var instance = (GameObject) UnityObject.Instantiate(prefab, parentTransform.position, Quaternion.identity);
                    instance.name = "BingoBallView_" + i;
                    instance.GetComponent<RectTransform>().SetParent(parentTransform);
                    instance.transform.localScale = new Vector3(1, 1, 1);
                    var view = instance.GetComponent<BingoBallView>();
                    view.Disable();
                    list.Add(view);
                }
                return list;
            }

            public BingoBallView GetBingoBallView()
            {
                foreach (var ball in _bingoBallsPool)
                {
                    if (ball.IsDisabled)
                    {
                        return ball;
                    }
                }
                return null;
            }

            #endregion
        }

        #endregion

        #region Constructors

        public BingoBallViewsQueue(Transform bingoBallViewParentTransform, GameObject bingoBallPrefab,
            int ballsCount, Vector3 generatedBallAppearancePosition)
        {
            _bingoBallObjectPool = new BingoBallObjectPool(bingoBallViewParentTransform, bingoBallPrefab, ballsCount);
            _maxBallsInQueue = ballsCount-1;
            _bingoLetterToSprite = new Dictionary<BingoLetter, Sprite>();
            _generatedBallAppearancePosition = generatedBallAppearancePosition;
            _ballsQueue = new Queue<BingoBallView>();
        }

        #endregion

        #region Methods

        public void SetBBallSprite(Sprite sprite)
        {
            SetSpriteForLetter(BingoLetter.B, sprite);
        }

        public void SetIBallSprite(Sprite sprite)
        {
            SetSpriteForLetter(BingoLetter.I, sprite);
        }

        public void SetNBallSprite(Sprite sprite)
        {
            SetSpriteForLetter(BingoLetter.N, sprite);
        }

        public void SetGBallSprite(Sprite sprite)
        {
            SetSpriteForLetter(BingoLetter.G, sprite);
        }

        public void SetOBallSprite(Sprite sprite)
        {
            SetSpriteForLetter(BingoLetter.O, sprite);
        }

        private void SetSpriteForLetter(BingoLetter letter, Sprite sprite)
        {
            if (_bingoLetterToSprite.ContainsKey(letter))
            {
                _bingoLetterToSprite[letter] = sprite;
            }
            else
            {
                _bingoLetterToSprite.Add(letter, sprite);
            }
        }

        public void Enqueue(BingoLetter letter, int number)
        {
            DequeueLastBallIfExists();
            PromoteExistingBalls();
            EnqueueNewBall(letter, number);
        }

        private void DequeueLastBallIfExists()
        {
            if (_ballsQueue.Count >= _maxBallsInQueue)
            {
                var ballForDequeue = _ballsQueue.Dequeue();
                ballForDequeue.Disappear();
            }
        }

        private void PromoteExistingBalls()
        {
            foreach (var ballView in _ballsQueue)
            {
                ballView.MoveToNextPosition();
            }
        }

        private void EnqueueNewBall(BingoLetter letter, int number)
        {
            var bb = _bingoBallObjectPool.GetBingoBallView();

            if (bb == null)
            {
                throw new Exception("there are not enough polled objects");
            }

            bb.ApplyBingoBallModel(new BingoBall(letter, number));
            bb.ApplyBallSprite(_bingoLetterToSprite[letter]);
            _ballsQueue.Enqueue(bb);
            bb.Appear(_generatedBallAppearancePosition);
        }

        #endregion
    }
}