using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Models;
using Random = UnityEngine.Random;

namespace BrilliantBingo.Code.Infrastructure.Generators
{
    internal class BingoNumbersGenerator
    {
        #region Fields

        private readonly IList<int> _bList;

        private readonly IList<int> _iList;

        private readonly IList<int> _nList;

        private readonly IList<int> _gList;

        private readonly IList<int> _oList;

        private readonly IList<int>[] _bingoNumberListsArray;

        #endregion

        #region Constructors

        public BingoNumbersGenerator()
        {
            _bList = GenerateNumbersForRange(BingoNumbersRanges.FromB, BingoNumbersRanges.ToB);
            _iList = GenerateNumbersForRange(BingoNumbersRanges.FromI, BingoNumbersRanges.ToI);
            _nList = GenerateNumbersForRange(BingoNumbersRanges.FromN, BingoNumbersRanges.ToN);
            _gList = GenerateNumbersForRange(BingoNumbersRanges.FromG, BingoNumbersRanges.ToG);
            _oList = GenerateNumbersForRange(BingoNumbersRanges.FromO, BingoNumbersRanges.ToO);

            _bingoNumberListsArray = new[] { _bList, _iList, _nList, _gList, _oList };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if it's possible to generate number for specified letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public bool CanGenerateNumberForLetter(BingoLetter letter)
        {
            var letterIndex = BingoLetterCaster.BingoLetterToInt(letter);
            return _bingoNumberListsArray[letterIndex].Count > 0;
        }

        /// <summary>
        /// Generates unique number according specified letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public int GenerateUniqueNumberForLetter(BingoLetter letter)
        {
            if (!CanGenerateNumberForLetter(letter))
            {
                throw new Exception("All numbers for letter " + letter + " were already generated");
            }
            var letterIndex = BingoLetterCaster.BingoLetterToInt(letter);
            var numbersList = _bingoNumberListsArray[letterIndex];

            var randomIndexForPickNumber = Random.Range(0, numbersList.Count);

            // Pick number by random index in numbersList
            var randomNumber = numbersList[randomIndexForPickNumber];
            
            // Remove picked number from list (we don't want generate this number again in further calls
            // to GenerateUniqueNumberForLetter() method)
            numbersList.RemoveAt(randomIndexForPickNumber);

            return randomNumber;
        }

        private IList<int> GenerateNumbersForRange(int from, int to)
        {
            var result = new List<int>();
            for (var i = from; i <= to; i++)
            {
                result.Add(i);
            }
            return result;
        }

        #endregion
    }
}