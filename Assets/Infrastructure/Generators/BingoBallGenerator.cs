using System;
using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure.Generators
{
    internal class BingoBallGenerator
    {
        #region Fields

        private readonly BingoNumbersGenerator _numbersGenerator;

        #endregion

        #region Constructors

        public BingoBallGenerator()
        {
            _numbersGenerator = new BingoNumbersGenerator();
        }

        #endregion

        #region Methods

        public BingoBall GenerateRandomBingoBall()
        {
            if (!CanGenerateBalls())
            {
                throw new Exception("All balls were already generated");
            }
            var randomLetter = GenerateRandomBingoLetter();
            if (!_numbersGenerator.CanGenerateNumberForLetter(randomLetter))
            {
                return GenerateRandomBingoBall();
            }
            var randomNumber = _numbersGenerator.GenerateUniqueNumberForLetter(randomLetter);
            return new BingoBall(randomLetter, randomNumber);
        }

        private BingoLetter GenerateRandomBingoLetter()
        {
            var randomLetterIndex = UnityEngine.Random.Range(0, 5);
            return BingoLetterCaster.IntToBingoLetter(randomLetterIndex);
        }

        /// <summary>
        /// Checks if it's possible to generate number for any letter
        /// </summary>
        /// <returns></returns>
        private bool CanGenerateBalls()
        {
            return
                (_numbersGenerator.CanGenerateNumberForLetter(BingoLetter.B) &&
                 _numbersGenerator.CanGenerateNumberForLetter(BingoLetter.I) &&
                 _numbersGenerator.CanGenerateNumberForLetter(BingoLetter.N) &&
                 _numbersGenerator.CanGenerateNumberForLetter(BingoLetter.G) &&
                 _numbersGenerator.CanGenerateNumberForLetter(BingoLetter.O));
        }

        #endregion
    }
}