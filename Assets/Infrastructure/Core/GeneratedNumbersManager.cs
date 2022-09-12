using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Core.Interfaces;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Views;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Core
{
    public class GeneratedNumbersManager : MonoBehaviour, IGeneratedNumbersManager
    {
        #region Fields

        [SerializeField]
        private RectTransform _bColumn;

        [SerializeField]
        private RectTransform _iColumn;

        [SerializeField]
        private RectTransform _nColumn;

        [SerializeField]
        private RectTransform _gColumn;

        [SerializeField]
        private RectTransform _oColumn;

        [SerializeField]
        private GameObject _generatedNumberPrefab;

        private IList<GeneratedNumberView> _generatedNumbers;

        #endregion

        #region IGeneratedNumbersManager

        #region Methods

        public bool CheckIfNumberWasGenerated(int number)
        {
            return _generatedNumbers[number-1].Generated;
        }

        #endregion

        #endregion

        #region Methods

        public void Awake()
        {
            _generatedNumbers = new List<GeneratedNumberView>();
            GenerateNumbers();
            CoreGameObjectsLocator.Default.BingoBallsSource.BingoBallGenerated -= OnBingoBallGenerated;
            CoreGameObjectsLocator.Default.BingoBallsSource.BingoBallGenerated += OnBingoBallGenerated;
        }

        private void GenerateNumbers()
        {
            for (var i = 1; i <= 75; i++)
            {
                var parent = GetTransformForNumber(i);
                if (parent == null)
                {
                    throw new Exception("Can't get parent for number: " + i);
                }
                var numberView = InstantiateNumber(parent);
                numberView.SetNumber(i);
                numberView.Disable();
                _generatedNumbers.Add(numberView);
            }
        }

        private GeneratedNumberView InstantiateNumber(RectTransform parent)
        {
            var go = (GameObject)Instantiate(_generatedNumberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.GetComponent<RectTransform>().SetParent(parent);
            go.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            return go.GetComponent<GeneratedNumberView>();
        }

        private RectTransform GetTransformForNumber(int number)
        {
            if (number >= 1 && (number <= 15))
            {
                return _bColumn;
            }
            if (number >= 16 && (number <= 30))
            {
                return _iColumn;
            }
            if (number >= 31 && (number <= 45))
            {
                return _nColumn;
            }
            if (number >= 46 && (number <= 60))
            {
                return _gColumn;
            }
            if (number >= 61 && (number <= 75))
            {
                return _oColumn;
            }
            return null;
        }

        private void OnBingoBallGenerated(object sender, BingoBallGeneratedEventArgs e)
        {
            var numberView = _generatedNumbers[e.Ball.Number-1];
            numberView.MarkAsGenerated();
        }

        #endregion
    }
}