using System;

namespace BrilliantBingo.Code.Infrastructure.Models
{
    public class BingoBall
    {
        #region Fields
        #endregion

        #region Construtors

        public BingoBall(BingoLetter letter, int number)
        {
            if (!BingoBallNumberValidator.IsBingoBallNumberValid(number))
            {
                throw new Exception("Unable to create bingo ball for number " + number);
            }
            Letter = letter;
            Number = number;
        }

        #endregion

        #region Properties

        public BingoLetter Letter { get; private set; }

        public int Number { get; private set; }

        #endregion
    }
}