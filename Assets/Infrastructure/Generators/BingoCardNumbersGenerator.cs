using BrilliantBingo.Code.Infrastructure.Models;

namespace BrilliantBingo.Code.Infrastructure.Generators
{
    public class BingoCardNumbersGenerator
    {
        #region Methods

        public int[,] GenerateRandomBingoCardNumbers()
        {
            var ng = new BingoNumbersGenerator();
            var randomCardNumbers = new[,]
            {
                { ng.GenerateUniqueNumberForLetter(BingoLetter.B), ng.GenerateUniqueNumberForLetter(BingoLetter.I), ng.GenerateUniqueNumberForLetter(BingoLetter.N), ng.GenerateUniqueNumberForLetter(BingoLetter.G), ng.GenerateUniqueNumberForLetter(BingoLetter.O) },
                { ng.GenerateUniqueNumberForLetter(BingoLetter.B), ng.GenerateUniqueNumberForLetter(BingoLetter.I), ng.GenerateUniqueNumberForLetter(BingoLetter.N), ng.GenerateUniqueNumberForLetter(BingoLetter.G), ng.GenerateUniqueNumberForLetter(BingoLetter.O) },
                { ng.GenerateUniqueNumberForLetter(BingoLetter.B), ng.GenerateUniqueNumberForLetter(BingoLetter.I), ng.GenerateUniqueNumberForLetter(BingoLetter.N), ng.GenerateUniqueNumberForLetter(BingoLetter.G), ng.GenerateUniqueNumberForLetter(BingoLetter.O) },
                { ng.GenerateUniqueNumberForLetter(BingoLetter.B), ng.GenerateUniqueNumberForLetter(BingoLetter.I), ng.GenerateUniqueNumberForLetter(BingoLetter.N), ng.GenerateUniqueNumberForLetter(BingoLetter.G), ng.GenerateUniqueNumberForLetter(BingoLetter.O) },
                { ng.GenerateUniqueNumberForLetter(BingoLetter.B), ng.GenerateUniqueNumberForLetter(BingoLetter.I), ng.GenerateUniqueNumberForLetter(BingoLetter.N), ng.GenerateUniqueNumberForLetter(BingoLetter.G), ng.GenerateUniqueNumberForLetter(BingoLetter.O) }
            };
            return randomCardNumbers;
        }

        #endregion
    }
}