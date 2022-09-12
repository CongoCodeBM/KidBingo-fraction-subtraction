using BrilliantBingo.Code.Infrastructure.Collections;
using BrilliantBingo.Code.Infrastructure.Collections.Interfaces;
using BrilliantBingo.Code.Infrastructure.Core.Interfaces;
using BrilliantBingo.Code.Infrastructure.Generators;
using BrilliantBingo.Code.Infrastructure.Generators.Interfaces;
using BrilliantBingo.Code.Infrastructure.Layout;
using BrilliantBingo.Code.Infrastructure.Layout.Interfaces;
using UnityEngine;

namespace BrilliantBingo.Code.Infrastructure.Core
{
    public class CoreGameObjectsLocator
    {
        #region Fields

        private static CoreGameObjectsLocator _instance;

        private BingoBallsSource _bingoBallsSource;

        private CardsLayoutManager _cardsLayoutManager;

        private BingoCardsFactory _cardsFactory;

        private DialogManager _dialogManager;

        private GeneratedNumbersManager _generatedNumbersManager;

        #endregion

        #region Properties

        public static CoreGameObjectsLocator Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoreGameObjectsLocator();
                }
                return _instance;
            }
        }

        public IBingoBallsSource BingoBallsSource
        {
            get { return LocateCoreGameObject(Tags.BingoBallsSourceTag, ref _bingoBallsSource); }
        }

        public IBingoCardsCollection CardsCollection
        {
            get { return BingoCardsCollection.Default; }
        }

        public ICardsLayoutManager CardsLayoutManager
        {
            get { return LocateCoreGameObject(Tags.CardsLayoutManagerTag, ref _cardsLayoutManager); }
        }

        public IBingoCardsFactory CardsFactory
        {
            get { return LocateCoreGameObject(Tags.BingoCardsFactoryTag, ref _cardsFactory); }
        }

        public IDialogManager DialogManager
        {
            get { return LocateCoreGameObject(Tags.DialogManagerTag, ref _dialogManager); }
        }

        public IGeneratedNumbersManager GeneratedNumbersManager
        {
            get { return LocateCoreGameObject(Tags.GeneratedNumberManagerTag, ref _generatedNumbersManager); }
        }

        #endregion

        #region Methods

        private T LocateCoreGameObject<T>(string tag, ref T instanceHolder)
            where T : Component
        {
            if (instanceHolder != null)
            {
                return instanceHolder;
            }
            var go = GameObject.FindGameObjectWithTag(tag);
            if (go == null)
            {
                instanceHolder = null;
                return null;
            }
            instanceHolder = go.GetComponent<T>();
            return instanceHolder;
        }

        #endregion
    }
}