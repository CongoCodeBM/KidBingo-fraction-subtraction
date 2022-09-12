using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Core;
using BrilliantBingo.Code.Infrastructure.Events.Args;
using BrilliantBingo.Code.Infrastructure.Generators;
using BrilliantBingo.Code.Infrastructure.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace BrilliantBingo.Code.Infrastructure.Views
{
    public class BingoCardView : MonoBehaviour, IBingoCardViewController
    {
        #region Fields

        [SerializeField]
        private GameObject _numbersPanel;

        [SerializeField]
        private GameObject _badBingoPanel;

        [SerializeField]
        private GameObject _winBingoPanel;

        [SerializeField]
        private Button _bingoButton;

        [SerializeField]
        private AudioSource _badBingoAudioSource;

        [SerializeField]
        private AudioSource _winBingoAudioSource;

        #region Column_1

        [SerializeField]
        private CardNumberView _cardNumberView_11;

        [SerializeField]
        private CardNumberView _cardNumberView_21;

        [SerializeField]
        private CardNumberView _cardNumberView_31;

        [SerializeField]
        private CardNumberView _cardNumberView_41;

        [SerializeField]
        private CardNumberView _cardNumberView_51;

        #endregion

        #region Column_2

        [SerializeField]
        private CardNumberView _cardNumberView_12;

        [SerializeField]
        private CardNumberView _cardNumberView_22;

        [SerializeField]
        private CardNumberView _cardNumberView_32;

        [SerializeField]
        private CardNumberView _cardNumberView_42;

        [SerializeField]
        private CardNumberView _cardNumberView_52;

        #endregion

        #region Column_3

        [SerializeField]
        private CardNumberView _cardNumberView_13;

        [SerializeField]
        private CardNumberView _cardNumberView_23;

        [SerializeField]
        private CardNumberView _cardNumberView_33;

        [SerializeField]
        private CardNumberView _cardNumberView_43;

        [SerializeField]
        private CardNumberView _cardNumberView_53;

        #endregion

        #region Column_4

        [SerializeField]
        private CardNumberView _cardNumberView_14;

        [SerializeField]
        private CardNumberView _cardNumberView_24;

        [SerializeField]
        private CardNumberView _cardNumberView_34;

        [SerializeField]
        private CardNumberView _cardNumberView_44;

        [SerializeField]
        private CardNumberView _cardNumberView_54;

        #endregion

        #region Column_5

        [SerializeField]
        private CardNumberView _cardNumberView_15;

        [SerializeField]
        private CardNumberView _cardNumberView_25;

        [SerializeField]
        private CardNumberView _cardNumberView_35;

        [SerializeField]
        private CardNumberView _cardNumberView_45;

        [SerializeField]
        private CardNumberView _cardNumberView_55;

        #endregion

        private const int UnmarkedNumber = -1;

        private const int RowsCount = 5;

        private const int ColumnsCount = 5;

        private int[,] _markedNumbersMap;

        private CardNumberView[,] _cardNumberViewsMap;

        private int[,] _numbersOnCard;

        #endregion

        #region Methods

        public void Awake()
        {
            Finished = false;
            _winBingoPanel.SetActive(false);
            _badBingoPanel.SetActive(false);

            _bingoButton.onClick.AddListener(OnBingoButtonPressed);

            _markedNumbersMap = new [,]
            {
                {UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber},
                {UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber},
                {UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber},
                {UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber},
                {UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber, UnmarkedNumber},
            };

            _cardNumberViewsMap = new[,]
            {
                {_cardNumberView_11, _cardNumberView_12, _cardNumberView_13, _cardNumberView_14, _cardNumberView_15},
                {_cardNumberView_21, _cardNumberView_22, _cardNumberView_23, _cardNumberView_24, _cardNumberView_25},
                {_cardNumberView_31, _cardNumberView_32, _cardNumberView_33, _cardNumberView_34, _cardNumberView_35},
                {_cardNumberView_41, _cardNumberView_42, _cardNumberView_43, _cardNumberView_44, _cardNumberView_45},
                {_cardNumberView_51, _cardNumberView_52, _cardNumberView_53, _cardNumberView_54, _cardNumberView_55},
            };

            _numbersOnCard = RetrieveRandomNumbersForCard();
            InitializeCardNumbersMap();

            CoreGameObjectsLocator.Default.CardsCollection.AddCard(this);
        }

        public void DisableCardNumbersInput()
        {
            ForEachNumber(cardNumberView => cardNumberView.DisableInput());
        }

        public void EnableCardNumbersInput()
        {
            ForEachNumber(cardNumberView => cardNumberView.EnableInput());
        }

        private int[,] RetrieveRandomNumbersForCard()
        {
            var cng = new BingoCardNumbersGenerator();
            return cng.GenerateRandomBingoCardNumbers();
        }

        private void InitializeCardNumbersMap()
        {
            for (var rowIndex = 0; rowIndex < RowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
                {
                    var cardNumberView = _cardNumberViewsMap[rowIndex, columnIndex];

                    var letter = BingoLetterCaster.IntToBingoLetter(columnIndex);
                    var number = _numbersOnCard[rowIndex, columnIndex];

                    cardNumberView.Initialize(letter, rowIndex, number);

                    cardNumberView.Marked += OnNumberMarked;
                    cardNumberView.Unmarked += OnNumberUnmarked;
                }
            }
        }

        private void OnNumberMarked(object sender, CardNumberMarkedEventArgs e)
        {
            var rowIndex = e.NumberVerticalIndex;
            var columnIndex = BingoLetterCaster.BingoLetterToInt(e.NumberColumnLetter);
            _markedNumbersMap[rowIndex, columnIndex] = e.Number;
        }

        private void OnNumberUnmarked(object sender, CardNumberUnmarkedEventArgs e)
        {
            var rowIndex = e.NumberVerticalIndex;
            var columnIndex = BingoLetterCaster.BingoLetterToInt(e.NumberColumnLetter);
            _markedNumbersMap[rowIndex, columnIndex] = UnmarkedNumber;
        }

        private void ForEachNumber(Action<CardNumberView> actor)
        {
            for (var rowIndex = 0; rowIndex < RowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
                {
                    var cardNumberView = _cardNumberViewsMap[rowIndex, columnIndex];
                    actor(cardNumberView);
                }
            }
        }

        private void OnBingoButtonPressed()
        {
            Finished = true;
            DisableCard();
            var bingo = CheckForBingo();
            IsWinBingo = bingo;
            if (bingo)
            {
                TurnToCardWinBingoView();
                PlayWinBingoSound();
                OnWinBingoStated();
            }
            else
            {
                TurnToCardBadBingoView();
                PlayBadBingoSound();
                OnBadBingoStated();
            }
        }

        private void PlayBadBingoSound()
        {
            _badBingoAudioSource.Play();
        }

        private void PlayWinBingoSound()
        {
            _winBingoAudioSource.Play();
        }

        private void TurnToCardBadBingoView()
        {
            _numbersPanel.SetActive(false);
            _winBingoPanel.SetActive(false);
            _badBingoPanel.SetActive(true);
        }

        private void TurnToCardWinBingoView()
        {
            _numbersPanel.SetActive(false);
            _winBingoPanel.SetActive(true);
            _badBingoPanel.SetActive(false);
        }

        private bool CheckForBingo()
        {
            var fullMarkedLines = new List<int[]>();
            // Check rows
            for (var rowIndex = 0; rowIndex < RowsCount; rowIndex++)
            {
                if (IsLineMarkedInRow(rowIndex))
                {
                    fullMarkedLines.Add(GetLineFromRow(rowIndex));
                }
            }
            // Check columns
            for (var columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
            {
                if (IsLineMarkedInColumn(columnIndex))
                {
                    fullMarkedLines.Add(GetLineFromColumn(columnIndex));
                }
            }

            // Check diagonals
            if (IsUpLeftToDownRightDiagonalMarked())
            {
                fullMarkedLines.Add(GetUpLeftToDownRightDiagonal());
            }
            if (IsUpRightToDownLeftDiagonalMarked())
            {
                fullMarkedLines.Add(GetUpRightToDownLeftDiagonal());
            }

            // Check corners
            if (IsCornerNumbersMarked())
            {
                fullMarkedLines.Add(GetCornerNumbers());
            }

            if (fullMarkedLines.Count <= 0) return false;
            var result = false;
            foreach (var line in fullMarkedLines)
            {
                if (AllNumbersInLineWereGenerated(line))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool AllNumbersInLineWereGenerated(IEnumerable<int> lineNumbers)
        {
            var gnm = CoreGameObjectsLocator.Default.GeneratedNumbersManager;
            var result = true;
            foreach (var number in lineNumbers)
            {
                var wasGenerated = gnm.CheckIfNumberWasGenerated(number);
                if (!wasGenerated)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private bool IsCornerNumbersMarked()
        {
            return (_markedNumbersMap[0, 0] > UnmarkedNumber)
                   && (_markedNumbersMap[4, 4] > UnmarkedNumber)
                   && (_markedNumbersMap[0, 4] > UnmarkedNumber)
                   && (_markedNumbersMap[4, 0] > UnmarkedNumber);
        }

        private int[] GetCornerNumbers()
        {
            return new[] { _markedNumbersMap[0, 0], _markedNumbersMap[4, 4], _markedNumbersMap[0, 4], _markedNumbersMap[4, 0] };
        }

        private bool IsUpLeftToDownRightDiagonalMarked()
        {
            var diagonalMarked = true;
            for (var diagonalIndex = 0; diagonalIndex < 5; diagonalIndex++)
            {
                if (_markedNumbersMap[diagonalIndex, diagonalIndex] <= UnmarkedNumber)
                {
                    diagonalMarked = false;
                    break;
                }
            }
            return diagonalMarked;
        }

        private bool IsUpRightToDownLeftDiagonalMarked()
        {
            var diagonalMarked = true;
            for (var diagonalIndex = 4; diagonalIndex >= 0; diagonalIndex--)
            {
                if (_markedNumbersMap[diagonalIndex, diagonalIndex] <= UnmarkedNumber)
                {
                    diagonalMarked = false;
                    break;
                }
            }
            return diagonalMarked;
        }

        private int[] GetUpLeftToDownRightDiagonal()
        {
            var diagonal = new int[5];
            for (var diagonalIndex = 0; diagonalIndex < 5; diagonalIndex++)
            {
                diagonal[diagonalIndex] = _markedNumbersMap[diagonalIndex, diagonalIndex];
            }
            return diagonal;
        }

        private int[] GetUpRightToDownLeftDiagonal()
        {
            var diagonal = new int[5];
            for (var diagonalIndex = 4; diagonalIndex >= 0; diagonalIndex--)
            {
                diagonal[diagonalIndex] = _markedNumbersMap[diagonalIndex, diagonalIndex];
            }
            return diagonal;
        }

        private bool IsLineMarkedInRow(int rowIndex)
        {
            var lineMarked = true;
            for (var columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
            {
                if (_markedNumbersMap[rowIndex, columnIndex] <= UnmarkedNumber)
                {
                    lineMarked = false;
                    break;
                }
            }
            return lineMarked;
        }

        private bool IsLineMarkedInColumn(int columnIndex)
        {
            var lineMarked = true;
            for (var rowIndex = 0; rowIndex < RowsCount; rowIndex++)
            {
                if (_markedNumbersMap[rowIndex, columnIndex] <= UnmarkedNumber)
                {
                    lineMarked = false;
                    break;
                }
            }
            return lineMarked;
        }

        private int[] GetLineFromColumn(int columnIndex)
        {
            var line = new int[5];
            for (var rowIndex=0; rowIndex < RowsCount; rowIndex++)
            {
                line[rowIndex] = _markedNumbersMap[rowIndex, columnIndex];
            }
            return line;
        }

        private int[] GetLineFromRow(int rowIndex)
        {
            var line = new int[5];
            for (var columnIndex = 0; columnIndex < ColumnsCount; columnIndex++)
            {
                line[columnIndex] = _markedNumbersMap[rowIndex, columnIndex];
            }
            return line;
        }

        #endregion

        #region IBingoCardViewController

        #region Events

        public event EventHandler BadBingoStated;
        private void OnBadBingoStated()
        {
            var handler = BadBingoStated;
            if (handler == null) return;
            handler(this, EventArgs.Empty);
        }

        public event EventHandler WinBingoStated;
        private void OnWinBingoStated()
        {
            var handler = WinBingoStated;
            if (handler == null) return;
            handler(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        public void EnableCard()
        {
            _bingoButton.interactable = true;
            EnableCardNumbersInput();
        }

        public void DisableCard()
        {
            _bingoButton.interactable = false;
            DisableCardNumbersInput();
        }

        #endregion

        #region Properties

        public bool Finished { get; private set; }

        public bool IsWinBingo { get; private set; }

        #endregion

        #endregion
    }
}