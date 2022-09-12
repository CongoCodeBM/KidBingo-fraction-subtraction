using System;
using System.Collections.Generic;
using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure
{
    internal static class BingoLetterCaster
    {
        #region Fields

        private static IDictionary<BingoLetter, int> _bingoLetterToInt
            = new Dictionary<BingoLetter, int>
            {
                {BingoLetter.B, 0},
                {BingoLetter.I, 1},
                {BingoLetter.N, 2},
                {BingoLetter.G, 3},
                {BingoLetter.O, 4}
            };

        private static IDictionary<int, BingoLetter> _intToBingoLetter
            = new Dictionary<int, BingoLetter>
            {
                {0, BingoLetter.B},
                {1, BingoLetter.I},
                {2, BingoLetter.N},
                {3, BingoLetter.G},
                {4, BingoLetter.O}
            };

        private static IDictionary<BingoLetter, string> _bingoLetterToString
            = new Dictionary<BingoLetter, string>
            {
                {BingoLetter.B, "B"},
                {BingoLetter.I, "I"},
                {BingoLetter.N, "N"},
                {BingoLetter.G, "G"},
                {BingoLetter.O, "O"}
            };

        #endregion

        #region Mehods

        public static int BingoLetterToInt(BingoLetter letter)
        {
            return _bingoLetterToInt[letter];
        }

        public static string BingoLetterToString(BingoLetter letter)
        {
            return _bingoLetterToString[letter];
        }

        public static BingoLetter IntToBingoLetter(int letterIndex)
        {
            if (!_intToBingoLetter.ContainsKey(letterIndex))
            {
                throw new Exception("Can't cast index " + letterIndex + " to bingo letter");
            }
            return _intToBingoLetter[letterIndex];
        }

        #endregion
    }
}